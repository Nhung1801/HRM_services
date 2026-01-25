using HRM_BE.Core.Data.Staff;
using HRM_BE.Core.ISeedWorks;
using HRM_BE.Core.Models.Common;
using HRM_BE.Core.Models.Staff;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HRM_BE.Core.IRepositories
{
    public interface IEmployeeRepository : IRepositoryBase<Employee, int>
    {
        Task<PagingResult<EmployeeDto>> Paging(string? keyWord,int? organizationId, int? leaderOrganizationId, int? positionId, WorkingStatus? workingStatus,AccountStatus? accountStatus, int? cityId, int? districtId, int? wardId, int? streetId,string? sortBy,string? orderBy,int pageIndex = 1,int pageSize = 10);
        Task<EmployeeDto> Create(CreateEmployeeRequest request);
        Task Update(int id, UpdateEmployeeRequest request);
        Task Delete(int id);
        Task<EmployeeDto> GetById(int id);
        Task UpdateAccountStatus(int employeeId, UpdateAccountStatusRequest request);
        Task UpdateRangeAccountStatus(List<int> ids, AccountStatus accountStatus);
        Task<(UpdateEmployeeRequest employeePath, Employee employeeEntity)> GetEmployeeForPatch(int id);
        Task SaveChangesForPatch(UpdateEmployeeRequest emlpoyeePatch, Employee employeeEntity);
        Task DeleteRange(ListEntityIdentityRequest<int> request);

        Task<GetEmployeeProfileDto> GetProfileInfoByEmployeeId(int employeeId);
        
    }
}