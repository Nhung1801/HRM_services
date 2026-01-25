using HRM_BE.Core.Data.Payroll_Timekeeping.LeaveRegulation;
using HRM_BE.Core.Data.Payroll_Timekeeping.Payroll;
using HRM_BE.Core.Models.Payroll_Timekeeping.LeaveRegulation;
using HRM_BE.Core.Models.Payroll_Timekeeping.Payroll;

namespace HRM_BE.Api.Mappers
{
    public class SalaryComponentMapper : AutoMapper.Profile
    {
        public SalaryComponentMapper()
        {
            CreateMap<CreateSalaryComponentRequest, SalaryComponent>();
            CreateMap<UpdateSalaryComponentRequest, SalaryComponent>();
            CreateMap<SalaryComponent, SalaryComponentDto>().ReverseMap();
            CreateMap<SalaryComponent, PagingSalaryComponentRequest>().ReverseMap();
            CreateMap<SalaryComponent, SalaryComponentDto>()
                .ForMember(dest => dest.OrganizationName, opt => opt.MapFrom(src => src.Organization.OrganizationName));
        }
    }
}
