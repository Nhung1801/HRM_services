using AutoMapper;
using HRM_BE.Core.Data.Profile;
using HRM_BE.Core.Models.Profile.ContractDuration;


namespace HRM_BE.Api.Mappers
{
    public class ContractDurationMapper : AutoMapper.Profile
    {
        public ContractDurationMapper()
        {
            CreateMap<CreateContractDurationDto, ContractDuration>();
            CreateMap<UpdateContractDurationDto, ContractDuration>();
            CreateMap<ContractDuration, ContractDurationDto>().ReverseMap();
            CreateMap<ContractDuration, GetContractDurationDto>().ReverseMap();
        }
    }
}
