using AutoMapper;
using HRM_BE.Core.Data.Task;
using HRM_BE.Core.Exceptions;
using HRM_BE.Core.Extension;
using HRM_BE.Core.IRepositories;
using HRM_BE.Core.Models.Common;
using HRM_BE.Core.Models.Organization;
using HRM_BE.Core.Models.Tag;
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
    public class TagRepository:RepositoryBase<Tag,int>, ITagRepository
    {
        private readonly IMapper _mapper;
        public TagRepository(HrmContext context, IMapper mapper, IHttpContextAccessor httpContextAccessor):base(context,httpContextAccessor)
        {
            _mapper = mapper;
        }

        public async Task<TagDto> Create(CreateTagRequest request)
        {
            var entity = _mapper.Map<Tag>(request);
            var entityCreated = await CreateAsync(entity);
            return _mapper.Map<TagDto>(entityCreated);
        }

        public async Task<TagDto> GetById(int id)
        {
            var result = await GetAndCheckExist(id);
            return _mapper.Map<TagDto>(result);
        }

        public async Task<PagingResult<TagDto>> Paging(string? keyWord, string? orderBy,string? sortBy, int pageIndex = 1, int pageSize = 10)
        {
            var query = _dbContext.Tags.AsNoTracking().AsQueryable();
            if (!string.IsNullOrEmpty(keyWord)) 
            { 

            }
            query.ApplySorting(orderBy, sortBy);
            int total = await query.CountAsync();

            query.ApplyPaging(pageIndex, pageSize);

            var data = await _mapper.ProjectTo<TagDto>(query).ToListAsync();

            var result = new PagingResult<TagDto>(data,pageIndex,pageSize,total);
            return result;

        }

        public async Task Update(int id, UpdateTagRequest request)
        {
            var entity = await GetAndCheckExist(id);
            _mapper.Map(request, entity);
            await UpdateAsync(entity);

        }    
        public async Task Delete(int id)
        {
            var entity = await GetAndCheckExist(id);
            entity.IsDeleted = true;
            await UpdateAsync(entity);

        }
        private async Task<Tag> GetAndCheckExist(int tagId)
        {
            var entity = await _dbContext.Tags.FindAsync(tagId);
            if (entity is null)
                throw new EntityNotFoundException(nameof(Tag), $"id = {tagId}");
            return entity;

        }
    }
}
