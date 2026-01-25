using HRM_BE.Core.Data.Payroll_Timekeeping.Payroll;
using HRM_BE.Core.Models.Payroll_Timekeeping.Payroll;

namespace HRM_BE.Api.Mappers
{
    public class PayrollInquiryMapper : AutoMapper.Profile
    {
        public PayrollInquiryMapper()
        {
            CreateMap<PayrollInquiry, PayrollInquiryDto>().ReverseMap();
            CreateMap<CreatePayrollInquiryRequest, PayrollInquiry>().ReverseMap();
            CreateMap<PayrollInquiry, PayrollInquiryDto>()
                .ForMember(dest => dest.EmployeeName, opt => opt.MapFrom(src => src.PayrollDetail.FullName))
                .ForMember(dest => dest.TimeSent, opt => opt.MapFrom(src => src.CreatedAt))
                .ForMember(dest => dest.EmployeeId, opt => opt.MapFrom(src => src.PayrollDetail.EmployeeId));
        }
    }
}
