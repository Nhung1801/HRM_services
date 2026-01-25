using AutoMapper;
using HRM_BE.Core.Data.Payroll_Timekeeping.LeaveRegulation;
using HRM_BE.Core.Data.Payroll_Timekeeping.TimekeepingRegulation;
using HRM_BE.Core.Exceptions;
using HRM_BE.Core.Extension;
using HRM_BE.Core.IRepositories;
using HRM_BE.Core.Models.Common;
using HRM_BE.Core.Models.Payroll_Timekeeping.LeaveRegulation;
using HRM_BE.Core.Models.Payroll_Timekeeping.TimekeepingRegulation;
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
    public class TimekeepingLocationRepository : RepositoryBase<TimekeepingLocation, int>, ITimekeepingLocationRepository
    {
        private readonly IMapper _mapper;

        public TimekeepingLocationRepository(HrmContext context, IMapper mapper, IHttpContextAccessor httpContextAccessor) : base(context, httpContextAccessor)
        {
            _mapper = mapper;
        }

        public async Task<TimekeepingLocationDto> Create(CreateTimekeepingLocationRequest request)
        {
            var entity = _mapper.Map<TimekeepingLocation>(request);
            await CreateAsync(entity);
            return _mapper.Map<TimekeepingLocationDto>(entity);
        }

        public async Task<TimekeepingLocationDto> GetById(int id)
        {
            var entity = await GetTimekeepingLocationAndCheckExist(id);
            return _mapper.Map<TimekeepingLocationDto>(entity);
        }

        public async Task<PagingResult<TimekeepingLocationDto>> Paging(int? organizationId, string? sortBy, string? orderBy, int pageIndex = 1, int pageSize = 10)
        {
            var query = _dbContext.TimekeepingLocations.Where(g => g.IsDeleted != true).AsQueryable();

            if (organizationId.HasValue)
            {
                query = query.Where(g => g.OrganizationId == organizationId);
            }

            // Áp dụng sắp xếp
            query = query.ApplySorting(sortBy, orderBy);
            // Tính tổng số bản ghi
            int total = await query.CountAsync();
            // Áp dụng phân trang
            query = query.ApplyPaging(pageIndex, pageSize);

            var data = await _mapper.ProjectTo<TimekeepingLocationDto>(query).ToListAsync();

            var result = new PagingResult<TimekeepingLocationDto>(data, pageIndex, pageSize, sortBy, orderBy, total);

            return result;
        }

        public async Task Update(int id, UpdateTimekeepingLocationRequest request)
        {
            var entity = await GetTimekeepingLocationAndCheckExist(id);
            await UpdateAsync(_mapper.Map(request, entity));
        }

        public async Task Delete(int id)
        {
            var entity = await GetTimekeepingLocationAndCheckExist(id);
            await DeleteAsync(entity);
        }

        private async Task<TimekeepingLocation> GetTimekeepingLocationAndCheckExist(int timekeepingLocationId)
        {
            var timekeepingLocation = await _dbContext.TimekeepingLocations.FindAsync(timekeepingLocationId);
            if (timekeepingLocation is null)
                throw new EntityNotFoundException(nameof(TimekeepingLocation), $"Id = {timekeepingLocationId}");
            return timekeepingLocation;
        }

        public async Task<TimekeepingLocation?> GetByOrganizationIdAsync(int organizationId)
        {
            return await _dbContext.TimekeepingLocations
                .Where(t => t.OrganizationId == organizationId && t.IsDeleted != true)
                .FirstOrDefaultAsync();
        }
    }
}
