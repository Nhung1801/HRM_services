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
    public interface IPayrollInquiryRepository : IRepositoryBase<PayrollInquiry, int>
    {
        Task<PagingResult<PayrollInquiryDto>> Paging(int? payrollDetailId, int? payrollId, string? sortBy, string? orderBy, int pageIndex = 1, int pageSize = 10);
        Task<PayrollInquiryDto> Create(CreatePayrollInquiryRequest request);
        Task<PayrollInquiryDto> GetById(int id);
        Task Delete(int id);

    }
}
