using AutoMapper;
using HRM_BE.Core.Constants.Contract;
using HRM_BE.Core.Data.Company;
using HRM_BE.Core.Data.Official_Form;
using HRM_BE.Core.Data.Payroll_Timekeeping.Shift;
using HRM_BE.Core.Data.Payroll_Timekeeping.TimekeepingRegulation;
using HRM_BE.Core.Data.Profile;
using HRM_BE.Core.Data.Staff;
using HRM_BE.Core.Exceptions;
using HRM_BE.Core.Extension;
using HRM_BE.Core.IRepositories;
using HRM_BE.Core.Models.Common;
using HRM_BE.Core.Models.DetailTimeSheet;
using HRM_BE.Core.Models.Payroll_Timekeeping.LeaveRegulation;
using HRM_BE.Core.Models.Payroll_Timekeeping.TimekeepingRegulation;
using HRM_BE.Core.Models.ShiftCatalog;
using HRM_BE.Core.Models.SumaryTimeSheet;
using HRM_BE.Data.SeedWorks;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.VisualBasic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;
using static System.Net.Mime.MediaTypeNames;

namespace HRM_BE.Data.Repositories
{
    public class DetailTimeSheetRepository : RepositoryBase<DetailTimesheetName, int>, IDetailTimeSheetRepository
    {
        private readonly IMapper _mapper;
        public DetailTimeSheetRepository(HrmContext context, IMapper mapper, IHttpContextAccessor httpContextAccessor) : base(context, httpContextAccessor)
        {
            _mapper = mapper;

        }

        public async Task<DetailTimeSheetDto> Create(CreateDetailTimeSheetRequest request)
        {
            var detailTimeSheet = _mapper.Map<DetailTimesheetName>(request);
            var entityReturn = await CreateAsync(detailTimeSheet);
            return _mapper.Map<DetailTimeSheetDto>(entityReturn);
        }

        public async Task Delete(int id)
        {
            var entity = await GetDetailTimesheetAndCheckExsit(id);
            entity.IsDeleted = false;
            await UpdateAsync(entity);
        }

        public async Task<DetailTimeSheetDto> GetById(int id)
        {
            var entity = await GetDetailTimesheetAndCheckExsit(id);
            return _mapper.Map<DetailTimeSheetDto>(entity);
        }

        public async Task<PagingResult<DetailTimeSheetDto>> Paging(string? name, int? month, int? year, int? organizationId, string? staffPositionIds, string? sortBy, string? orderBy, int pageIndex = 1, int pageSize = 10)
        {
            try
            {
                var query = _dbContext.DetailTimesheetNames
                    .Include(s => s.Organization).AsSplitQuery().AsNoTracking();

                if (!string.IsNullOrEmpty(name))
                    query = query.Where(c => c.TimekeepingSheetName.Contains(name));

                // Only call GetAllChildOrganizationIds if organizationId has a value
                List<int>? organizationDescendantIds = null;
                if (organizationId.HasValue)
                {
                    organizationDescendantIds = await GetAllChildOrganizationIds(organizationId.Value);
                    organizationDescendantIds.Add(organizationId.Value);
                    query = query.Where(c => organizationDescendantIds.Contains(c.OrganizationId.Value));
                }

                if (!string.IsNullOrEmpty(staffPositionIds))
                {
                    var staffpositionIds = staffPositionIds.Split(',').Select(id => int.Parse(id)).ToList();
                    query = query.Where(c => c.DetailTimesheetNameStaffPositions.Any(p => staffpositionIds.Contains(p.StaffPosition.Id)));
                }

                if (month.HasValue)
                    query = query.Where(c => c.EndDate.Value.Month >= month || c.StartDate.Value.Month <= month);

                if (year.HasValue)
                    query = query.Where(c => c.EndDate.Value.Year >= year || c.StartDate.Value.Year <= year);

                query = query.ApplySorting(sortBy, orderBy);
                int total = await query.CountAsync();
                query = query.ApplyPaging(pageIndex, pageSize);

                var data = await _mapper.ProjectTo<DetailTimeSheetDto>(query).ToListAsync();
                return new PagingResult<DetailTimeSheetDto>(data, pageIndex, pageSize, sortBy, orderBy, total);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }

        }

