using AutoMapper;
using AutoMapper.QueryableExtensions;
using HRM_BE.Core.Data.Task;
using HRM_BE.Core.Exceptions;
using HRM_BE.Core.Extension;
using HRM_BE.Core.IRepositories;
using HRM_BE.Core.Models.Common;
using HRM_BE.Core.Models.GroupWorkModel;
using HRM_BE.Core.Models.Tag;
using HRM_BE.Data.SeedWorks;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Microsoft.Extensions.Logging.EventSource.LoggingEventSource;

namespace HRM_BE.Data.Repositories
{
    public class GroupWorkRepository : RepositoryBase<GroupWork, int>, IGroupWorkRepository
    {
        private readonly IMapper _mapper;
        public GroupWorkRepository(HrmContext context,IMapper mapper, IHttpContextAccessor httpContextAccessor):base(context,httpContextAccessor)
        {
            _mapper = mapper;
        }
        public async Task<GroupWorkDto> Create(CreateGroupWorkRequest request)
        {
            var entity = _mapper.Map<GroupWork>(request);
            var createdEntity =  await CreateAsync(entity);
            return _mapper.Map<GroupWorkDto>(createdEntity);
        }

        public async Task Delete(int id)
        {
            var entity = await GetAndCheckExist(id);
            entity.IsDeleted = true;
            await UpdateAsync(entity);
        }

        public async Task<List<GroupWorkDto>> GetAll()
        {
            var query = _dbContext.GroupWorks.AsNoTracking().AsQueryable();
                
            var data = await _mapper.ProjectTo<GroupWorkDto>(query).ToListAsync();
            return data;
        }

        public async Task<GroupWorkDto> GetById(int id)
        {
            var entity = await GetAndCheckExist(id);
            return _mapper.Map<GroupWorkDto>(entity);
        }

        public async Task<PagingResult<GroupWorkDto>> Paging(string? keyWord, int? projectId, string? orderBy, string? sortBy, int pageIndex = 1, int pageSize = 10)
        {
            var query = _dbContext.GroupWorks
                .Include( g => g.Works)
                .ThenInclude( w => w.Reporter)
                .AsQueryable();
            var test = await query.ToListAsync();
            if (!string.IsNullOrEmpty(keyWord))
            {
                query = query.Where(x => x.Name.Contains(keyWord));
            }

            if(projectId.HasValue)
            {
                query = query.Where(x => x.ProjectId == projectId.Value);
            }
            query.ApplySorting(orderBy, sortBy);

            int total = await query.CountAsync();

            query.ApplyPaging(pageIndex, pageSize);

            var data = await _mapper.ProjectTo<GroupWorkDto>(query).ToListAsync();

            var result = new PagingResult<GroupWorkDto>(data, pageIndex, pageSize, total);
            return result;
        }

        public async Task Update(int id ,UpdateGroupWorkRequest request)
        {
            var entity = await GetAndCheckExist(id);
            _mapper.Map(request, entity);
            await UpdateAsync(entity);
        }
        private async Task<GroupWork> GetAndCheckExist(int groupWorkId)
        {
            var entity = await _dbContext.GroupWorks.FindAsync(groupWorkId);
            if ( entity is null)
                throw new EntityNotFoundException(nameof(GroupWork), $" Id = {groupWorkId}");
            return entity;
        }
    }
}
