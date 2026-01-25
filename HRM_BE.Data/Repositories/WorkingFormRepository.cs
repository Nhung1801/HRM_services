using AutoMapper;
using HRM_BE.Core.Data.Profile;
using HRM_BE.Core.Exceptions;
using HRM_BE.Core.Extension;
using HRM_BE.Core.IRepositories;
using HRM_BE.Core.Models.Common;
using HRM_BE.Core.Models.Profile.WorkingForm;
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
    public class WorkingFormRepository : RepositoryBase<WorkingForm, int>, IWorkingFormRepository
    {
        private readonly IMapper _mapper;
        public WorkingFormRepository(HrmContext context, IMapper mapper, IHttpContextAccessor httpContextAccessor) : base(context, httpContextAccessor)
        {
            _mapper = mapper;
        }

        public async Task<WorkingFormDto> Create(CreateWorkingFormDto request)
        {
            var entity = _mapper.Map<WorkingForm>(request);
            await CreateAsync(entity);
            return _mapper.Map<WorkingFormDto>(entity);
        }

        public async Task<PagingResult<WorkingFormDto>> Paging(string? keyWord, string? sortBy, string? orderBy, int pageIndex = 1, int pageSize = 10)
        {
            var query = _dbContext.WorkingForms.Where(c => c.IsDeleted != true).AsQueryable();
            if (!string.IsNullOrEmpty(keyWord))
            {
                query = query.Where(c => c.Form.Contains(keyWord));
            }

            // Áp dụng sắp xếp
            query = query.ApplySorting(sortBy, orderBy);
            // Tính tổng số bản ghi
            int total = await query.CountAsync();
            // Áp dụng phân trang
            query = query.ApplyPaging(pageIndex, pageSize);

            var data = await _mapper.ProjectTo<WorkingFormDto>(query).ToListAsync();

            var result = new PagingResult<WorkingFormDto>(data, pageIndex, pageSize, sortBy, orderBy, total);

            return result;
        }

        public async Task Update(int id, UpdateWorkingFormDto request)
        {
            var entity = await GetWorkingFormAndCheckExsit(id);
            await UpdateAsync(_mapper.Map(request, entity));
        }
        private async Task<WorkingForm> GetWorkingFormAndCheckExsit(int WorkingFormId)
        {
            var WorkingForm = await _dbContext.WorkingForms.FindAsync(WorkingFormId);
            if (WorkingForm is null)
                throw new EntityNotFoundException(nameof(WorkingForm), $"Id = {WorkingForm}");
            return WorkingForm;
        }

        public async Task<WorkingFormDto> GetById(int id)
        {
            var entity = await GetWorkingFormAndCheckExsit(id);
            return _mapper.Map<WorkingFormDto>(entity);
        }
    }
}