        public async Task Update(int id, UpdateDetailTimeSheetRequest request)
        {
            var detailTimesheet = await GetDetailTimesheetAndCheckExsit(id);

            _mapper.Map(request, detailTimesheet);
            // Xóa các StaffPosition cũ
            detailTimesheet.DetailTimesheetNameStaffPositions.Clear();

            // Thêm danh sách StaffPosition mới từ request
            foreach (var staffPositionRequest in request.StaffTimesheets)
            {
                var staffPosition = _dbContext.StaffPositions.Find(staffPositionRequest.StaffPositionId);
                if (staffPosition != null)
                {
                    var newStaffPosition = _mapper.Map<DetailTimesheetNameStaffPosition>(staffPositionRequest);
                    newStaffPosition.DetailTimesheetNameId = detailTimesheet.Id;
                    detailTimesheet.DetailTimesheetNameStaffPositions.Add(newStaffPosition);
                }
            }
            // Lưu các thay đổi vào cơ sở dữ liệu
            await _dbContext.SaveChangesAsync();

        }
        public async Task<DetailTimesheetName> GetDetailTimesheetAndCheckExsit(int id)
        {
            var entity = await _dbContext.DetailTimesheetNames
                .Include(d => d.DetailTimesheetNameStaffPositions).ThenInclude(d => d.StaffPosition)
                .SingleOrDefaultAsync(d => d.Id == id);
            if (entity is null)
                throw new EntityNotFoundException(nameof(DetailTimesheetName), $"Id = {id}");
            return entity;
        }

        /// <summary>
        /// Lấy danh sách nhân viên + chấm công theo 1 DetailTimeSheet (KHÔNG phân trang)
        /// Bắt đầu từ Employee (theo Organization) rồi lấy Timesheet trong khoảng thời gian của sheet.
        /// </summary>
        public async Task<List<GetDetailTimesheetWithEmployeeDto>> DetailTimeSheetWithEmployee(
            int detailTimeSheetId,
            string? keyWord,
            int? organizationId,
            string? sortBy,
            string? orderBy)
        {
            var detailTimeSheet = await _dbContext.DetailTimesheetNames.FindAsync(detailTimeSheetId);
            if (detailTimeSheet is null)
                throw new EntityNotFoundException(nameof(DetailTimesheetName), $"Id = {detailTimeSheetId}");

            if (!detailTimeSheet.StartDate.HasValue || !detailTimeSheet.EndDate.HasValue)
                throw new Exception("DetailTimesheetName chưa cấu hình StartDate/EndDate.");

            // Lấy gốc organization: ưu tiên tham số truyền vào, nếu null thì lấy từ DetailTimesheetName
            int rootOrganizationId;
            if (organizationId.HasValue)
            {
                rootOrganizationId = organizationId.Value;
            }
            else if (detailTimeSheet.OrganizationId.HasValue)
            {
                rootOrganizationId = detailTimeSheet.OrganizationId.Value;
            }
            else
            {
                throw new Exception("DetailTimesheetName không có OrganizationId và không truyền organizationId.");
            }

            // Lấy toàn bộ phòng ban con (cả cây) + chính nó
            var organizationDescendantIds = await GetAllChildOrganizationIds(rootOrganizationId);
            organizationDescendantIds.Add(rootOrganizationId);

            var query = _dbContext.Employees
                .Where(e => organizationDescendantIds.Contains(e.OrganizationId.Value)
                            && e.AccountStatus == AccountStatus.Active)
                .AsNoTracking();

            if (!string.IsNullOrEmpty(keyWord))
            {
                keyWord = keyWord.Trim();
                query = query.Where(c => (c.LastName.Trim() + " " + c.FirstName.Trim()).Contains(keyWord) ||
                                         (c.FirstName.Trim() + " " + c.LastName.Trim()).Contains(keyWord));
            }

            // Lọc theo Timesheet trong khoảng thời gian của sheet
            // Chỉ giữ những nhân viên có ít nhất 1 bản ghi chấm công trong khoảng StartDate-EndDate
            query = query.Where(e => e.Timesheets.Any(t =>
                t.Date.HasValue &&
                t.Date.Value.Date >= detailTimeSheet.StartDate.Value.Date &&
                t.Date.Value.Date <= detailTimeSheet.EndDate.Value.Date
            ));

            // Áp dụng sắp xếp (nếu có)
            query = query.ApplySorting(sortBy, orderBy);

            // Map ra DTO (không phân trang)
            var data = await query.Select(e => new GetDetailTimesheetWithEmployeeDto
            {
                Id = e.Id,
                EmployeeCode = e.EmployeeCode,
                FirstName = e.FirstName,
                LastName = e.LastName,
                Timesheets = e.Timesheets
                    .Where(t => t.Date.Value.Date >= detailTimeSheet.StartDate.Value.Date
                                && t.Date.Value.Date <= detailTimeSheet.EndDate.Value.Date)
                    .GroupBy(t => t.Date.Value.Date)
                    .Select(g => new ConfirmTimeSheetDto
                    {
                        Date = g.Key,
                        Shifts = g.Select(t => new ShiftDetailDto
                        {
                            TimeSheetId = t.Id,
                            StartTime = t.StartTime,
                            EndTime = t.EndTime,
                            ShiftWorkId = t.ShiftWorkId,
                            NumberOfWorkingHour = t.NumberOfWorkingHour,
                            TimekeepingType = t.TimekeepingType,
                            ShiftTableName = t.ShiftWork.ShiftTableName,
                            TimeKeepingLeaveStatus = t.TimeKeepingLeaveStatus,
                            IsEnoughWork = t.NumberOfWorkingHour >= (t.ShiftWork.ShiftCatalog.WorkingHours ?? 0)
                        }).ToList()
                    }).ToList(),
                IsOffical = e.Contracts
                    .Where(c => !c.ContractName.Contains(ContractConstant.InterContract)
                                && c.SignStatus == SignStatus.Signed)
                    .FirstOrDefault() != null,
                Holidays = e.Organization.Holidays.Select(h => new HolidayDto
                {
                    Id = h.Id,
                    Name = h.Name,
                    FromDate = h.FromDate,
                    ToDate = h.ToDate,
                    OrganizationId = h.OrganizationId,
                    ApplyObject = h.ApplyObject
                }).ToList()
            }).ToListAsync();

            return data;
        }

