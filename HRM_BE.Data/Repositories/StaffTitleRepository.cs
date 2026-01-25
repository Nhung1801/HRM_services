using AutoMapper;
using HRM_BE.Core.Data.Staff;
using HRM_BE.Core.Exceptions;
using HRM_BE.Core.IRepositories;
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
    class StaffTitleRepository : RepositoryBase<StaffTitle, int>, IStaffTitleRepository
    {

        private readonly IMapper _mapper;
        public StaffTitleRepository(HrmContext context, IMapper mapper, IHttpContextAccessor httpContextAccessor) : base(context, httpContextAccessor)
        {
            _mapper = mapper;
        }
        public async Task<StaffTitleDto> Create(CreateStaffTitleRequest request)
        {
            var entity = _mapper.Map<StaffTitle>(request);
            await CreateAsync(entity);
            var entityReturn = _mapper.Map<StaffTitleDto>(entity);
            return entityReturn;
        }

        public async Task Delete(int id)
        {
            var staffTitle = await GetStaffTitleAndCheckExsit(id);    
            await DeleteAsync(staffTitle);
        }

        public async Task<List<StaffTitleDto>> GetAll()
        {
            var result = await _dbContext.StaffTitles.ToListAsync();
            var resultReturn = _mapper.Map<List<StaffTitleDto>>(result);
            return resultReturn;
        }

        public async Task<StaffTitleDto> GetById(int id)
        {
            var staffTitle = await GetStaffTitleAndCheckExsit(id);
            return _mapper.Map<StaffTitleDto>(staffTitle);
        }

        public Task Update(int id, UpdateStaffTitleRequest request)
        {
            throw new NotImplementedException();
        }
        private async Task<StaffTitle> GetStaffTitleAndCheckExsit(int id)
        {
            var staffTitle = await _dbContext.StaffTitles.FindAsync(id);
            if (staffTitle is null)
                throw new EntityNotFoundException(nameof(StaffTitle), $"Id = {id}");
            return staffTitle;
        }
    }
}
