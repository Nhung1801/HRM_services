using AutoMapper;
using Hangfire;
using HRM_BE.Core.Data.Official_Form;
using HRM_BE.Core.Data.Payroll_Timekeeping.LeaveRegulation;
using HRM_BE.Core.Data.Payroll_Timekeeping.TimekeepingRegulation;
using HRM_BE.Core.Data.Staff;
using HRM_BE.Core.Exceptions;
using HRM_BE.Core.IRepositories;
using HRM_BE.Core.ISeedWorks;
using HRM_BE.Data.SeedWorks;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace HRM_BE.Data.Repositories
{
    public class LeavePermissionRepository : RepositoryBase<LeavePermission, int>, ILeavePermissionRepository
    {
        private readonly IMapper _mapper;
        public LeavePermissionRepository(HrmContext context, IMapper mapper, IHttpContextAccessor httpContextAccessor) : base(context, httpContextAccessor)
        {
            _mapper = mapper;
        }

        public async Task TriggerCreateLeavePermission(int employeeId, int contractId, int numberOfLeave, DateTime start, DateTime end)
        {
            var employee = await _dbContext.Employees.FindAsync(employeeId);
            var generalLeaveRegulation = await _dbContext.GeneralLeaveRegulations.Where(s => s.OrganizationId == employee.OrganizationId).FirstOrDefaultAsync();

            if (generalLeaveRegulation is null)
            {
                throw new EntityNotFoundException("Chưa có quy định nghỉ phép chung cho tổ chức");
            }

            // cài 
            var monthsAndYears = Enumerable.Range(0, 1 + ((end.Year - start.Year) * 12 + end.Month - start.Month))
            .Select(offset => new
            {
                Year = start.AddMonths(offset).Year,
                Month = start.AddMonths(offset).Month
            })
            .ToList();

            // Loại bỏ số tháng đầu tiên dựa trên SeniorityMonths
            for (int i = 0; i < generalLeaveRegulation.SeniorityMonths; i++)
            {
                if (monthsAndYears.Any())
                {
                    monthsAndYears.RemoveAt(0); // Xóa phần tử đầu tiên
                }
            }

            var listLeavePermissions = new List<LeavePermission>();
            foreach (var monthYear in monthsAndYears)
            {
                var permission = new LeavePermission
                {
                    EmployeeId = employeeId,
                    ContractId = contractId,
                    Date = new DateTime(monthYear.Year, monthYear.Month, generalLeaveRegulation.AdmissionDay.Value),
                    LeavePerrmissionStatus = LeavePerrmissionStatus.Active,
                    NumerOfLeave = 1
                };
                listLeavePermissions.Add(permission);
            }
            await CreateRangeAsync(listLeavePermissions);
        }

        public async Task TriggerUpdateNumberLeavePermission(int employeeId, double numberOfLeave, DateTime startDate, DateTime endDate)
        {
            throw new NotImplementedException();
        }
        private int CountDays(DateTime startDate, DateTime endDate)
        {
            if (endDate < startDate)
                throw new ArgumentException("End date must be greater than or equal to start date.");

            return (endDate - startDate).Days + 1; // Thêm 1 để tính cả ngày bắt đầu
        }
        private int GetDaysInMonth(DateTime startDate, DateTime endDate, int year, int month)
        {
            var startOfMonth = new DateTime(year, month, 1);
            var endOfMonth = startOfMonth.AddMonths(1).AddDays(-1);

            var effectiveStartDate = startDate > startOfMonth ? startDate : startOfMonth;
            var effectiveEndDate = endDate < endOfMonth ? endDate : endOfMonth;

            return (effectiveEndDate - effectiveStartDate).Days + 1;
        }
        private List<(int Year, int Month)> GenerateMonths(DateTime startDate, DateTime endDate, int step = 1)
        {
            var months = new List<(int Year, int Month)>();

            // Khởi tạo biến giữ giá trị ngày hiện tại
            var currentDate = new DateTime(startDate.Year, startDate.Month, 1);

            // Lặp qua các tháng
            while (currentDate <= endDate)
            {
                // Thêm tháng và năm hiện tại vào danh sách
                months.Add((currentDate.Year, currentDate.Month));

                // Tăng giá trị tháng lên theo step
                currentDate = currentDate.AddMonths(step);
            }

            return months;
        }




        public  async Task<double> CountDayOff(int employeeId)
        {
            var count= await _dbContext.LeavePermissions.Where(x=>x.EmployeeId == employeeId).Select(e=>e.NumerOfLeave).FirstOrDefaultAsync();
            return count;
        }
    }
}