        // test commit
        public async Task<PagingResult<GetDetailTimesheetWithEmployeeDto>> DetailTimeSheetWithEmployeePaging(int detailTimeSheetId, string? keyWord, int? organizationId, string? sortBy, string? orderBy, int pageIndex = 1, int pageSize = 10)
        {
            var detailTimeSheet = await _dbContext.DetailTimesheetNames.FindAsync(detailTimeSheetId);
            if (detailTimeSheet is null)
                throw new EntityNotFoundException(nameof(DetailTimesheetName), $"Id = {detailTimeSheetId}");


            // Lấy gốc organization: ưu tiên tham số truyền vào, nếu null thì lấy từ DetailTimesheetName
            int rootOrganizationId;
            if (organizationId.HasValue)
            {
                rootOrganizationId = organizationId.Value;
            }
            else if (detailTimeSheet.OrganizationId.HasValue)
            {
                rootOrganizationId = detailTimeSheet.OrganizationId.Value;
            }
            else
            {
                throw new Exception("DetailTimesheetName không có OrganizationId và không truyền organizationId.");
            }

            // Lấy toàn bộ phòng ban con (cả cây) + chính nó
            var organizationDescendantIds = await GetAllChildOrganizationIds(rootOrganizationId);
            organizationDescendantIds.Add(rootOrganizationId);

            var query = _dbContext.Employees.Where(e => organizationDescendantIds.Contains(e.OrganizationId.Value) && e.AccountStatus == AccountStatus.Active).AsNoTracking();

            //query = query.Where( e => e.Timesheets.Any( t => t.Date >= detailTimeSheet.StartDate && t.Date <= detailTimeSheet.EndDate));
            if (!string.IsNullOrEmpty(keyWord))
            {
                keyWord = keyWord.Trim(); // Loại bỏ khoảng trắng thừa đầu và cuối từ khóa
                query = query.Where(c => (c.LastName.Trim() + " " + c.FirstName.Trim()).Contains(keyWord) ||
                                         (c.FirstName.Trim() + " " + c.LastName.Trim()).Contains(keyWord));
            }
            //if (organizationId.HasValue)
            //{
            //    query = query.Where(c => c.OrganizationId == organizationId);
            //}
            query = query.Where(e => e.Contracts.Any(c =>
                c.ExpiryDate.HasValue &&
                c.EffectiveDate.HasValue &&
                c.ExpiryDate.Value.Date <= detailTimeSheet.EndDate.Value.Date &&
                c.EffectiveDate.Value.Date >= detailTimeSheet.StartDate.Value.Date
            ));
            // Áp dụng sắp xếp
            query = query.ApplySorting(sortBy, orderBy);
            // Tính tổng số bản ghi
            int total = await query.CountAsync();
            // Áp dụng phân trang
            query = query.ApplyPaging(pageIndex, pageSize);
            // Cũ
            #region 
            var data = await query.Select(e => new GetDetailTimesheetWithEmployeeDto
            {
                Id = e.Id,
                EmployeeCode = e.EmployeeCode,
                FirstName = e.FirstName,
                LastName = e.LastName,
                Timesheets = e.Timesheets.Where(t => t.Date.Value.Date >= detailTimeSheet.StartDate.Value.Date
                && t.Date.Value.Date <= detailTimeSheet.EndDate.Value.Date).GroupBy(t => t.Date.Value.Date)
                .Select(g => new ConfirmTimeSheetDto
                {
                    Date = g.Key,
                    Shifts = g.Select(t => new ShiftDetailDto
                    {
                        TimeSheetId = t.Id,
                        StartTime = t.StartTime,
                        EndTime = t.EndTime,
                        ShiftWorkId = t.ShiftWorkId,
                        NumberOfWorkingHour = t.NumberOfWorkingHour,
                        TimekeepingType = t.TimekeepingType,
                        ShiftTableName = t.ShiftWork.ShiftTableName,
                        TimeKeepingLeaveStatus = t.TimeKeepingLeaveStatus,
                        IsEnoughWork = t.NumberOfWorkingHour >= (t.ShiftWork.ShiftCatalog.WorkingHours ?? 0) ? true : false
                    }).ToList()
                }).ToList(),
                IsOffical = e.Contracts.Where(c => !c.ContractName.Contains(ContractConstant.InterContract) && c.SignStatus == SignStatus.Signed).FirstOrDefault() != null ? true : false,
                Holidays = e.Organization.Holidays.Select(h => new HolidayDto
                {
                    Id = h.Id,
                    Name = h.Name,
                    FromDate = h.FromDate,
                    ToDate = h.ToDate,
                    OrganizationId = h.OrganizationId,
                    ApplyObject = h.ApplyObject
                }).ToList()
                //PermittedLeaves = e.PermittedLeaves
                //.Where(p =>
                //    p.StartDate.Value.Date <= detailTimeSheet.EndDate.Value.Date &&
                //    p.EndDate.Value.Date >= detailTimeSheet.StartDate.Value.Date &&
                //    p.Status == LeaveApplicationStatus.Approved &&
                //    //p.LeavePermission.Any(lp => lp.LeavePerrmissionStatus == LeavePerrmissionStatus.Active) &&
                //    p.EmployeeId == e.Id)
                //.OrderBy(p => p.CreatedAt)
                //.Select(p => new PermittedLeaveDto
                //{
                //    Id = p.Id,
                //    Date = null,
                //    NumberOfDays = p.NumberOfDays.Value
                //}).ToList()
            }).ToListAsync();
            #endregion

            var result = new PagingResult<GetDetailTimesheetWithEmployeeDto>(data, pageIndex, pageSize, sortBy, orderBy, total);
            //var leaveApplications = await _dbContext.LeaveApplications.Where( s => s.StartDate <= detailTimeSheet.EndDate).ToListAsync();
            //var leavePermissions = await _dbContext.LeavePermissions.ToListAsync();
            //foreach (var item in result.Items)
            //{
            //    //var leaveApplications = await _dbContext.LeaveApplications.Where( l => l.EmployeeId == item.Id ).ToListAsync();
            //    //var leavePermissions = await _dbContext.LeavePermissions.Where(l => l.EmployeeId == item.Id).ToListAsync();

            //    item.PermittedLeaves.ForEach( lp => lp.Date = AllocateLeaveDays(
            //        leaveApplications.Where(l => l.EmployeeId == item.Id).ToList(),
            //        leavePermissions.Where( lps => lps.EmployeeId == item.Id && lps.LeavePerrmissionStatus == LeavePerrmissionStatus.Active).ToList()));
            //}
            return result;
        }
        private List<DateTime> GetDatesInRange(DateTime startDate, DateTime endDate)
        {
            var dates = new List<DateTime>();
            for (var date = startDate.Date; date <= endDate.Date; date = date.AddDays(1))
            {
                dates.Add(date);
            }
            return dates;
        }
        public List<DateTime> AllocateLeaveDays(List<LeaveApplication> leaveApplications, List<LeavePermission> leavePermissions)
        {
            var leaveDays = new List<DateTime>();
            var totalDaysRequested = leaveApplications.Sum(l => l.NumberOfDays) ?? 0;
            // Tổng số ngày nghỉ có lương từ LeavePermissions
            var totalLeavePermission = leavePermissions
                .Where(l => l.LeavePerrmissionStatus == LeavePerrmissionStatus.Active)
                .Sum(p => p.NumerOfLeave);
            // Lặp qua từng LeaveApplication
            foreach (var application in leaveApplications.OrderBy(l => l.StartDate))
            {
                // Lấy ngày bắt đầu và kết thúc
                var startDate = application.StartDate.Value;
                var endDate = application.EndDate.Value;

                // Lặp qua từng ngày từ StartDate đến EndDate
                for (var date = startDate; date < endDate; date = date.AddDays(1))
                {
                    if (leaveDays.Count < totalLeavePermission)
                    {
                        leaveDays.Add(date);
                    }
                    else
                    {
                        break; // Đủ số ngày nghỉ, thoát vòng lặp
                    }
                }

                // Dừng nếu đã đủ số ngày nghỉ có lương
                if (leaveDays.Count >= totalLeavePermission)
                {
                    break;
                }
            }

            return leaveDays.OrderBy(d => d).ToList();
        }

