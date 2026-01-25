using AutoMapper;
using HRM_BE.Core.Data.Address;
using HRM_BE.Core.Data.Task;
using HRM_BE.Core.Exceptions;
using HRM_BE.Core.IRepositories;
using HRM_BE.Core.Models.Comment;
using HRM_BE.Core.Models.Common;
using HRM_BE.Data.SeedWorks;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HRM_BE.Data.Repositories
{
    public class CommentRepository : RepositoryBase<Comment, int>, ICommentRepository
    {
        private readonly IMapper _mapper;
        public CommentRepository(HrmContext context, IMapper mapper, IHttpContextAccessor httpContextAccessor) : base(context, httpContextAccessor)
        {
            _mapper = mapper;
        }


        public async Task<PagingResult<CommentDto>> Get(GetCommentRequest request)
        {
            try
            {
                var query = _dbContext.Comments.Where(x => x.IsDeleted != true).AsQueryable();

                if (request.WorkId != null)
                {
                    query = query.Where(b => b.WorkId == request.WorkId);
                }

                int total = await query.CountAsync();

                if (request.PageIndex == null) request.PageIndex = 1;
                if (request.PageSize == null) request.PageSize = total;

                int totalPages = (int)Math.Ceiling((double)total / request.PageSize);

                var comments = await query
                    .Include(c => c.Employee)  
                    .OrderByDescending(b => b.Id)
                    .Skip((request.PageIndex - 1) * request.PageSize)
                    .Take(request.PageSize)
                    .ToListAsync();

                var commentParrents = comments.Where(c => c.ParentCommentId == null);

                var commentDtos = _mapper.Map<List<CommentDto>>(commentParrents);

                foreach (var commentDto in commentDtos)
                {
                    commentDto.Children = await this.GetRecursive(commentDto.Id, comments);
                }

                var result = new PagingResult<CommentDto>(commentDtos, request.PageIndex, request.PageSize, total);

                return result;
            }
            catch (Exception ex)
            {
                throw new Exception("Error " + ex.Message, ex);
            }
        }

        private async Task<List<CommentDto>> GetRecursive(int? parentCommentId, IEnumerable<Comment> allComments)
        {
            var children = allComments
                .Where(p => p.ParentCommentId == parentCommentId)
                .ToList();

            var childDtos = new List<CommentDto>();

            foreach (var childComment in children)
            {
                var childDto = _mapper.Map<CommentDto>(childComment);
                childDto.Children = await GetRecursive(childComment.Id, allComments);
                childDtos.Add(childDto);
            }

            return childDtos;
        }



        public async Task<CommentDto> Create(CreateCommentRequest request)
        {
            try
            {
                var comment = _mapper.Map<Comment>(request);

                await CreateAsync(comment);

                var commentDto = _mapper.Map<CommentDto>(comment);
                return commentDto;
            }
            catch (Exception ex)
            {
                throw new Exception("Error " + ex.Message, ex);
            }
        }

        public async Task<CommentDto> Delete(int id)
        {
            try
            {
                var comment = await _dbContext.Comments.FindAsync(id);

                if (comment == null)
                {
                    throw new Exception("Not Found");
                }

                comment.IsDeleted =true;

                await UpdateAsync(comment);

                var commentDto = _mapper.Map<CommentDto>(comment);
                return commentDto;
            }
            catch (Exception ex)
            {
                throw new Exception("Error " + ex.Message, ex);
            }
        }



    }
}
