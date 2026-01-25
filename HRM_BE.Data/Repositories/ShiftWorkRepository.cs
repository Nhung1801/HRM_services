using AutoMapper;
using HRM_BE.Core.Data.Payroll_Timekeeping.Shift;
using HRM_BE.Core.Data.Staff;
using HRM_BE.Core.Exceptions;
using HRM_BE.Core.Extension;
using HRM_BE.Core.IRepositories;
using HRM_BE.Core.ISeedWorks;
using HRM_BE.Core.Models.Common;
using HRM_BE.Core.Models.ShiftCatalog;
using HRM_BE.Core.Models.ShiftWork;
using HRM_BE.Data.SeedWorks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc.ViewFeatures;
using Microsoft.EntityFrameworkCore;

namespace HRM_BE.Data.Repositories
{
    public class ShiftWorkRepository : RepositoryBase<ShiftWork, int>, IShiftWorkRepository
    {
        private readonly IMapper _mapper;
        public ShiftWorkRepository(HrmContext context, IMapper mapper, IHttpContextAccessor httpContextAccessor) : base(context, httpContextAccessor)
        {
            _mapper = mapper;
        }

        public async Task<ShiftWorkDto> Create(CreateShiftWorkRequest request)
        {
            var entity = _mapper.Map<ShiftWork>(request);
            var enittyReturn = await CreateAsync(entity);
            return _mapper.Map<ShiftWorkDto>(enittyReturn);
        }

        public async Task Delete(int shiftWorkId)
        {
            var entity = await GetShiftWorkAndCheckExist(shiftWorkId);
            entity.IsDeleted = true;
            await UpdateAsync(entity);
        }

        public async Task<ShiftWorkDto> GetById(int id)
        {
            var entity = await GetShiftWorkAndCheckExist(id);
            return _mapper.Map<ShiftWorkDto>(entity);
        }


        public async Task<PagingResult<ShiftWorkDto>> Paging(string? name, int? organizationId, string? sortBy, string? orderBy, int pageIndex, int pageSize)
        {
            var query = _dbContext.ShiftWorks.AsNoTracking();
            if (!string.IsNullOrEmpty(name))
            {
                query = query.Where(c => c.ShiftTableName.Contains(name));
            }
            if (organizationId.HasValue)
            {
                query = query.Where(c => c.OrganizationId == organizationId);
            }

            // Áp dụng sắp xếp
            query = query.ApplySorting(sortBy, orderBy);
            // Tính tổng số bản ghi
            int total = await query.CountAsync();
            // Áp dụng phân trang
            query = query.ApplyPaging(pageIndex, pageSize);

            var data = await _mapper.ProjectTo<ShiftWorkDto>(query).ToListAsync();

            var result = new PagingResult<ShiftWorkDto>(data, pageIndex, pageSize, sortBy, orderBy, total);

            return result;
        }

        public async Task Update(int shiftWorkId, UpdateShiftWorkRequest request)
        {
            var entity = await GetShiftWorkAndCheckExist(shiftWorkId);
            await UpdateAsync(_mapper.Map(request, entity));
        }


        public async Task<List<ShiftWorkDto>> GetByEmployee(DateTime adjustedStartDate, DateTime adjustedEndDate, int employeeId)
        {
            var employee = await _dbContext.Employees.FirstOrDefaultAsync(e => e.Id == employeeId);
            if (employee == null)
            {
                throw new EntityNotFoundException(nameof(Employee), $"Id={employeeId}");
            }

            var organizationId = employee.OrganizationId;

            var allShiftWorks = await _dbContext.ShiftWorks
                .Include(sw => sw.ShiftCatalog)
                .Where(sw => sw.OrganizationId == organizationId && sw.IsDeleted != true &&
                             sw.StartDate <= adjustedEndDate &&
                             (sw.EndDate == null || sw.EndDate >= adjustedStartDate))
                .ToListAsync();

            var shiftWorkDtos= _mapper.Map<List<ShiftWorkDto>>(allShiftWorks);

            return shiftWorkDtos; 
        }



        private async Task<ShiftWork> GetShiftWorkAndCheckExist(int shiftWorkId)
        {
            var shiftWork = await _dbContext.ShiftWorks.Include(s => s.Organization).Include(s => s.ShiftCatalog).SingleOrDefaultAsync(s => s.Id == shiftWorkId);
            if (shiftWork is null)
                throw new EntityNotFoundException(nameof(ShiftWork), $"Id = {shiftWorkId}");
            return shiftWork;
        }


