using HRM_BE.Core.Data.Staff;
using HRM_BE.Core.ISeedWorks;
using HRM_BE.Core.Models.Common;
using HRM_BE.Core.Models.Profile;
using HRM_BE.Core.Models.Staff;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HRM_BE.Core.IRepositories
{
    public interface IProfileRepository : IRepositoryBase<Employee, int>
    {
        Task<PagingResult<EmployeeDto>> Paging(WorkingStatus? workingStatus, int? employeeId, int? organizationId, string? keyWord, string? sortBy, string? orderBy, int pageIndex = 1, int pageSize = 10);
        Task<List<EmployeeDto>> GetAll(WorkingStatus? workingStatus, int? employeeId, int? organizationId, string? sortBy, string? orderBy);
    }
}
