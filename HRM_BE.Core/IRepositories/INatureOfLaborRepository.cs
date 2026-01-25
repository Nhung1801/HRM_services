using HRM_BE.Core.Data.Profile;
using HRM_BE.Core.ISeedWorks;
using HRM_BE.Core.Models.Common;
using HRM_BE.Core.Models.Contract.NatureOfLabor;
using HRM_BE.Core.Models.Profile.ContractType;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HRM_BE.Core.IRepositories
{
    public interface INatureOfLaborRepository : IRepositoryBase<NatureOfLabor, int>
    {
        Task<PagingResult<NatureOfLaborDto>> Paging(string? keyWord, string? sortBy, string? orderBy, int pageIndex = 1, int pageSize = 10);
        Task<NatureOfLaborDto> Create(CreateNatureOfLaborDto request);
        Task Update(int id, UpdateNatureOfLaborDto request);
        Task<NatureOfLaborDto> GetById(int id);
    }
}
