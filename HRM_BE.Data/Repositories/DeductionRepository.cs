using AutoMapper;
using HRM_BE.Core.Data.Profile;
using HRM_BE.Core.Data.ProfileEntity;
using HRM_BE.Core.Exceptions;
using HRM_BE.Core.IRepositories;
using HRM_BE.Core.Models.ProfileInfoModel;
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
    public class DeductionRepository:RepositoryBase<Deduction,int>,IDeductionRepository
    {
        private readonly IMapper _mapper;
        public DeductionRepository(HrmContext context,IMapper mapper,IHttpContextAccessor httpContextAccessor):base(context,httpContextAccessor)
        {
            _mapper = mapper;
        }

        public async Task<DeductionDto> Create(CreateDeductionRequest request)
        {
            var entity = _mapper.Map<Deduction>(request);
            await CreateAsync(entity);
            return _mapper.Map<DeductionDto>(entity);
        }

        public async Task Delete(int id)
        {
            var entity = await GetDeductionAndCheckExsit(id);
            entity.IsDeleted = true;
            await UpdateAsync(entity);
        }

        public async Task<List<DeductionDto>> GetAll()
        {
            var result = await  _dbContext.Deductions.Where( d => d.IsDeleted == false).ToListAsync();
            return _mapper.Map<List<DeductionDto>>(result);
        }

        public async Task<DeductionDto> GetById(int id)
        {
            var entity = await GetDeductionAndCheckExsit(id);
            return _mapper.Map<DeductionDto>(entity);
        }

        public async Task<List<DeductionDto>> GetDeductionByEmployeeId(int employeeId)
        {
            var entity = await _dbContext.Deductions.Where( d => d.EmployeeId == employeeId).ToListAsync();
            return _mapper.Map<List<DeductionDto>>(entity);
        }

        public async Task Update(int id, UpdateDeductionRequest request)
        {
            var entity = await GetDeductionAndCheckExsit(id);
            _mapper.Map(request,entity);
            await UpdateAsync(entity);
        }

        private async Task<Deduction> GetDeductionAndCheckExsit(int id)
        {
            var deduction = await _dbContext.Deductions.FindAsync(id);
            if (deduction is null)
                throw new EntityNotFoundException(nameof(deduction), $"Id = {id}");
            return deduction;
        }
        
    }
}
