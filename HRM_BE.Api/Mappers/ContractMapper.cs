using HRM_BE.Core.Data.Profile;
using HRM_BE.Core.Data.Staff;
using HRM_BE.Core.Models.Company;
using HRM_BE.Core.Models.Contract;
using HRM_BE.Core.Models.Profile;
using HRM_BE.Core.Models.Profile.ContractType;

namespace HRM_BE.Api.Mappers
{
    public class ContractMapper : AutoMapper.Profile
    {
        public ContractMapper()
        {
            CreateMap<CreateContractRequest, Contract>();
            CreateMap<UpdateContractRequest, Contract>();
            CreateMap<UpdateContractExpiredStatusRequest,Contract>();
            CreateMap<Contract, ContractDTO>()
                .ForMember(dest => dest.TotalAllowance, opt => opt.MapFrom( src => src.Allowances.Sum( a => a.Value)));
            CreateMap<Contract, GetContractPagingRequest>().ReverseMap();
            CreateMap<Employee,GetContractEmployeeDto>();
        }
    }
}
