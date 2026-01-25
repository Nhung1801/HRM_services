using HRM_BE.Core.Data.Profile;
using HRM_BE.Core.ISeedWorks;
using HRM_BE.Core.Models.Common;
using HRM_BE.Core.Models.Profile.ContractDuration;
using HRM_BE.Core.Models.Profile.ContractType;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HRM_BE.Core.IRepositories
{
    public interface IContractTypeRepository: IRepositoryBase<ContractType, int>
    {
        Task<PagingResult<ContractTypeDto>> Paging(string? keyWord, string? sortBy, string? orderBy, int pageIndex = 1, int pageSize = 10);
        Task<ContractTypeDto> Create(CreateContractTypeDto request);
        Task Update(int id, UpdateContractTypeDto request);
        Task<ContractTypeDto> GetById(int id);
    }
}
