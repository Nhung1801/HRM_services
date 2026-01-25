using HRM_BE.Core.Data.Profile;
using HRM_BE.Core.Data.Staff;
using HRM_BE.Core.ISeedWorks;
using HRM_BE.Core.Models.Common;
using HRM_BE.Core.Models.Profile.ContractDuration;
using HRM_BE.Core.Models.Staff;


namespace HRM_BE.Core.IRepositories
{
    public interface IContractDurationRepository : IRepositoryBase<ContractDuration, int>
    {
        Task<PagingResult<ContractDurationDto>> Paging(string? keyWord, string? sortBy, string? orderBy, int pageIndex = 1, int pageSize = 10);     
        Task<ContractDurationDto> Create(CreateContractDurationDto request);
        Task Update(int id, UpdateContractDurationDto request);
        Task<ContractDurationDto> GetById(int id);
    }
}
