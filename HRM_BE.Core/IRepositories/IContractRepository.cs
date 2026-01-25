using HRM_BE.Core.Data.Profile;
using HRM_BE.Core.Data.Staff;
using HRM_BE.Core.ISeedWorks;
using HRM_BE.Core.Models.Common;
using HRM_BE.Core.Models.Contract;
using HRM_BE.Core.Models.Profile;
using HRM_BE.Core.Models.Profile.ContractDuration;
using HRM_BE.Core.Models.Staff;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HRM_BE.Core.IRepositories
{
    public interface IContractRepository : IRepositoryBase<Contract, int>
    {
        Task<PagingResult<ContractDTO>> Paging(string? nameEmployee,string? unit,int? unitId, bool? expiredStatus, string? sortBy, string? orderBy, int pageIndex = 1, int pageSize = 10);
        Task<ContractDTO> Create(CreateContractRequest request);
        Task Update(int id, UpdateContractRequest request);
        Task Delete(int id);
        Task DeleteRange( ListEntityIdentityRequest<int> ids );
        Task UpdateExpiredStatus(int id, UpdateContractExpiredStatusRequest request);

        Task<ContractDTO> GetById(int id);
        Task<bool> CheckEmployeeHaveContractValid(int employeeId);


    }
}
