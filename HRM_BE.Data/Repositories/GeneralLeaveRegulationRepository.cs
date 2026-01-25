using AutoMapper;
using HRM_BE.Core.Data.Payroll_Timekeeping.LeaveRegulation;
using HRM_BE.Core.Data.Payroll_Timekeeping.TimekeepingRegulation;
using HRM_BE.Core.Data.Profile;
using HRM_BE.Core.Exceptions;
using HRM_BE.Core.Extension;
using HRM_BE.Core.IRepositories;
using HRM_BE.Core.Models.Common;
using HRM_BE.Core.Models.Contract.NatureOfLabor;
using HRM_BE.Core.Models.Payroll_Timekeeping.LeaveRegulation;
using HRM_BE.Core.Models.Payroll_Timekeeping.TimekeepingRegulation;
using HRM_BE.Data.SeedWorks;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HRM_BE.Data.Repositories
{
    public class GeneralLeaveRegulationRepository : RepositoryBase<GeneralLeaveRegulation, int>, IGeneralLeaveRegulationRepository
    {
        private readonly IMapper _mapper;

        public GeneralLeaveRegulationRepository(HrmContext context, IMapper mapper, IHttpContextAccessor httpContextAccessor) : base(context, httpContextAccessor)
        {
            _mapper = mapper;
        }

        public async Task<GeneralLeaveRegulationDto> Create(CreateGeneralLeaveRegulationRequest request)
        {
            var entity = _mapper.Map<GeneralLeaveRegulation>(request);
            await CreateAsync(entity);
            return _mapper.Map<GeneralLeaveRegulationDto>(entity);
        }

        public async Task<GeneralLeaveRegulationDto> GetById(int id)
        {
            var entity = await GetGeneralLeaveRegulationAndCheckExist(id);
            return _mapper.Map<GeneralLeaveRegulationDto>(entity);
        }

        public async Task<PagingResult<GeneralLeaveRegulationDto>> Paging(int? organizationId, string? sortBy, string? orderBy, int pageIndex = 1, int pageSize = 10)
        {
            var query = _dbContext.GeneralLeaveRegulations.Where(g => g.IsDeleted != true).AsQueryable();

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

            var data = await _mapper.ProjectTo<GeneralLeaveRegulationDto>(query).ToListAsync();

            var result = new PagingResult<GeneralLeaveRegulationDto>(data, pageIndex, pageSize, sortBy, orderBy, total);

            return result;
        }

        public async Task Update(int id, UpdateGeneralLeaveRegulationRequest request)
        {
            var entity = await GetGeneralLeaveRegulationAndCheckExist(id);
            await UpdateAsync(_mapper.Map(request, entity));
        }

        private async Task<GeneralLeaveRegulation> GetGeneralLeaveRegulationAndCheckExist(int generalLeaveRegulationId)
        {
            var generalLeaveRegulation = await _dbContext.GeneralLeaveRegulations.FindAsync(generalLeaveRegulationId);
            if (generalLeaveRegulation is null)
                throw new EntityNotFoundException(nameof(GeneralLeaveRegulation), $"Id = {generalLeaveRegulationId}");
            return generalLeaveRegulation;
        }


        public async Task<GeneralLeaveRegulationDto?> GetByOrganizationId(int? organizationId)
        {
            var entity = await _dbContext.GeneralLeaveRegulations
                                         .FirstOrDefaultAsync(x => x.OrganizationId == organizationId && x.IsDeleted != true);
            return _mapper.Map<GeneralLeaveRegulationDto?>(entity);
        }

        public async Task UpdateV2(int? organizationId, CreateGeneralLeaveRegulationRequest request)
        {
            // Lấy entity cần cập nhật từ database
            var entity = await _dbContext.GeneralLeaveRegulations
                                            .FirstOrDefaultAsync(r => r.OrganizationId == organizationId);

            // Ánh xạ dữ liệu từ request sang entity hiện tại
            _mapper.Map(request, entity);

            // Cập nhật lại entity
            await UpdateAsync(entity);
        }
    }
}
