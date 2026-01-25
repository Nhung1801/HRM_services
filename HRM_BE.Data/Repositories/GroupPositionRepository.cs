using AutoMapper;
using HRM_BE.Core.Data.Company;
using HRM_BE.Core.Data.Staff;
using HRM_BE.Core.Exceptions;
using HRM_BE.Core.IRepositories;
using HRM_BE.Core.Models.Staff;
using HRM_BE.Data.SeedWorks;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Formats.Asn1;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HRM_BE.Data.Repositories
{
    public class GroupPositionRepository : RepositoryBase<GroupPosition, int>, IGroupPositionRepository
    {
        private readonly IMapper _mapper;
        public GroupPositionRepository(HrmContext context,IMapper mapper, IHttpContextAccessor httpContextAccessor):base(context,httpContextAccessor)
        {
            _mapper = mapper;
        }
        public async Task<GroupPositionDto> Create(CreateGroupPositionRequest request)
        {
            var entity = _mapper.Map<GroupPosition>(request);
            await CreateAsync(entity);
            return _mapper.Map<GroupPositionDto>(entity);
        }

        public async Task Delete(int id)
        {
            var entity = await GetGroupPositionAndCheckExsit(id);
            await DeleteAsync(entity);
        }

        public async Task<List<GroupPositionDto>> GetAll()
        {
            var result = await _dbContext.GroupPositions.ToListAsync();
            var resultReturn = _mapper.Map<List<GroupPositionDto>>(result);
            return resultReturn;
        }

        public async Task<GroupPositionDto> GetById(int id)
        {
            var entity = await GetGroupPositionAndCheckExsit(id);
            return _mapper.Map<GroupPositionDto>(entity);
        }

        public async Task Update(int id, UpdateGrouptPositonRequest request)
        {
            var entity = await GetGroupPositionAndCheckExsit(id);

            var entityUpdate = _mapper.Map(request, entity);
            await UpdateAsync(entityUpdate);
        }
        private async Task<GroupPosition> GetGroupPositionAndCheckExsit(int id)
        {
            var GroupPosition = await _dbContext.GroupPositions.FindAsync(id);
            if (GroupPosition is null)
                throw new EntityNotFoundException(nameof(GroupPosition), $"Id = {id}");
            return GroupPosition;
        }
    }
}
