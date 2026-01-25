using AutoMapper;
using HRM_BE.Core.Data.Profile;
using HRM_BE.Core.Exceptions;
using HRM_BE.Core.Extension;
using HRM_BE.Core.IRepositories;
using HRM_BE.Core.Models.Common;
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
    public class ContractTypeRepository : RepositoryBase<ContractType, int>, IContractTypeRepository
    {
        private readonly IMapper _mapper;
        public ContractTypeRepository(HrmContext context, IMapper mapper, IHttpContextAccessor httpContextAccessor) : base(context, httpContextAccessor)
        {
            _mapper = mapper;
        }

        public async Task<ContractTypeDto> Create(CreateContractTypeDto request)
        {
            var entity = _mapper.Map<ContractType>(request);
            await CreateAsync(entity);
            return _mapper.Map<ContractTypeDto>(entity);
        }

        public async Task<PagingResult<ContractTypeDto>> Paging(string? keyWord, string? sortBy, string? orderBy, int pageIndex = 1, int pageSize = 10)
        {
            var query = _dbContext.ContractTypes.Where(c => c.IsDeleted != true).AsQueryable();
            if (!string.IsNullOrEmpty(keyWord))
            {
                query = query.Where(c => c.Name.Contains(keyWord));
            }

            // Áp dụng sắp xếp
            query = query.ApplySorting(sortBy, orderBy);
            // Tính tổng số bản ghi
            int total = await query.CountAsync();
            // Áp dụng phân trang
            query = query.ApplyPaging(pageIndex, pageSize);

            var data = await _mapper.ProjectTo<ContractTypeDto>(query).ToListAsync();

            var result = new PagingResult<ContractTypeDto>(data, pageIndex, pageSize, sortBy, orderBy, total);

            return result;
        }

        public async Task Update(int id, UpdateContractTypeDto request)
        {
            var entity = await GetContractTypeAndCheckExsit(id);
            await UpdateAsync(_mapper.Map(request, entity));
        }
        private async Task<ContractType> GetContractTypeAndCheckExsit(int contractTypeId)
        {
            var contractType = await _dbContext.ContractTypes.FindAsync(contractTypeId);
            if (contractType is null)
                throw new EntityNotFoundException(nameof(ContractType), $"Id = {contractType}");
            return contractType;
        }

        public async Task<ContractTypeDto> GetById(int id)
        {
            var entity = await GetContractTypeAndCheckExsit(id);
            return _mapper.Map<ContractTypeDto>(entity);
        }
    }
}
