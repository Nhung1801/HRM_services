using HRM_BE.Core.Data.Identity;
using HRM_BE.Core.Models.Common;
using HRM_BE.Core.Models.Identity.Role;

namespace HRM_BE.Api.Services.Interfaces
{
    public interface IRoleService
    {
        Task<PagingResult<RoleDto>> GetPaging(GetRoleRequest request);

        Task<RoleDto> GetById(EntityIdentityRequest<int> request);

        Task<PagingResult<RoleDto>> GetByUser(GetRoleByUserRequest request);

        Task<List<RoleDto>> GetRoleByEmployeeAsync(int employeeId);

        Task<RoleDto> Create(CreateRoleRequest request);

        Task<RoleDto> Edit(EditRoleRequest request);

        Task<RoleDto> Delete(int id);

        Task<List<RoleDto>> DeleteMultiple(List<int?> ids);

        Task<List<User>> GetUsersInRoleByIdAsync(int roleId);


    }
}
