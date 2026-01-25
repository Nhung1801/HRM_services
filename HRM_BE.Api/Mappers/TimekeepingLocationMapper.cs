using HRM_BE.Core.Data.Payroll_Timekeeping.LeaveRegulation;
using HRM_BE.Core.Data.Payroll_Timekeeping.TimekeepingRegulation;
using HRM_BE.Core.Models.Payroll_Timekeeping.LeaveRegulation;
using HRM_BE.Core.Models.Payroll_Timekeeping.TimekeepingRegulation;

namespace HRM_BE.Api.Mappers
{
    public class TimekeepingLocationMapper : AutoMapper.Profile
    {
        public TimekeepingLocationMapper()
        {
            CreateMap<CreateTimekeepingLocationRequest, TimekeepingLocation>();
            CreateMap<UpdateTimekeepingLocationRequest, TimekeepingLocation>();
            CreateMap<TimekeepingLocation, TimekeepingLocationDto>().ReverseMap();
            CreateMap<TimekeepingLocation, PagingTimekeepingLocationRequest>().ReverseMap();
        }
    }
}
