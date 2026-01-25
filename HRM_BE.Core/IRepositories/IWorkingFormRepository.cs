using HRM_BE.Core.Data.Profile;
using HRM_BE.Core.ISeedWorks;
using HRM_BE.Core.Models.Common;
using HRM_BE.Core.Models.Profile.ContractType;
using HRM_BE.Core.Models.Profile.WorkingForm;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HRM_BE.Core.IRepositories
{
    public interface IWorkingFormRepository : IRepositoryBase<WorkingForm, int>
    {
        Task<PagingResult<WorkingFormDto>> Paging(string? keyWord, string? sortBy, string? orderBy, int pageIndex = 1, int pageSize = 10);
        Task<WorkingFormDto> Create(CreateWorkingFormDto request);
        Task Update(int id, UpdateWorkingFormDto request);
        Task<WorkingFormDto> GetById(int id);
    }
}
