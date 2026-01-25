using AutoMapper;
using HRM_BE.Core.Data.Company;
using HRM_BE.Core.Data.Profile;
using HRM_BE.Core.Data.Staff;
using HRM_BE.Core.Models.Delegation;
using HRM_BE.Core.Models.Identity.User;
using HRM_BE.Core.Models.Official_Form.LeaveApplication;
using HRM_BE.Core.Models.Organization;
using HRM_BE.Core.Models.Staff;

namespace HRM_BE.Api.Mappers
{
    public class EmployeeMapper:Profile
    {
        public EmployeeMapper()
        {
            CreateMap<CreateEmployeeRequest, Employee>();
            CreateMap<UpdateEmployeeRequest, Employee>().ReverseMap();
            CreateMap<Employee, EmployeeDto>().ReverseMap();
            CreateMap<Employee,GetManagerDto>().ReverseMap();
            CreateMap<Employee, GetOrganizationLeaderDto>().ReverseMap();
            CreateMap<Employee, UserEmployeeDto>().ReverseMap();
            CreateMap<OrganizationLeader, GetEmployeeOrganizationDto>()
                .ForMember(dest => dest.OrganizationId, opt => opt.MapFrom(src => src.OrganizationId))
                .ForMember(dest => dest.OrganizationName , opt => opt.MapFrom(src => src.Organization.OrganizationName));

            CreateMap<GetEmployeeContractDto, Contract>().ReverseMap();
            CreateMap<Allowance,GetAllowanceEmployeeDto>().ReverseMap();
            CreateMap<Employee, GetEmployeeProfileDto>().ReverseMap();
            CreateMap<Organization, GetOrganizationForEmployeeDto>();
            CreateMap<Employee, LeaveApplicationEmployeeDto>().ReverseMap();
            CreateMap<Employee, EmployeeDelegationDto>().ReverseMap();

        }
    }
}