        #region
        //public async Task<PagingResult<GetDetailTimesheetWithEmployeeDto>> DetailTimeSheetWithEmployeePaging(int detailTimeSheetId, string? keyWord, int? organizationId, string? sortBy, string? orderBy, int pageIndex = 1, int pageSize = 10)
        //{
        //    var detailTimeSheet = await _dbContext.DetailTimesheetNames.FindAsync(detailTimeSheetId);
        //    if (detailTimeSheet is null)
        //        throw new EntityNotFoundException(nameof(DetailTimesheetName), $"Id = {detailTimeSheetId}");

        //    var query = _dbContext.Employees.Where(e => e.OrganizationId == detailTimeSheet.OrganizationId).AsNoTracking();

        //    if (!string.IsNullOrEmpty(keyWord))
        //    {
        //        keyWord = keyWord.Trim();
        //        query = query.Where(c => (c.LastName.Trim() + " " + c.FirstName.Trim()).Contains(keyWord) ||
        //                                 (c.FirstName.Trim() + " " + c.LastName.Trim()).Contains(keyWord));
        //    }
        //    if (organizationId.HasValue)
        //    {
        //        query = query.Where(c => c.OrganizationId == organizationId);
        //    }

        //    query = query.ApplySorting(sortBy, orderBy);
        //    int total = await query.CountAsync();
        //    query = query.ApplyPaging(pageIndex, pageSize);

