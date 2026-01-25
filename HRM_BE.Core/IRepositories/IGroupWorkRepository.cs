using HRM_BE.Core.Data.Task;
using HRM_BE.Core.ISeedWorks;
using HRM_BE.Core.Models.Common;
using HRM_BE.Core.Models.GroupWorkModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HRM_BE.Core.IRepositories
{
    public interface IGroupWorkRepository:IRepositoryBase<GroupWork,int>
    {
        Task<GroupWorkDto> Create(CreateGroupWorkRequest request);
        Task Update(int id ,UpdateGroupWorkRequest request);
        Task<GroupWorkDto> GetById(int id);
        Task<PagingResult<GroupWorkDto>> Paging(string? KeyWord, int? projectId,string? orderBy, string? sortBy, int pageIndex = 1, int pageSize = 10);
        Task<List<GroupWorkDto>> GetAll();
        Task Delete(int id);
    }
}
