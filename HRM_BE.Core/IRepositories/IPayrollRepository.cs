using HRM_BE.Core.Data.Payroll_Timekeeping.Payroll;
using HRM_BE.Core.ISeedWorks;
using HRM_BE.Core.Models.Common;
using HRM_BE.Core.Models.Payroll_Timekeeping.LeaveRegulation;
using HRM_BE.Core.Models.Payroll_Timekeeping.Payroll;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HRM_BE.Core.IRepositories
{
    public interface IPayrollRepository : IRepositoryBase<Payroll, int>
    {
        Task<PagingResult<PayrollDto>> Paging(int? organizationId, string? name, string? sortBy, string? orderBy, int pageIndex = 1, int pageSize = 10);
        Task<PayrollDto> Create(CreatePayrollRequest request);
        Task Update(int id, UpdatePayrollRequest request);
        Task<PayrollDto> GetById(int id);
        Task Delete(int id);
        Task TogglePayrollStatus(int payrollId);
        Task<bool> IsPayrollLocked(int payrollId);
        Task<PagingResult<PayrollDto>> PagingForEmployee(int? organizationId, string? name, int? employeeId, int? Year, string? sortBy, string? orderBy, int pageIndex = 1, int pageSize = 10);
    }
}