        // Method lấy shiftWorkId cho màn chấm công GPS vào ra
        public async Task<int?> GetShiftWorkIdForModuleTimekeepingGpsInOutAsync(int organizationId, DateTime currentDateTime)
        {
            // Lọc các phân ca theo OrganizationId
            var shiftWorks = await _dbContext.ShiftWorks
                .Include(s => s.ShiftCatalog)
                .Where(s => s.OrganizationId == organizationId)
                .ToListAsync();

            // Lọc theo ngày hợp lệ
            shiftWorks = shiftWorks.Where(s => s.StartDate <= currentDateTime.Date && s.EndDate >= currentDateTime.Date).ToList();

            // Xác định thứ hiện tại
            var currentDayOfWeek = (int)currentDateTime.DayOfWeek; // 0: Chủ nhật, 1: Thứ hai, ..., 6: Thứ bảy

            shiftWorks = shiftWorks
                .Where(s => (currentDayOfWeek == 0 && s.IsSunday == true)
                            || (currentDayOfWeek == 1 && s.IsMonday == true)
                            || (currentDayOfWeek == 2 && s.IsTuesday == true)
                            || (currentDayOfWeek == 3 && s.IsWednesday == true)
                            || (currentDayOfWeek == 4 && s.IsThursday == true)
                            || (currentDayOfWeek == 5 && s.IsFriday == true)
                            || (currentDayOfWeek == 6 && s.IsSaturday == true))
                .ToList();

            // Lọc theo giờ trong ngày
            var currentHour = currentDateTime.TimeOfDay;

            // Tìm tất cả các ca phù hợp
            var validShiftWorks = shiftWorks
                .Where(s =>
                    s.ShiftCatalog.StartTimeIn <= currentHour && // Trong khoảng bắt đầu check-in
                    s.ShiftCatalog.EndTimeOut >= currentHour // Trong khoảng kết thúc check-out
                )
                .ToList();

            // Nếu có nhiều ca phù hợp, ưu tiên theo khoảng cách thời gian
            if (validShiftWorks.Count > 1)
            {
                validShiftWorks = validShiftWorks
                    .OrderBy(s =>
                    {
                        // Tính khoảng cách thời gian so với `EndTimeOut` hoặc `StartTimeIn`
                        var timeToEndTimeOut = Math.Abs((s.ShiftCatalog.EndTimeOut - currentHour)?.TotalMinutes ?? 0);
                        var timeToStartTimeIn = Math.Abs((s.ShiftCatalog.StartTimeIn - currentHour)?.TotalMinutes ?? 0);
                        return Math.Min(timeToEndTimeOut, timeToStartTimeIn);
                    })
                    .ToList();
            }

            // Lấy ca phù hợp nhất
            var bestShiftWork = validShiftWorks.FirstOrDefault();

            return bestShiftWork?.Id;
        }





        //tny
        //get schedule
        public async Task<List<ShiftScheduleDto>> GetShiftsForPeriod(DateTime startDate, DateTime endDate, int employeeId)
        {

            var employee = await _dbContext.Employees.FirstOrDefaultAsync(e => e.Id == employeeId);
            if (employee == null)
            {
                throw new EntityNotFoundException(nameof(Employee), $"Id={employeeId}");
            }

            var organizationId = employee.OrganizationId;
            var dates = Enumerable.Range(0, (endDate - startDate).Days + 1)
                                       .Select(offset => startDate.AddDays(offset))
                                       .ToList();

            var shifts = await _dbContext.ShiftWorks
                                .Where(sw => sw.OrganizationId == organizationId &&
                                             sw.StartDate <= endDate &&
                                             sw.EndDate >= startDate)
                                .Include(sw => sw.ShiftCatalog)
                                .ToListAsync();

            //var shiftSchedules = dates.Select(date => new ShiftScheduleDto
            //{
            //    Date = date,
            //    Shifts = shifts.Where(sw => date >= sw.StartDate && date <= sw.EndDate &&
            //                                IsShiftScheduled(sw, date))
            //                .Select(sw => new ShiftCatalogScheduleDto
            //                {
            //                    Id = sw.ShiftCatalog.Id,
            //                    Code = sw.ShiftCatalog.Code,
            //                    Name = sw.ShiftCatalog.Name,
            //                    StartTime = sw.ShiftCatalog.StartTime,
            //                    EndTime = sw.ShiftCatalog.EndTime
            //                })
            //                .ToList()
            //}).ToList();

            var shiftSchedules = dates.Select(date => new ShiftScheduleDto
            {
                Date = date.Date,
                Shifts = shifts.Where(sw => date.Date.Date >= sw.StartDate?.Date && date.Date <= sw.EndDate?.Date &&
                                            IsShiftScheduled(sw, date.Date))
                    .Select(sw => new ShiftCatalogScheduleDto
                    {
                        Id = sw.ShiftCatalog.Id,
                        Code = sw.ShiftCatalog.Code,
                        Name = sw.ShiftCatalog.Name,
                        StartTime = sw.ShiftCatalog.StartTime,
                        EndTime = sw.ShiftCatalog.EndTime
                    })
                    .ToList()
            }).ToList();


            return shiftSchedules;
        }

