using AutoMapper;
using HRM_BE.Core.Data.Payroll_Timekeeping.TimekeepingRegulation;
using HRM_BE.Core.Exceptions;
using HRM_BE.Core.Extension;
using HRM_BE.Core.IRepositories;
using HRM_BE.Core.Models.Common;
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
    public class TimekeepingSettingRepository : RepositoryBase<TimekeepingSetting, int>, ITimekeepingSettingRepository
    {
        private readonly IMapper _mapper;

        public TimekeepingSettingRepository(HrmContext context, IMapper mapper, IHttpContextAccessor httpContextAccessor) : base(context, httpContextAccessor)
        {
            _mapper = mapper;
        }

        public async Task<TimekeepingSettingDto> Create(CreateTimekeepingSettingRequest request)
        {
            var entity = _mapper.Map<TimekeepingSetting>(request);
            await CreateAsync(entity);
            return _mapper.Map<TimekeepingSettingDto>(entity);
        }

        public async Task<TimekeepingSettingDto> GetById(int id)
        {
            var entity = await GetTimekeepingSettingAndCheckExist(id);
            return _mapper.Map<TimekeepingSettingDto>(entity);
        }

        public async Task<PagingResult<TimekeepingSettingDto>> Paging(int? organizationId, string? sortBy, string? orderBy, int pageIndex = 1, int pageSize = 10)
        {
            var query = _dbContext.TimekeepingSettings.Where(g => g.IsDeleted != true).AsQueryable();

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

            var data = await _mapper.ProjectTo<TimekeepingSettingDto>(query).ToListAsync();

            var result = new PagingResult<TimekeepingSettingDto>(data, pageIndex, pageSize, sortBy, orderBy, total);

            return result;
        }

        private async Task<TimekeepingSetting> GetTimekeepingSettingAndCheckExist(int timekeepingSettingId)
        {
            var timekeepingSetting = await _dbContext.TimekeepingSettings.FindAsync(timekeepingSettingId);
            if (timekeepingSetting is null)
                throw new EntityNotFoundException(nameof(TimekeepingSetting), $"Id = {timekeepingSettingId}");
            return timekeepingSetting;
        }
    }
}
