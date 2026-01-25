using HRM_BE.Core.Data.Payroll_Timekeeping.LeaveRegulation;
using HRM_BE.Core.Models.Payroll_Timekeeping.LeaveRegulation;

namespace HRM_BE.Api.Mappers
{
    public class WorkFactorMapper : AutoMapper.Profile
    {
        public WorkFactorMapper()
        {
            CreateMap<WorkFactor, WorkFactorDto>();
            CreateMap<WorkFactorDto, WorkFactor>();
            CreateMap<SaveWorkFactorRequest, WorkFactor>();
        }
    }
}
