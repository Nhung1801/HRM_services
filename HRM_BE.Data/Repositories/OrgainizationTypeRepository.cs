using AutoMapper;
using HRM_BE.Core.Data.Company;
using HRM_BE.Core.Exceptions;
using HRM_BE.Core.Models.Organization;
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
    public class OrgainizationTypeRepository:RepositoryBase<OrganizationType,int>, IOrganizationTypeRepository
    {
        private readonly IMapper _mapper;
        public OrgainizationTypeRepository(HrmContext context, IMapper mapper, IHttpContextAccessor httpContextAccessor) : base(context, httpContextAccessor)
        {
            _mapper = mapper;
        }
        public async Task<OrganizationTypeDto> Create(CreateOrganizationTypeRequest request)
        {
            var entity = _mapper.Map<OrganizationType>(request);
            await CreateAsync(entity);
            return _mapper.Map<OrganizationTypeDto>(entity);
        }

        public async Task Delete(int id)
        {
            var entity = await GetOrganizationAndCheckExist(id);
            await DeleteAsync(entity);
        }
        public async Task Update(int id,UpdateOrganizationTypeRequest request)
        {
            var entity = await GetOrganizationAndCheckExist(id);
            await UpdateAsync(_mapper.Map(request,entity));
        }

        public async Task<OrganizationTypeDto> GetById(int id)
        {
            var entity = await GetOrganizationAndCheckExist(id);
            return _mapper.Map<OrganizationTypeDto>(entity);
        }

        private async Task<OrganizationType> GetOrganizationAndCheckExist(int organizationId)
        {
            var organization = await _dbContext.OrganizationTypes.FindAsync(organizationId);
            if (organization is null)
                throw new EntityNotFoundException(nameof(OrganizationType), $"Id = {organizationId}");
            return organization;
        }

        public async Task<List<OrganizationTypeDto>> GetAll()
        {
            var result = await _dbContext.OrganizationTypes.ToListAsync();
            var resultReturn = _mapper.Map<List<OrganizationTypeDto>>(result);
            return resultReturn;
        }
    }
}