        //    var data = await query.Select(e => new GetDetailTimesheetWithEmployeeDto
        //    {
        //        Id = e.Id,
        //        EmployeeCode = e.EmployeeCode,
        //        FirstName = e.FirstName,
        //        LastName = e.LastName,
        //        Timesheets = e.Timesheets.Where(t => t.Date.Value.Date >= detailTimeSheet.StartDate.Value.Date
        //        && t.Date.Value.Date <= detailTimeSheet.EndDate.Value.Date).GroupBy(t => t.Date.Value.Date)
        //        .Select(g => new ConfirmTimeSheetDto
        //        {
        //            Date = g.Key,
        //            Shifts = g.Select(t => new ShiftDetailDto
        //            {
        //                TimeSheetId = t.Id,
        //                StartTime = t.StartTime,
        //                EndTime = t.EndTime,
        //                ShiftWorkId = t.ShiftWorkId,
        //                NumberOfWorkingHour = t.NumberOfWorkingHour,
        //                TimekeepingType = t.TimekeepingType,
        //                ShiftTableName = t.ShiftWork.ShiftTableName,
        //                IsEnoughWork = t.NumberOfWorkingHour >= (t.ShiftWork.ShiftCatalog.WorkingHours ?? 0) ? true : false
        //            }).ToList()
        //        }).ToList(),
        //        PermittedLeaves = e.PermittedLeaves
        //            .Where(p =>
        //                p.StartDate.Value.Date <= detailTimeSheet.EndDate.Value.Date &&
        //                p.EndDate.Value.Date >= detailTimeSheet.StartDate.Value.Date &&
        //                p.Status == LeaveApplicationStatus.Approved &&
        //                p.EmployeeId == e.Id)
        //            .AsEnumerable()
        //            // Chuyển sang client-side
        //            .Where(p => IsContractValid(e.Contracts.AsEnumerable(), p.StartDate.Value, p.EndDate.Value)) // Kiểm tra hợp đồng ở đây
        //            .OrderBy(p => p.CreatedAt)
        //            .Take(1) // 1 tháng chỉ mặc định 1 phép
        //            .Select(p => new PermittedLeaveDto
        //            {
        //                Id = p.Id,
        //                Date = p.StartDate.Value,
        //                NumberOfDays = p.NumberOfDays.Value
        //            })
        //            .ToList()
        //    }).ToListAsync();

