using HRM_BE.Core.Data.Payroll_Timekeeping.LeaveRegulation;
using HRM_BE.Core.Data.Profile;
using HRM_BE.Core.Models.Contract.Allowance;
using HRM_BE.Core.Models.Payroll_Timekeeping.LeaveRegulation;

namespace HRM_BE.Api.Mappers
{
    public class HolidayMapper : AutoMapper.Profile
    {
        public HolidayMapper()
        {
            CreateMap<CreateHolidayRequest, Holiday>();
            CreateMap<UpdateHolidayRequest, Holiday>();
            CreateMap<Holiday, HolidayDto>().ReverseMap();
            CreateMap<Holiday, PagingHolidayRequest>().ReverseMap();
        }
    }
}
