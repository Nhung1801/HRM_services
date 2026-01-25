using AutoMapper;
using HRM_BE.Core.Data.Content;
using HRM_BE.Core.Data.Task;
using HRM_BE.Core.Models.Content.Banner;
using HRM_BE.Core.Models.Department;

namespace HRM_BE.Api.Mappers
{
    public class DepartmentMapper:Profile
    {
        public DepartmentMapper()
        {
            CreateMap<Department, DepartmentDto>().ReverseMap();
            CreateMap<DepartmentRole, DepartmentRoleDto>().ReverseMap();

            CreateMap<CreateDepartmentRequest, Department>()
            .ForMember(dest => dest.DepartmentEmployees, opt => opt.Ignore()).ReverseMap();

            CreateMap<UpdateDepartmentRequest, Department>()
                .ForMember(dest => dest.DepartmentEmployees, opt => opt.Ignore()).ReverseMap();

        }
    }
}
