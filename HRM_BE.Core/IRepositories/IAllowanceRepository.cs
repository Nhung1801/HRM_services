using HRM_BE.Core.Data.Profile;
using HRM_BE.Core.ISeedWorks;
using HRM_BE.Core.Models.Common;
using HRM_BE.Core.Models.Contract.Allowance;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HRM_BE.Core.IRepositories
{
    public interface IAllowanceRepository : IRepositoryBase<Allowance, int>
    {
        Task<PagingResult<AllowanceDto>> Paging(string? keyWord, string? sortBy, string? orderBy, int pageIndex = 1, int pageSize = 10);
        Task<AllowanceDto> Create(CreateAllowanceDto request);
        Task Update(int id, UpdateAllowanceDto request);
        Task<AllowanceDto> GetById(int id);
        Task<List<AllowanceDto>> GetByContractId(int id); 
    }
}
