using HRM_BE.Core.Data.Profile;
using HRM_BE.Core.Models.Contract.NatureOfLabor;
using HRM_BE.Core.Models.Profile.ContractType;

namespace HRM_BE.Api.Mappers
{
    public class NatureOfLaborMapper : AutoMapper.Profile
    {
        public NatureOfLaborMapper()
        {
            CreateMap<CreateNatureOfLaborDto, NatureOfLabor>();
            CreateMap<UpdateNatureOfLaborDto, NatureOfLabor>();
            CreateMap<NatureOfLabor, NatureOfLaborDto>().ReverseMap();
            CreateMap<NatureOfLabor, GetPagingNatureOfLaborRequest>().ReverseMap();
        }
    }
}