        //    var result = new PagingResult<GetDetailTimesheetWithEmployeeDto>(data, pageIndex, pageSize, sortBy, orderBy, total);
        //    return result;
        //}

        //// Phương thức kiểm tra hợp đồng
        //private bool IsContractValid(IEnumerable<Contract> contracts, DateTime startDate, DateTime endDate)
        //{
        //    return contracts.Any(c =>
        //        c.ExpiredStatus == false &&
        //        (c.EffectiveDate.Value.Date.Day == 1
        //            ? c.EffectiveDate.Value.Date
        //            : new DateTime(c.EffectiveDate.Value.Year, c.EffectiveDate.Value.Month, 1).AddMonths(1)) >= startDate &&
        //        (c.EffectiveDate.Value.Date.Day == 1
        //            ? c.EffectiveDate.Value.Date
        //            : new DateTime(c.EffectiveDate.Value.Year, c.EffectiveDate.Value.Month, 1).AddMonths(1)) <= endDate);
        //}
        #endregion
        public async Task LockDetailTimeSheet(int id, bool isLock)
        {
            var entity = await GetDetailTimesheetAndCheckExsit(id);
            entity.IsLock = isLock;
            await UpdateAsync(entity);
        }

        public async Task<StatiscTimeSheetDto> StatiscTimeSheetDto(int detailTimeSheetId)
        {
            var detailTimeSheet = await _dbContext.DetailTimesheetNames.FindAsync(detailTimeSheetId);
            if (detailTimeSheet is null)
                throw new EntityNotFoundException(nameof(DetailTimesheetName), $"Id = {detailTimeSheetId}");

            var totalWokring = await _dbContext.Timesheets.Where(t => t.Date.Value.Date == DateTime.Now.Date && t.EarlyLeaveDuration == 0 && t.LateDuration == 0 && t.TimeKeepingLeaveStatus == TimeKeepingLeaveStatus.None && t.Employee.Contracts.Any(c =>
              c.ExpiryDate.HasValue &&
             c.EffectiveDate.HasValue &&
             c.ExpiryDate.Value.Date <= detailTimeSheet.EndDate.Value.Date &&
             c.EffectiveDate.Value.Date.Month >= detailTimeSheet.StartDate.Value.Date.Month
             )).CountAsync();


            var totalLateEarly = await _dbContext.Timesheets.Where(t => t.Date.Value.Date == DateTime.Now.Date && (t.EarlyLeaveDuration > 0 || t.LateDuration > 0) && t.Employee.Contracts.Any(c =>
              c.ExpiryDate.HasValue &&
             c.EffectiveDate.HasValue &&
             c.ExpiryDate.Value.Date <= detailTimeSheet.EndDate.Value.Date &&
             c.EffectiveDate.Value.Date.Month >= detailTimeSheet.StartDate.Value.Date.Month
             )).CountAsync();

            var organizationDescendantIds = await GetAllChildOrganizationIds(detailTimeSheet.OrganizationId.Value);
            organizationDescendantIds.Add(detailTimeSheet.OrganizationId.Value);

            var totalEmployee = await _dbContext.Employees.Where(e => organizationDescendantIds.Contains(e.OrganizationId.Value) && e.AccountStatus == AccountStatus.Active &&
                e.Contracts.Any(c =>
              c.ExpiryDate.HasValue &&
             c.EffectiveDate.HasValue &&
             c.ExpiryDate.Value.Date <= detailTimeSheet.EndDate.Value.Date &&
             c.EffectiveDate.Value.Date.Month >= detailTimeSheet.StartDate.Value.Date.Month
             )).CountAsync();

            var totalLeaveWorking = _dbContext.LeaveApplications.Where(l => l.Employee.OrganizationId == detailTimeSheet.OrganizationId
            && l.StartDate.Value.Date <= DateTime.Now.Date && DateTime.Now.Date <= l.EndDate.Value.Date && l.SalaryPercentage > 0).Select(l => l.EmployeeId).Count();
            var totalNotCheck = totalEmployee - totalWokring - totalLateEarly;
            return new StatiscTimeSheetDto
            {
                TotalWokring = totalWokring,
                TotalLateEarly = totalLateEarly,
                TotalLeaveWorking = totalLeaveWorking,
                TotalNotCheck = totalNotCheck - totalLeaveWorking
            };

        }

