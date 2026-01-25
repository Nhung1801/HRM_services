using HRM_BE.Core.Data.Payroll_Timekeeping.Payroll;
using HRM_BE.Core.Models.Payroll_Timekeeping.Payroll;

namespace HRM_BE.Api.Mappers
{
    public class PayrollMapper : AutoMapper.Profile
    {
        public PayrollMapper()
        {
            CreateMap<CreatePayrollRequest, Payroll>();
            CreateMap<UpdatePayrollRequest, Payroll>();
            CreateMap<Payroll, PayrollDto>().ReverseMap();
            CreateMap<Payroll, PagingPayrollRequest>().ReverseMap();
            CreateMap<PayrollSummaryTimesheet, PayrollSummaryTimesheetDto>().ReverseMap();
            CreateMap<PayrollStaffPosition, PayrollStaffPositionDto>().ReverseMap();
            CreateMap<Payroll, PayrollDto>()
                .ForMember(dest => dest.OrganizationName, opt => opt.MapFrom(src => src.Organization.OrganizationName));
            CreateMap<PayrollSummaryTimesheet, PayrollSummaryTimesheetDto>()
                .ForMember(dest => dest.SummaryTimesheetName, opt => opt.MapFrom(src => src.SummaryTimesheetName.TimekeepingSheetName));
            CreateMap<PayrollStaffPosition, PayrollStaffPositionDto>()
                .ForMember(dest => dest.PositionName, opt => opt.MapFrom(src => src.StaffPosition.PositionName));
        }
    }
}
