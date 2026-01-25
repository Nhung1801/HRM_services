using AutoMapper;
using HRM_BE.Core.Data.Company;
using HRM_BE.Core.Exceptions;
using HRM_BE.Core.IRepositories;
using HRM_BE.Core.ISeedWorks;
using HRM_BE.Core.Models.Common;
using HRM_BE.Core.Models.Company;
using HRM_BE.Data.SeedWorks;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.Design;
using HRM_BE.Core.Constants.System;
using HRM_BE.Core.Models.Content.Banner;
using Microsoft.EntityFrameworkCore;
using HRM_BE.Core.Helpers;
using HRM_BE.Core.Extension;
using Microsoft.Identity.Client;


namespace HRM_BE.Data.Repositories
{
    class CompanyRepository : RepositoryBase<Company, int>, ICompanyRepository
    {
        private readonly IMapper _mapper;
        public CompanyRepository(HrmContext context, IMapper mapper, IHttpContextAccessor httpContextAccessor) : base(context, httpContextAccessor)
        {
            _mapper = mapper;
        }
        public async Task<CompanyDto> Create(CreateCompanyRequest request)
        {
            var companyEntity = _mapper.Map<Company>(request);
            string companyCode = $"TCTSMO{StringHelper.GenerateRandomCode(3)}";
            companyEntity.CompanyCode = companyCode;
            await CreateAsync(companyEntity);
            var companyReturn = _mapper.Map<CompanyDto>(companyEntity);

            var oranizationType = new OrganizationType
            {
                CompanyId = companyEntity.Id,
                OrganizationTypeName = "Tổng Công Ty",
            };
            await _dbContext.OrganizationTypes.AddAsync(oranizationType);
            await _dbContext.SaveChangesAsync();
            var organization = new Organization
            {
                OrganizationCode = companyCode,
                OrganizationName = request.FullName,
                Abbreviation = request.Abbreviation,
                CompanyId = companyEntity.Id,
                OrganizationTypeId = (int)oranizationType.Id,
                BusinessRegistrationCode = companyEntity.BusinessRegistrationCode,
                IssuingAuthority = companyEntity.IssuingAuthority,
                OrganizationAddress = companyEntity.Address,
                OrganizationTypeName = oranizationType.OrganizationTypeName

            };
            await _dbContext.Organizations.AddAsync(organization);
            await _dbContext.SaveChangesAsync();
            return companyReturn;
        }

        public async Task Delete(int companyId)
        {
            var companyEntity = await GetCompanyAndCheckExist(companyId);

            companyEntity.IsDeleted = true;
            await UpdateAsync(companyEntity);
        }

        public async Task<CompanyDto> GetById(int companyId)
        {
            var companyEntity = await GetCompanyAndCheckExist(companyId);
            var companyReturn = _mapper.Map<CompanyDto>(companyEntity);
            return companyReturn;
        }

        public async Task<PagingResult<CompanyDto>> GetPaging(string? keyWord, string? sortBy, string? orderBy, int pageIndex = 1, int pageSize = 10)
        {
            var query = _dbContext.Companies.AsNoTracking().Where(c => c.IsDeleted == false);
            if (!string.IsNullOrEmpty(keyWord))
            {
                query = query.Where(c => c.CompanyCode == keyWord || c.Abbreviation.Contains(keyWord));
            }

            // Áp dụng sắp xếp
            query = query.ApplySorting(sortBy, orderBy);
            // Tính tổng số bản ghi
            int total = await query.CountAsync();
            // Áp dụng phân trang
            query = query.ApplyPaging(pageIndex, pageSize);

            var data = await _mapper.ProjectTo<CompanyDto>(query).ToListAsync();

            var result = new PagingResult<CompanyDto>(data, pageIndex, pageSize, sortBy, orderBy, total);

            return result;
        }

        public async Task<CompanyDto> GetTree(int companyId)
        {
            var result = _dbContext.Companies
            .Include(x => x.Organizations) // Lấy tất cả các tổ chức của công ty
            .ThenInclude(o => o.OrganizationType) // Lấy loại tổ chức của các tổ chức con
            .Where(x => x.Id == companyId); // Lọc theo công ty ID

            return _mapper.Map<CompanyDto>(result);
        }

        public async Task Update(int companyId, UpdateCompanyRequest request)
        {
            var companyEntity = await GetCompanyAndCheckExist(companyId);
            await UpdateAsync(_mapper.Map(request, companyEntity));
        }

        private async Task<Company> GetCompanyAndCheckExist(int companyId)
        {
            var company = await _dbContext.Companies.FindAsync(companyId);
            if (company is null)
                throw new EntityNotFoundException(nameof(Company), $"Id = {companyId}");
            return company;
        }
    }
}
