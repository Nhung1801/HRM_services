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
    public interface ISalaryComponentRepository : IRepositoryBase<SalaryComponent, int>
    {
        Task<PagingResult<SalaryComponentDto>> Paging(string? name, Status? status, int? organizationId, string? sortBy, string? orderBy, int pageIndex = 1, int pageSize = 10);
        Task<List<SalaryComponentDto>> Create(List<CreateSalaryComponentRequest> requests);
        Task Update(int id, UpdateSalaryComponentRequest request);
        Task<SalaryComponentDto> GetById(int id);
        Task Delete(int id);
        Task<List<SalaryComponentDto>> GetDefaultSalaryComponents();
        Task<List<SalaryComponent>> GetByOrganizationId(int organizationId);
        Task<bool> IsFixedCharacteristic(int id);
    }
}
