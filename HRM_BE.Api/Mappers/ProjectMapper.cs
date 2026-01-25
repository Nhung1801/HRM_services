using AutoMapper;
using HRM_BE.Core.Data.Content;
using HRM_BE.Core.Data.Task;
using HRM_BE.Core.Models.Content.Banner;
using HRM_BE.Core.Models.Department;
using HRM_BE.Core.Models.Project;

namespace HRM_BE.Api.Mappers
{
    public class ProjectMapper:Profile
    {
        public ProjectMapper()
        {
            CreateMap<Project, ProjectDto>().ReverseMap();

            CreateMap<Project, ProjectDepartmentDto>().ReverseMap();

            CreateMap<ProjectRole, ProjectRoleDto>().ReverseMap();

            CreateMap<CreateProjectRequest, Project>()
            .ForMember(dest => dest.ProjectEmployees, opt => opt.Ignore()).ReverseMap();

            CreateMap<UpdateProjectRequest, Project>()
                .ForMember(dest => dest.ProjectEmployees, opt => opt.Ignore()).ReverseMap();

        }
    }
}
