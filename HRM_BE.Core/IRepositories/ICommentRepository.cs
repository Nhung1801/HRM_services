using HRM_BE.Core.Data.Content;
using HRM_BE.Core.Data.Task;
using HRM_BE.Core.ISeedWorks;
using HRM_BE.Core.Models.Comment;
using HRM_BE.Core.Models.Common;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HRM_BE.Core.IRepositories
{
    public interface ICommentRepository : IRepositoryBase<Comment, int>
    {
        Task<PagingResult<CommentDto>> Get(GetCommentRequest request);

        Task<CommentDto> Create(CreateCommentRequest request);

        Task<CommentDto> Delete(int id);
       
    }
}
