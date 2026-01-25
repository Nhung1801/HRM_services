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
    public class TimekeepingRegulationRepository : RepositoryBase<TimekeepingRegulation, int>, ITimekeepingRegulationRepository
    {
        private readonly IMapper _mapper;

        public TimekeepingRegulationRepository(HrmContext context, IMapper mapper, IHttpContextAccessor httpContextAccessor) : base(context, httpContextAccessor)
        {
            _mapper = mapper;
        }

        public async Task<TimekeepingRegulationDto?> GetByOrganizationId(int organizationId)
        {
            var entity = await _dbContext.TimekeepingRegulations
                                         .FirstOrDefaultAsync(x => x.OrganizationId == organizationId && x.IsDeleted != true);
            return _mapper.Map<TimekeepingRegulationDto?>(entity);
        }


        public async Task<TimekeepingRegulationDto> Create(CreateTimeKeepingRegulationRequest request)
        {
            var entity = _mapper.Map<TimekeepingRegulation>(request);
            await CreateAsync(entity);
            return _mapper.Map<TimekeepingRegulationDto>(entity);
        }

        public async Task<TimekeepingRegulationDto> GetById(int id)
        {
            var entity = await GetTimekeepingRegulationAndCheckExist(id);
            return _mapper.Map<TimekeepingRegulationDto>(entity);
        }

        public async Task<PagingResult<TimekeepingRegulationDto>> Paging(int? organizationId, string? sortBy, string? orderBy, int pageIndex = 1, int pageSize = 10)
        {
            var query = _dbContext.TimekeepingRegulations.Where(g => g.IsDeleted != true).AsQueryable();

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

            var data = await _mapper.ProjectTo<TimekeepingRegulationDto>(query).ToListAsync();

            var result = new PagingResult<TimekeepingRegulationDto>(data, pageIndex, pageSize, sortBy, orderBy, total);

            return result;
        }

        public async Task Update(int id, UpdateTimekeepingRegulationRequest request)
        {
            var entity = await GetTimekeepingRegulationAndCheckExist(id);
            await UpdateAsync(_mapper.Map(request, entity));
        }

        public async Task UpdateV2(int organizationId, CreateTimeKeepingRegulationRequest request)
        {
            // Lấy entity cần cập nhật từ database
            var entity = await _dbContext.TimekeepingRegulations
                                            .FirstOrDefaultAsync(r => r.OrganizationId == organizationId);

            // Ánh xạ dữ liệu từ request sang entity hiện tại
            _mapper.Map(request, entity);

            // Cập nhật lại entity
            await UpdateAsync(entity);
        }


        private async Task<TimekeepingRegulation> GetTimekeepingRegulationAndCheckExist(int timekeepingRegulationId)
        {
            var timekeepingRegulation = await _dbContext.TimekeepingRegulations.FindAsync(timekeepingRegulationId);
            if (timekeepingRegulation is null)
                throw new EntityNotFoundException(nameof(TimekeepingRegulation), $"Id = {timekeepingRegulationId}");
            return timekeepingRegulation;
        }
    }
}
