using HRM_BE.Core.Data.Payroll_Timekeeping.TimekeepingRegulation;
using HRM_BE.Core.Models.Payroll_Timekeeping.TimekeepingRegulation;

namespace HRM_BE.Api.Mappers
{
    public class TimekeepingSettingMapper : AutoMapper.Profile
    {
        public TimekeepingSettingMapper()
        {
            CreateMap<CreateTimekeepingSettingRequest, TimekeepingSetting>();
            CreateMap<TimekeepingSetting, TimekeepingSettingDto>().ReverseMap();
            CreateMap<TimekeepingSetting, PagingTimekeepingSettingRequest>().ReverseMap();
        }
    }
}