        public async Task<PagingResult<DetailTimeSheetDto>> GetSelect(string? name, int? month, int? year, int? organizationId, string? staffPositionIds, string? sortBy, string? orderBy, int pageIndex = 1, int pageSize = 10)
        {
            //var detailTimesheetNameids = await _dbContext.SummaryTimesheetNameDetailTimesheetNames.Select(s => s.DetailTimesheetNameId).ToListAsync();
            var query = _dbContext.DetailTimesheetNames
                .Where(d => !_dbContext.SummaryTimesheetNameDetailTimesheetNames.Any(s => s.DetailTimesheetNameId == d.Id)) // lọc những id chưa tồn tại trong chấm công tổng hợp
            //.Where( d => !detailTimesheetNameids.Contains(d.Id))
                .Include(s => s.Organization).AsSplitQuery().AsNoTracking();
            if (!string.IsNullOrEmpty(name))
            {
                query = query.Where(c => c.TimekeepingSheetName.Contains(name));
            }
            if (organizationId.HasValue)
            {
                query = query.Where(c => c.OrganizationId == organizationId);
            }
            if (!string.IsNullOrEmpty(staffPositionIds))
            {
                var staffpositionIds = staffPositionIds.Split(',').Select(id => int.Parse(id)).ToList();

                query = query.Where(c => c.DetailTimesheetNameStaffPositions.Any(p => staffpositionIds.Contains(p.StaffPosition.Id)));
            }
            if (month.HasValue)
            {
                query = query.Where(c => c.EndDate.Value.Month >= month);
            }
            if (year.HasValue)
            {
                query = query.Where(c => c.EndDate.Value.Year >= year);
            }
            // Áp dụng sắp xếp
            query = query.ApplySorting(sortBy, orderBy);
            // Tính tổng số bản ghi
            int total = await query.CountAsync();
            // Áp dụng phân trang
            query = query.ApplyPaging(pageIndex, pageSize);

            var data = await _mapper.ProjectTo<DetailTimeSheetDto>(query).ToListAsync();

            var result = new PagingResult<DetailTimeSheetDto>(data, pageIndex, pageSize, sortBy, orderBy, total);

            return result;
        }
        public async Task<List<int>> GetAllChildOrganizationIds(int parentId)
        {
            // Lấy tất cả các tổ chức
            var allOrganizations = await _dbContext.Organizations.AsNoTracking().ToListAsync();

            // Gọi hàm đệ quy để tìm tất cả các Id con
            var result = new List<int>();
            GetChildIdsRecursive(parentId, allOrganizations, result);
            return result;
        }

        private void GetChildIdsRecursive(int parentId, List<Organization> allOrganizations, List<int> result)
        {
            // Lấy tất cả các con trực tiếp của parentId
            var children = allOrganizations.Where(o => o.OrganizatioParentId == parentId).ToList();

            foreach (var child in children)
            {
                result.Add(child.Id); // Thêm Id của con vào danh sách kết quả
                GetChildIdsRecursive(child.Id, allOrganizations, result); // Gọi đệ quy cho các con
            }
        }
    }
}
