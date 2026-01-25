using HRM_BE.Core.Data.Profile;
using HRM_BE.Core.Models.Profile.ContractType;

namespace HRM_BE.Api.Mappers
{
    public class ContractTypeMapper : AutoMapper.Profile
    {
        public ContractTypeMapper()
        {
            CreateMap<CreateContractTypeDto, ContractType>();
            CreateMap<UpdateContractTypeDto, ContractType>();
            CreateMap<ContractType, ContractTypeDto>().ReverseMap();
            CreateMap<ContractType, GetPagingContractTypeRequest>().ReverseMap();
        }
    }
}
