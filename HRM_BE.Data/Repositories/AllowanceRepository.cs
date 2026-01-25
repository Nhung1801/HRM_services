using AutoMapper;
using HRM_BE.Core.Data.Profile;
using HRM_BE.Core.Exceptions;
using HRM_BE.Core.Extension;
using HRM_BE.Core.IRepositories;
using HRM_BE.Core.Models.Common;
using HRM_BE.Core.Models.Contract.Allowance;
using HRM_BE.Data.SeedWorks;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.WebSockets;
using System.Text;
using System.Threading.Tasks;

namespace HRM_BE.Data.Repositories
{
    public class AllowanceRepository : RepositoryBase<Allowance, int>, IAllowanceRepository
    {
        private readonly IMapper _mapper;
        public AllowanceRepository(HrmContext context, IMapper mapper, IHttpContextAccessor httpContextAccessor) : base(context, httpContextAccessor)
        {
            _mapper = mapper;
        }

        public async Task<AllowanceDto> Create(CreateAllowanceDto request)
        {
            var entity = _mapper.Map<Allowance>(request);
            await CreateAsync(entity);
            return _mapper.Map<AllowanceDto>(entity);
        }

        public async Task<PagingResult<AllowanceDto>> Paging(string? keyWord, string? sortBy, string? orderBy, int pageIndex = 1, int pageSize = 10)
        {
            var query = _dbContext.Allowances.Where(c => c.IsDeleted != true).AsQueryable();
            if (!string.IsNullOrEmpty(keyWord))
            {
                query = query.Where(c => c.AllowanceName.Contains(keyWord) || c.Note.Contains(keyWord));
            }

            // Áp dụng sắp xếp
            query = query.ApplySorting(sortBy, orderBy);
            // Tính tổng số bản ghi
            int total = await query.CountAsync();
            // Áp dụng phân trang
            query = query.ApplyPaging(pageIndex, pageSize);

            var data = await _mapper.ProjectTo<AllowanceDto>(query).ToListAsync();

            var result = new PagingResult<AllowanceDto>(data, pageIndex, pageSize, sortBy, orderBy, total);

            return result;
        }

        public async Task Update(int id, UpdateAllowanceDto request)
        {
            var entity = await GetAllowanceAndCheckExsit(id);
            await UpdateAsync(_mapper.Map(request, entity));
        }
        private async Task<Allowance> GetAllowanceAndCheckExsit(int AllowanceId)
        {
            var Allowance = await _dbContext.Allowances.FindAsync(AllowanceId);
            if (Allowance is null)
                throw new EntityNotFoundException(nameof(Allowance), $"Id = {Allowance}");
            return Allowance;
        }

        public async Task<AllowanceDto> GetById(int id)
        {
            var entity = await GetAllowanceAndCheckExsit(id);
            return _mapper.Map<AllowanceDto>(entity);
        }

        public async Task<List<AllowanceDto>> GetByContractId(int id)
        {
           var result = await _dbContext.Allowances.Where(a => a.ContractId == id).ToListAsync();

            return _mapper.Map<List<AllowanceDto>>(result);
        }
    }
}
