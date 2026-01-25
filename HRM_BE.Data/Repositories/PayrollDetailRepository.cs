using AutoMapper;
using HRM_BE.Core.Data.Payroll_Timekeeping.Payroll;
using HRM_BE.Core.Data.Profile;
using HRM_BE.Core.Exceptions;
using HRM_BE.Core.Extension;
using HRM_BE.Core.IRepositories;
using HRM_BE.Core.Models.Common;
using HRM_BE.Core.Models.Payroll_Timekeeping.Payroll;
using HRM_BE.Data.SeedWorks;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HRM_BE.Data.Repositories
{
    public class PayrollDetailRepository : RepositoryBase<PayrollDetail, int>, IPayrollDetailRepository
    {
        private readonly IMapper _mapper;

        public PayrollDetailRepository(HrmContext context, IMapper mapper, IHttpContextAccessor httpContextAccessor) : base(context, httpContextAccessor)
        {
            _mapper = mapper;
        }

        public async Task<PayrollDetailDto> GetById(int id)
        {
            var entity = await GetPayrollDetailAndCheckExist(id);
            return _mapper.Map<PayrollDetailDto>(entity);
        }

        public async Task<PagingResult<PayrollDetailDto>> Paging(int? organizationId, string? name, int? payrollId, int? employeeId, string? sortBy, string? orderBy, int pageIndex = 1, int pageSize = 10)
        {
            var query = _dbContext.PayrollDetails.Where(p => p.IsDeleted != true).AsQueryable();

            if (payrollId.HasValue)
            {

                query = query.Where(p => p.PayrollId == payrollId);
            }

            if (employeeId.HasValue)
            {
                query = query.Where(p => p.EmployeeId == employeeId);
            }

            if (organizationId.HasValue)
            {
                query = query.Where(p => p.OrganizationId == organizationId);
            }

            if (!string.IsNullOrEmpty(name))
            {
                query = query.Where(p => p.FullName.Contains(name));
            }

            // Áp dụng sắp xếp
            query = query.ApplySorting(sortBy, orderBy);
            // Tính tổng số bản ghi
            int total = await query.CountAsync();
            // Áp dụng phân trang
            query = query.ApplyPaging(pageIndex, pageSize);

            var data = await _mapper.ProjectTo<PayrollDetailDto>(query).ToListAsync();

            var result = new PagingResult<PayrollDetailDto>(data, pageIndex, pageSize, sortBy, orderBy, total);

            return result;
        }


        private async Task<PayrollDetail> GetPayrollDetailAndCheckExist(int payrollDetailId)
        {
            var payrollDetail = await _dbContext.PayrollDetails.FindAsync(payrollDetailId);
            if (payrollDetail is null)
                throw new EntityNotFoundException(nameof(PayrollDetail), $"Id = {payrollDetailId}");
            return payrollDetail;
        }

        public async Task CalculateAndSavePayrollDetails(int payrollId)
        {
            // Lấy Payroll
            var payroll = _dbContext.Payrolls.FirstOrDefault(p => p.Id == payrollId);
            if (payroll == null)
            {
                throw new Exception($"Payroll có Id = {payrollId} không tồn tại!");
            }

            // 1. Lấy danh sách nhân viên thuộc tổ chức của Payroll
            var employees = _dbContext.Employees
                .Where(e => e.OrganizationId == payroll.OrganizationId)
                .Where(e => e.Contracts.Any(c => c.EmployeeId == e.Id))
                .ToList();

            var standardWorkDays = _dbContext.ShiftWorks
                .Where(sw => sw.OrganizationId == payroll.OrganizationId)
                .Sum(sw => sw.TotalWork);

            var payrollDetails = new List<PayrollDetail>();

            foreach (var employee in employees)
            {
                var contract = _dbContext.Contracts.FirstOrDefault(c => c.EmployeeId == employee.Id);
                var timesheet = _dbContext.Timesheets.Where(t => t.EmployeeId == employee.Id);

                // Lấy bảng KpiDetail theo tháng hiện tại
                var kpiDetail = _dbContext.KpiTableDetails.Include(k => k.KpiTable)
                    .FirstOrDefault(k =>
                        k.EmployeeId == employee.Id &&
                        k.KpiTable != null &&
                        k.KpiTable.ToDate.HasValue &&
                        k.KpiTable.ToDate.Value.Month == payroll.CreatedAt.Value.Month &&
                        k.KpiTable.ToDate.Value.Year == payroll.CreatedAt.Value.Year);

                // Lấy các khoản khấu trừ
                var deductions = _dbContext.Deductions.Where(d => d.EmployeeId == employee.Id).ToList();
                var totalDeductions = deductions.Sum(d => d.Value); // Tổng khấu trừ

                // 2. Tính toán các thành phần lương
                var baseSalary = contract?.SalaryAmount ?? 0;
                var actualWorkDays = timesheet
                    .Where(t => t.Date.HasValue && t.Date.Value.Month == payroll.CreatedAt.Value.Month && t.Date.Value.Year == payroll.CreatedAt.Value.Year)
                    .Select(t => t.Date.Value.Date)
                    .Distinct()
                    .Count();

                var receivedSalary = standardWorkDays > 0 ? (baseSalary / (decimal)standardWorkDays) * (decimal)actualWorkDays : 0;
                var kpi = contract?.KpiSalary ?? 0;
                var kpiPercentage = kpiDetail?.CompletionRate ?? 0;
                var kpiSalary = (decimal)kpi * ((decimal)kpiPercentage / 100);
                var bonus = kpiDetail?.Bonus ?? 0;
                var salaryRate = contract?.SalaryRate ?? 1;
                var totalSalary = ((decimal)receivedSalary + (decimal)kpiSalary + (decimal)bonus) * ((decimal)salaryRate / 100);
                var totalReceivedSalary = totalSalary - totalDeductions;

                // 3. Lưu vào bảng PayrollDetail
                payrollDetails.Add(new PayrollDetail
                {
                    OrganizationId = employee.OrganizationId,
                    PayrollId = payrollId,
                    EmployeeId = employee.Id,
                    ContractId = contract?.Id,
                    EmployeeCode = employee.EmployeeCode,
                    FullName = employee.LastName + " " + employee.FirstName,
                    ContractTypeStatus = contract?.ContractTypeStatus ?? ContractTypeStatus.Official,
                    BaseSalary = baseSalary,
                    StandardWorkDays = standardWorkDays,
                    ActualWorkDays = actualWorkDays,
                    ReceivedSalary = receivedSalary,
                    KPI = (decimal)kpi,
                    KpiPercentage = (decimal)kpiPercentage,
                    KpiSalary = (decimal)kpiSalary,
                    Bonus = (decimal)bonus,

                    SalaryRate = (decimal)salaryRate,
                    TotalSalary = (decimal)totalSalary,
                    TotalReceivedSalary = (decimal)totalReceivedSalary,
                    ConfirmationStatus = PayrollConfirmationStatusEmployee.NotSent
                });

            }

            await CreateRangeAsync(payrollDetails);
        }

        public async Task<List<PayrollDetailDto>> FetchPayrollDetails(int payrollId)
        {
            try
            {
                var payroll = await _dbContext.Payrolls
                    .FirstOrDefaultAsync(p => p.Id == payrollId && p.IsDeleted != true);

                if (payroll == null)
                {
                    throw new EntityNotFoundException(nameof(Payroll), $"Id = {payrollId}");
                }

                // 1. Kiểm tra nếu bảng lương chi tiết đã tồn tại
                var existingDetails = await _dbContext.PayrollDetails
                    .Where(pd => pd.PayrollId == payrollId && pd.IsDeleted != true)
                    .ToListAsync();

                if (existingDetails.Any())
                {
                    return _mapper.Map<List<PayrollDetailDto>>(existingDetails);
                }

                // 2. Nếu chưa tồn tại, tính toán và lưu bảng lương chi tiết
                await CalculateAndSavePayrollDetails(payrollId);

                // 3. Lấy lại danh sách bảng lương chi tiết vừa tạo
                var newDetails = await _dbContext.PayrollDetails
                    .Where(pd => pd.PayrollId == payrollId && pd.IsDeleted != true)
                    .ToListAsync();

                return _mapper.Map<List<PayrollDetailDto>>(newDetails);
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }
        }

        // Quản lý gửi bảng lương cho nhân viên xem
        public async Task SendPayrollDetailConfirmation(UpdateSendPayrollDetailConfirmationRequest request)
        {
            if (request.PayrollDetailIds == null || !request.PayrollDetailIds.Any())
            {
                throw new Exception($"Chọn ít nhất 1 bảng lương chi tiết để gửi");
            }

            var payrollDetails = await _dbContext.PayrollDetails
                .Where(p => request.PayrollDetailIds.Contains(p.Id))
                .ToListAsync();

            foreach (var payrollDetail in payrollDetails)
            {
                if (payrollDetail == null)
                {
                    throw new Exception($"Không tìm thấy bảng lương chi tiết");
                }

                payrollDetail.ConfirmationStatus = PayrollConfirmationStatusEmployee.Confirming;
                payrollDetail.ResponseDeadline = request.ResponseDeadline;

            }

            await UpdateRangeAsync(payrollDetails);
        }

        // Nhân viên xác nhận bảng lương
        public async Task ConfirmPayrollDetailByEmployee(int payrollDetailId)
        {
            // Kiểm tra nếu ID không hợp lệ
            if (payrollDetailId <= 0)
            {
                throw new ArgumentException("PayrollDetailId không hợp lệ.");
            }

            var payrollDetail = await _dbContext.PayrollDetails
                .FirstOrDefaultAsync(p => p.Id == payrollDetailId && p.IsDeleted != true);

            if (payrollDetail == null)
            {
                throw new EntityNotFoundException(nameof(PayrollDetail), $"Không tìm thấy bảng lương chi tiết với Id = {payrollDetailId}");
            }

            payrollDetail.ConfirmationStatus = PayrollConfirmationStatusEmployee.Confirmed;
            payrollDetail.ConfirmationDate = DateTime.Now;

            await UpdateAsync(payrollDetail);

        }

    }
}
