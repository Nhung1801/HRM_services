using HRM_BE.Core.Data.Company;
using HRM_BE.Core.ISeedWorks;
using HRM_BE.Core.Models.Common;
using HRM_BE.Core.Models.Company;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HRM_BE.Core.IRepositories
{
    public interface ICompanyRepository:IRepositoryBase<Company,int>
    {
        Task<CompanyDto> Create(CreateCompanyRequest request);
        Task Update(int companyId, UpdateCompanyRequest request);
        Task Delete(int companyId);
        Task<CompanyDto> GetById(int companyId);
        Task<CompanyDto> GetTree(int companyId);

        Task<PagingResult<CompanyDto>> GetPaging(string? keyWord, string? sortBy, string? orderBy, int pageIndex = 1, int pageSize = 10);
        
    }
}
