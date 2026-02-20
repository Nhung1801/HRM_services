using HRM_BE.Core.Models.Common;
using HRM_BE.Core.Models.Identity.Permission;

namespace HRM_BE.Api.Services.Interfaces
{
    public interface IPermissionService
    {
        Task<PagingResult<PermissionDto>> GetPaging(GetPermissionRequest request);

        Task<List<PermissionDto>> GetByRoleId(int roleId);

        Task<PermissionDto> Create(CreatePermissionRequest request);

        Task Update(int id, UpdatePermissionRequest request);

        Task Delete(int id);

    }
}