        private bool IsShiftScheduled(ShiftWork shiftWork, DateTime date)
        {
            var dayOfWeekMatches = (date.DayOfWeek == DayOfWeek.Monday && shiftWork.IsMonday == true ||
                                    date.DayOfWeek == DayOfWeek.Tuesday && shiftWork.IsTuesday == true ||
                                    date.DayOfWeek == DayOfWeek.Wednesday && shiftWork.IsWednesday == true ||
                                    date.DayOfWeek == DayOfWeek.Thursday && shiftWork.IsThursday == true ||
                                    date.DayOfWeek == DayOfWeek.Friday && shiftWork.IsFriday == true ||
                                    date.DayOfWeek == DayOfWeek.Saturday && shiftWork.IsSaturday == true ||
                                    date.DayOfWeek == DayOfWeek.Sunday && shiftWork.IsSunday == true);

            if (!dayOfWeekMatches) return false;
            ///////tuần lẻ đi làm
            if (shiftWork.RecurrenceType.HasValue && shiftWork.RecurrenceCount.HasValue)
            {
                var firstDay = shiftWork.StartDate?.Date ?? date;
                switch (shiftWork.RecurrenceType.Value)
                {
                    case RecurrenceType.Day:
                        return (date - firstDay).Days % shiftWork.RecurrenceCount == 0;
                    case RecurrenceType.Week:
                        return (date - firstDay).Days / 7 % shiftWork.RecurrenceCount == 0;
                    case RecurrenceType.Month:
                        return ((date.Year - firstDay.Year) * 12 + date.Month - firstDay.Month) % shiftWork.RecurrenceCount == 0;
                    case RecurrenceType.Year:
                        return (date.Year - firstDay.Year) % shiftWork.RecurrenceCount == 0;
                    default:
                        return true;
                }
            }

            #region tuan chan

            /////////tuần lẻ đi làm
            //if (shiftWork.RecurrenceType.HasValue && shiftWork.RecurrenceCount.HasValue)
            //{
            //    var firstDay = shiftWork.StartDate ?? date;
            //    switch (shiftWork.RecurrenceType.Value)
            //    {
            //        case RecurrenceType.Day:
            //            return (date - firstDay).Days % shiftWork.RecurrenceCount == 0;
            //        case RecurrenceType.Week:
            //            var weeksSinceStart = (date - firstDay).Days / 7;
            //            return weeksSinceStart % (shiftWork.RecurrenceCount * 2) < shiftWork.RecurrenceCount;
            //        case RecurrenceType.Month:
            //            return ((date.Year - firstDay.Year) * 12 + date.Month - firstDay.Month) % shiftWork.RecurrenceCount == 0;
            //        case RecurrenceType.Year:
            //            return (date.Year - firstDay.Year) % shiftWork.RecurrenceCount == 0;
            //        default:
            //            return true;
            //    }
            //}
            #endregion


            return true; 
        }





















        #region igore
        //public async Task<List<ShiftScheduleDto>> GetShiftsForPeriod(DateTime startDate, DateTime endDate, int employeeId)
        //{

        //    var employee = await _dbContext.Employees.FirstOrDefaultAsync(e => e.Id == employeeId);
        //    if (employee == null)
        //    {
        //        throw new EntityNotFoundException(nameof(Employee), $"Id={employeeId}");
        //    }

        //    var organizationId = employee.OrganizationId;

        //    var dates = Enumerable.Range(0, (endDate - startDate).Days + 1)
        //                             .Select(offset => startDate.AddDays(offset))
        //                             .ToList();

        //    var shifts = await _dbContext.ShiftWorks
        //                        .Where(sw => sw.OrganizationId == organizationId &&
        //                                     sw.StartDate <= endDate &&
        //                                     sw.EndDate >= startDate)
        //                        .Include(sw => sw.ShiftCatalog)
        //                        .ToListAsync();

        //    var shiftSchedules = dates.Select(date => new ShiftScheduleDto
        //    {
        //        Date = date,
        //        Shifts = shifts.Where(sw => (date >= sw.StartDate && date <= sw.EndDate) &&
        //                                    (date.DayOfWeek == DayOfWeek.Monday && sw.IsMonday == true ||
        //                                     date.DayOfWeek == DayOfWeek.Tuesday && sw.IsTuesday == true ||
        //                                     date.DayOfWeek == DayOfWeek.Wednesday && sw.IsWednesday == true ||
        //                                     date.DayOfWeek == DayOfWeek.Thursday && sw.IsThursday == true ||
        //                                     date.DayOfWeek == DayOfWeek.Friday && sw.IsFriday == true ||
        //                                     date.DayOfWeek == DayOfWeek.Saturday && sw.IsSaturday == true ||
        //                                     date.DayOfWeek == DayOfWeek.Sunday && sw.IsSunday == true))
        //                    .Select(sw => new ShiftCatalogScheduleDto
        //                    {
        //                        Id = sw.ShiftCatalog.Id,
        //                        Code = sw.ShiftCatalog.Code,
        //                        Name = sw.ShiftCatalog.Name,
        //                        StartTime = sw.ShiftCatalog.StartTime,
        //                        EndTime = sw.ShiftCatalog.EndTime
        //                    })
        //                    .ToList()
        //    }).ToList();

        //    return shiftSchedules;

        //}
        #endregion





    }
}