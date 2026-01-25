using AutoMapper;
using HRM_BE.Core.Data.Task;
using HRM_BE.Core.Exceptions;
using HRM_BE.Core.Extension;
using HRM_BE.Core.IRepositories;
using HRM_BE.Core.ISeedWorks;
using HRM_BE.Core.Models.Common;
using HRM_BE.Core.Models.Work;
using HRM_BE.Data.SeedWorks;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HRM_BE.Data.Repositories
{
    public class ApprovalEmployeeRepository:RepositoryBase<ApprovalEmployee, int>, IApprovalEmployeeRepository
    {
        private readonly IMapper _mapper;
        public ApprovalEmployeeRepository(HrmContext context, IMapper mapper, IHttpContextAccessor httpContextAccessor):base(context,httpContextAccessor)
        {
            _mapper = mapper;
        }

        public async Task<ApprovalEmployeeDto> GetById(int id)
        {
            var approvalEmployee = await GetAndCheckExsit(id);
            return _mapper.Map<ApprovalEmployeeDto>(approvalEmployee);
        }

        public async Task<PagingResult<ApprovalEmployeeDto>> Paging(string? keyWord, int? approvalId, int? employeeId,string? ordeBy,string? sortBy, int pageIndex, int pageSize)
        {
            var query = _dbContext.ApprovalEmployees.AsQueryable().AsNoTracking();
            if (!string.IsNullOrEmpty(keyWord))
            {
                query = query.Where(x => x.Description.Contains(keyWord));
            }
            if(approvalId.HasValue)
            {
                query = query.Where(x => x.ApprovalId == approvalId);
            }
            if (employeeId.HasValue)
            {
                query = query.Where(x => x.EmployeeId == employeeId);
            }
            query.ApplySorting(ordeBy,sortBy);
            query.ApplyPaging(pageIndex, pageSize);
            var total = await query.CountAsync();
            var data = await _mapper.ProjectTo<ApprovalEmployeeDto>(query).ToListAsync();
            var result = new PagingResult<ApprovalEmployeeDto>(data,pageIndex,pageSize,total);
            return result;
        }

        public async Task Update(int id, UpdateApprovalEmployeeRequest request)
        {
            var approvalEmployee = await GetAndCheckExsit(id);
            _mapper.Map(request, approvalEmployee);
            await UpdateAsync(approvalEmployee);
        }
        public async Task<ApprovalEmployee> GetAndCheckExsit(int id)
        {
            var entity = await _dbContext.ApprovalEmployees.FindAsync(id);
            if (entity == null)
            {
                throw new EntityNotFoundException(nameof(ApprovalEmployee),"ApprovalEmployee not found");
            }
            return entity;
        }
    }
}
