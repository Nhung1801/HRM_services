using AutoMapper;
using HRM_BE.Core.Data.Company;
using HRM_BE.Core.Data.Profile;
using HRM_BE.Core.Data.Staff;
using HRM_BE.Core.Exceptions;
using HRM_BE.Core.Extension;
using HRM_BE.Core.IRepositories;
using HRM_BE.Core.Models.Common;
using HRM_BE.Core.Models.Profile.ContractDuration;
using HRM_BE.Core.Models.Staff;
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
    public class ContractDurationRepository : RepositoryBase<ContractDuration, int>, IContractDurationRepository
    {
        private readonly IMapper _mapper;
        public ContractDurationRepository(HrmContext context, IMapper mapper, IHttpContextAccessor httpContextAccessor) : base(context, httpContextAccessor)
        {
            _mapper = mapper;
        }
        public async Task<ContractDurationDto> Create(CreateContractDurationDto request)
        {
            var entity = _mapper.Map<ContractDuration>(request);
            await CreateAsync(entity);
            return _mapper.Map<ContractDurationDto>(entity);
        }

        public async Task<PagingResult<ContractDurationDto>> Paging(string? keyWord, string? sortBy, string? orderBy, int pageIndex = 1, int pageSize = 10)
        {
            var query = _dbContext.ContractDurations.Where(c => c.IsDeleted == false).AsQueryable();
            if (!string.IsNullOrEmpty(keyWord))
            {
                query = query.Where(c => c.Duration.Contains(keyWord));
            }
           
            // Áp dụng sắp xếp
            query = query.ApplySorting(sortBy, orderBy);
            // Tính tổng số bản ghi
            int total = await query.CountAsync();
            // Áp dụng phân trang
            query = query.ApplyPaging(pageIndex, pageSize);

            var data = await _mapper.ProjectTo<ContractDurationDto>(query).ToListAsync();

            var result = new PagingResult<ContractDurationDto>(data, pageIndex, pageSize, sortBy, orderBy, total);

            return result;
        }

        public async Task Update(int id, UpdateContractDurationDto request)
        {
            var entity = await GetContractDurationAndCheckExsit(id);
            await UpdateAsync(_mapper.Map(request, entity));
        }
        private async Task<ContractDuration> GetContractDurationAndCheckExsit(int contractDurationId)
        {
            var contractDuration = await _dbContext.ContractDurations.FindAsync(contractDurationId);
            if (contractDuration is null)
                throw new EntityNotFoundException(nameof(ContractDuration), $"Id = {contractDuration}");
            return contractDuration;
        }

        public async Task<ContractDurationDto> GetById(int id)
        {
            var entity = await GetContractDurationAndCheckExsit(id);
            return _mapper.Map<ContractDurationDto>(entity);
        }
    }
}