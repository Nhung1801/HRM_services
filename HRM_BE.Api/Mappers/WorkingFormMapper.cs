using HRM_BE.Core.Data.Profile;
using HRM_BE.Core.Models.Profile.ContractType;
using HRM_BE.Core.Models.Profile.WorkingForm;

namespace HRM_BE.Api.Mappers
{
    public class WorkingFormMapper : AutoMapper.Profile
    {
        public WorkingFormMapper()
        {
            CreateMap<CreateWorkingFormDto, WorkingForm>();
            CreateMap<UpdateWorkingFormDto, WorkingForm>();
            CreateMap<WorkingForm, WorkingFormDto>().ReverseMap();
            CreateMap<WorkingForm, GetPagingWorkingFormRequest>().ReverseMap();
        }
    }
}
