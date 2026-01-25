using AutoMapper;
using HRM_BE.Core.Data.Payroll_Timekeeping.LeaveRegulation;
using HRM_BE.Core.Exceptions;
using HRM_BE.Core.Extension;
using HRM_BE.Core.IRepositories;
using HRM_BE.Core.Models.Common;
using HRM_BE.Core.Models.Payroll_Timekeeping.LeaveRegulation;
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
    public class TypeOfLeaveRepository : RepositoryBase<TypeOfLeave, int>, ITypeOfLeaveRepository
    {
        private readonly IMapper _mapper;

        public TypeOfLeaveRepository(HrmContext context, IMapper mapper, IHttpContextAccessor httpContextAccessor) : base(context, httpContextAccessor)
        {
            _mapper = mapper;
        }

        public async Task<TypeOfLeaveDto> Create(CreateTypeOfLeaveRequest request)
        {
            var entity = _mapper.Map<TypeOfLeave>(request);
            await CreateAsync(entity);
            return _mapper.Map<TypeOfLeaveDto>(entity);
        }

        public async Task<TypeOfLeaveDto> GetById(int id)
        {
            var entity = await GetTypeOfLeaveAndCheckExist(id);
            return _mapper.Map<TypeOfLeaveDto>(entity);
        }

        public async Task<PagingResult<TypeOfLeaveDto>> Paging(int? organizationId, string? sortBy, string? orderBy, int pageIndex = 1, int pageSize = 10)
        {
            var query = _dbContext.TypeOfLeaves.Where(g => g.IsDeleted != true).AsQueryable();

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
            var data = await _mapper.ProjectTo<TypeOfLeaveDto>(query).ToListAsync();
            var result = new PagingResult<TypeOfLeaveDto>(data, pageIndex, pageSize, sortBy, orderBy, total);
            return result;
        }

        public async Task Update(int id, UpdateTypeOfLeaveRequest request)
        {
            var entity = await GetTypeOfLeaveAndCheckExist(id);
            await UpdateAsync(_mapper.Map(request, entity));
        }

        public async Task Delete(int id)
        {
            var entity = await GetTypeOfLeaveAndCheckExist(id);
            entity.IsDeleted = true;
            await UpdateAsync(entity);
        }

        private async Task<TypeOfLeave> GetTypeOfLeaveAndCheckExist(int typeOfLeaveId)
        {
            var typeOfLeave = await _dbContext.TypeOfLeaves.FindAsync(typeOfLeaveId);
            if (typeOfLeave is null)
                throw new EntityNotFoundException(nameof(TypeOfLeave), $"Id = {typeOfLeaveId}");
            return typeOfLeave;
        }
    }
}
