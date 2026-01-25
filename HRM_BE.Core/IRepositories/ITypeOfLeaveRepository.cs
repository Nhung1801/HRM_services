using HRM_BE.Core.Data.Payroll_Timekeeping.LeaveRegulation;
using HRM_BE.Core.ISeedWorks;
using HRM_BE.Core.Models.Common;
using HRM_BE.Core.Models.Payroll_Timekeeping.LeaveRegulation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HRM_BE.Core.IRepositories
{
    public interface ITypeOfLeaveRepository : IRepositoryBase<TypeOfLeave, int>
    {
        Task<PagingResult<TypeOfLeaveDto>> Paging(int? organizationId, string? sortBy, string? orderBy, int pageIndex = 1, int pageSize = 10);
        Task Update(int id, UpdateTypeOfLeaveRequest request);
        Task<TypeOfLeaveDto> Create(CreateTypeOfLeaveRequest request);
        Task<TypeOfLeaveDto> GetById(int id);
        Task Delete(int id);
    }
}
