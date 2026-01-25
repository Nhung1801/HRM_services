using HRM_BE.Core.Data.Task;
using HRM_BE.Core.ISeedWorks;
using HRM_BE.Core.Models.Common;
using HRM_BE.Core.Models.Tag;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HRM_BE.Core.IRepositories
{
    public interface ITagRepository:IRepositoryBase<Tag,int>
    {
        Task<TagDto> Create(CreateTagRequest request);
        Task<PagingResult<TagDto>> Paging(string? keyWord, string? orderBy, string? sortBy, int pageIndex = 1, int pageSize = 10);
        Task Update(int id, UpdateTagRequest request);
        Task<TagDto> GetById(int id);
        Task Delete(int id);
    }
}
