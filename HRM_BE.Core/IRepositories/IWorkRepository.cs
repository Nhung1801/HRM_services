using HRM_BE.Core.Data.Task;
using HRM_BE.Core.ISeedWorks;
using HRM_BE.Core.Models.Common;
using HRM_BE.Core.Models.WorkModel;
using HRM_BE.Core.Models.WorkModelModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HRM_BE.Core.IRepositories
{
    public interface IWorkRepository:IRepositoryBase<Work,int>
    {
        Task<WorkDto> Create(CreateWorkRequest request);
        Task<WorkDto> Update(int workId,UpdateWorkRequest request);
        Task<WorkDto> GetById( int id);
        Task Delete(int id);
        Task<PagingResult<WorkDto>> Paging(string? keyWork,string? orderBy,string? sortBy,int pageIndex = 1, int pageSize = 10);
    }
}
