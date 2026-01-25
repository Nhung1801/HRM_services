using HRM_BE.Core.Data.Payroll_Timekeeping.LeaveRegulation;
using HRM_BE.Core.Data.Payroll_Timekeeping.TimekeepingRegulation;
using HRM_BE.Core.Models.Payroll_Timekeeping.LeaveRegulation;
using HRM_BE.Core.Models.Payroll_Timekeeping.TimekeepingRegulation;

namespace HRM_BE.Api.Mappers
{
    public class ApplyOrganizationMapper : AutoMapper.Profile
    {
        public ApplyOrganizationMapper()
        {
            CreateMap<CreateApplyOrganizationRequest, ApplyOrganization>();
            CreateMap<UpdateApplyOrganizationRequest, ApplyOrganization>();
            CreateMap<ApplyOrganization, ApplyOrganizationDto>().ReverseMap();
            CreateMap<ApplyOrganization, PagingApplyOrganizationRequest>().ReverseMap();
        }
    }
}
