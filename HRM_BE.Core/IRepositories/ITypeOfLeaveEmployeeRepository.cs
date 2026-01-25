using HRM_BE.Core.Models.Payroll_Timekeeping.LeaveRegulation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HRM_BE.Core.IRepositories
{
    public interface ITypeOfLeaveEmployeeRepository
    {
        Task<TypeOfLeaveEmployeeDto> GetOrCreate(int? employeeId, int? typeOfLeaveId, int? year);
        Task<bool> UpdateDaysRemaining(double daysRemaining, int employeeId, int typeOfLeaveId, int year);
        Task<bool> CheckDaysRemaining(double daysRemaining, int employeeId, int typeOfLeaveId, int year);


    }
}
