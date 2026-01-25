using HRM_BE.Core.Data.Payroll_Timekeeping.LeaveRegulation;
using HRM_BE.Core.Data.Payroll_Timekeeping.TimekeepingRegulation;
using HRM_BE.Core.Data.Profile;
using HRM_BE.Core.Models.Contract.NatureOfLabor;
using HRM_BE.Core.Models.Payroll_Timekeeping.LeaveRegulation;
using HRM_BE.Core.Models.Payroll_Timekeeping.TimekeepingRegulation;

namespace HRM_BE.Api.Mappers
{
    public class GeneralLeaveRegulationMapper : AutoMapper.Profile
    {
        public GeneralLeaveRegulationMapper()
        {
            CreateMap<CreateGeneralLeaveRegulationRequest, GeneralLeaveRegulation>();
            CreateMap<UpdateGeneralLeaveRegulationRequest, GeneralLeaveRegulation>();
            CreateMap<GeneralLeaveRegulation, GeneralLeaveRegulationDto>().ReverseMap();
            CreateMap<GeneralLeaveRegulation, PagingGeneralLeaveRegulationRequest>().ReverseMap();
        }
    }
}
