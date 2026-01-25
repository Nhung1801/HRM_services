using AutoMapper;
using HRM_BE.Core.Data.Profile;
using HRM_BE.Core.Exceptions;
using HRM_BE.Core.Extension;
using HRM_BE.Core.IRepositories;
using HRM_BE.Core.Models.Common;
using HRM_BE.Core.Models.Contract.NatureOfLabor;
using HRM_BE.Core.Models.Profile.ContractType;
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
    public class NatureOfLaborRepository : RepositoryBase<NatureOfLabor, int>, INatureOfLaborRepository
    {
        private readonly IMapper _mapper;
        public NatureOfLaborRepository(HrmContext context, IMapper mapper, IHttpContextAccessor httpContextAccessor) : base(context, httpContextAccessor)
        {
            _mapper = mapper;
        }

        public async Task<NatureOfLaborDto> Create(CreateNatureOfLaborDto request)
        {
            var entity = _mapper.Map<NatureOfLabor>(request);
            await CreateAsync(entity);
            return _mapper.Map<NatureOfLaborDto>(entity);
        }

        public async Task<NatureOfLaborDto> GetById(int id)
        {
            var entity = await GetNatureOfLaborAndCheckExist(id);
            return _mapper.Map<NatureOfLaborDto>(entity);
        }

        public async Task<PagingResult<NatureOfLaborDto>> Paging(string? keyWord, string? sortBy, string? orderBy, int pageIndex = 1, int pageSize = 10)
        {
            var query = _dbContext.NatureOfLabor.Where(n => n.IsDeleted != true).AsQueryable();
            if (!string.IsNullOrEmpty(keyWord))
            {
                query = query.Where(n => n.Name.Contains(keyWord));
            }

            // Áp dụng sắp xếp
            query = query.ApplySorting(sortBy, orderBy);
            // Tính tổng số bản ghi
            int total = await query.CountAsync();
            // Áp dụng phân trang
            query = query.ApplyPaging(pageIndex, pageSize);

            var data = await _mapper.ProjectTo<NatureOfLaborDto>(query).ToListAsync();

            var result = new PagingResult<NatureOfLaborDto>(data, pageIndex, pageSize, sortBy, orderBy, total);

            return result;
        }

        public async Task Update(int id, UpdateNatureOfLaborDto request)
        {
            var entity = await GetNatureOfLaborAndCheckExist(id);
            await UpdateAsync(_mapper.Map(request, entity));
        }

        private async Task<NatureOfLabor> GetNatureOfLaborAndCheckExist(int natureOfLaborId)
        {
            var natureOfLabor = await _dbContext.NatureOfLabor.FindAsync(natureOfLaborId);
            if (natureOfLabor is null)
                throw new EntityNotFoundException(nameof(NatureOfLabor), $"Id = {natureOfLabor}");
            return natureOfLabor;
        }
    }
}
