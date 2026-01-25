using HRM_BE.Core.Data.Profile;
using HRM_BE.Core.Models.Contract.Allowance;
using HRM_BE.Core.Models.Profile.ContractType;

namespace HRM_BE.Api.Mappers
{
    public class AllowanceMapper : AutoMapper.Profile
    {
        public AllowanceMapper()
        {
            CreateMap<CreateAllowanceDto, Allowance>();
            CreateMap<UpdateAllowanceDto, Allowance>();
            CreateMap<Allowance, AllowanceDto>().ReverseMap();
            CreateMap<Allowance, GetPagingAllowanceRequest>().ReverseMap();
        }
    }
}
