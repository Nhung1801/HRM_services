using HRM_BE.Core.Data.Payroll_Timekeeping.LeaveRegulation;
using HRM_BE.Core.Data.Payroll_Timekeeping.TimekeepingRegulation;
using HRM_BE.Core.Models.Payroll_Timekeeping.LeaveRegulation;
using HRM_BE.Core.Models.Payroll_Timekeeping.TimekeepingRegulation;

namespace HRM_BE.Api.Mappers
{
    public class TimekeepingRegulationMapper : AutoMapper.Profile
    {
        public TimekeepingRegulationMapper()
        {
            CreateMap<CreateTimeKeepingRegulationRequest, TimekeepingRegulation>();
            CreateMap<UpdateTimekeepingRegulationRequest, TimekeepingRegulation>();
            CreateMap<TimekeepingRegulation, TimekeepingRegulationDto>().ReverseMap();
            CreateMap<TimekeepingRegulation, PagingTypeOfLeaveRequest>().ReverseMap();
        }
    }
}
