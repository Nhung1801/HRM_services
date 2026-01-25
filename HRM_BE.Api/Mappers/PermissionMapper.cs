using HRM_BE.Core.Data.Identity;
using HRM_BE.Core.Models.Identity.Permission;
using AutoMapper;

namespace HRM_BE.Api.Mappers
{
    public class PermissionMapper : Profile
    {
        public PermissionMapper()
        {

            CreateMap<Permission, PermissionDto>();
            CreateMap<PermissionDto, Permission>();
            CreateMap<CreatePermissionRequest, Permission>();

        }
    }
}
