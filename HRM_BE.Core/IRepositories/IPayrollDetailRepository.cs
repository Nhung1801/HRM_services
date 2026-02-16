using HRM_BE.Core.Data.Payroll_Timekeeping.Payroll;
using HRM_BE.Core.ISeedWorks;
using HRM_BE.Core.Models.Common;
using HRM_BE.Core.Models.Payroll_Timekeeping.Payroll;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HRM_BE.Core.IRepositories
{
    public interface IPayrollDetailRepository : IRepositoryBase<PayrollDetail, int>
    {
        Task<PagingResult<PayrollDetailDto>> Paging(int? organizationId, string? name, int? payrollId, int? employeeId, string? sortBy, string? orderBy, int pageIndex = 1, int pageSize = 10);
        Task<PayrollDetailDto> GetById(int id);
        Task CalculateAndSavePayrollDetails(int payrollId);
        Task RecalculateAndSavePayrollDetails(int payrollId);
        Task<List<PayrollDetailDto>> FetchPayrollDetails(int payrollId);
        Task SendPayrollDetailConfirmation(UpdateSendPayrollDetailConfirmationRequest request);
        Task ConfirmPayrollDetailByEmployee(int payrollDetailId);
    }
}
