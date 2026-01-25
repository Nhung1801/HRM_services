using AutoMapper;
using HRM_BE.Core.Data.Task;
using HRM_BE.Core.Models.Delegation;

namespace HRM_BE.Api.Mappers
{
    public class DelegationMapper:Profile
    {
       public DelegationMapper()
        {

            CreateMap<CreateDelegationRequest, Delegation>().ReverseMap();

            CreateMap<UpdateDelegationRequest, Delegation>().ReverseMap();

            //CreateMap<Delegation, DelegationDto>().ReverseMap();

            CreateMap<Delegation, DelegationDto>()
             .ForMember(dto => dto.Employees, opt => opt.MapFrom(src => src.DelegationEmployees.Select(de => de.Employee)))
             .ForMember(dto => dto.Projects, opt => opt.MapFrom(src => src.DelegationProjects.Select(dp => dp.Project)))
             .ReverseMap();
        }
    }
}
