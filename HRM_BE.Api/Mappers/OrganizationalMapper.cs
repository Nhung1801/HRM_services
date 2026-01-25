using AutoMapper;
using HRM_BE.Core.Data.Company;
using HRM_BE.Core.Data.Staff;
using HRM_BE.Core.Models.Identity.User;
using HRM_BE.Core.Models.Official_Form.LeaveApplication;
using HRM_BE.Core.Models.Organization;
using System.ComponentModel.Design;

namespace HRM_BE.Api.Mappers
{
    public class OrganizationalMapper:Profile
    {
        public OrganizationalMapper()
        {
            CreateMap<Organization, OrganizationDto>()
                            .ForMember(dest => dest.OrganizationChildren, opt => opt.MapFrom(src => src.OrganizationChildren));
            CreateMap<Organization, OrganizationSelectDto>()
                .ForMember(dest => dest.CompanyId, opt => opt.MapFrom(src => src.CompanyId));

            CreateMap<OrganizationDto,OrganizationSelectDto>().ReverseMap();
            CreateMap<Organization,GetOrganizationDto>().ReverseMap();
            CreateMap<OrganizationDto,GetOrganizationDto>().ReverseMap();
            CreateMap<GetOrganizationDto, OrganizationSelectDto>().ReverseMap();
            CreateMap<Organization,OrganizationLeaderDto>();
            CreateMap<CreateOrganizationRequest, Organization>().
                ForMember(dest => dest.OrganizationLeaders, opt => opt.Ignore());
            CreateMap<UpdateOrganizationRequest, Organization>().
                ForMember(dest => dest.OrganizationLeaders, opt => opt.Ignore());

            CreateMap<Employee, GetOrganizationEmployeeDto>();

            CreateMap<UpdateOrganizationTypeRequest, Organization>();
            CreateMap<OrganizationType, OrganizationTypeDto>().ReverseMap();
            CreateMap<CreateOrganizationTypeRequest, OrganizationType>().ReverseMap();

            CreateMap<Organization, ContractOrganizationDto>().ReverseMap();

            CreateMap<Organization, UserOrganizationDto>().ReverseMap();
            CreateMap<Organization, LeaveApplicationEmployeeOrganizationDto>().ReverseMap();


        }
    }
}
