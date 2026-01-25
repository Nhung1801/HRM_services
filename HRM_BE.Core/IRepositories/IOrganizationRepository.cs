using HRM_BE.Core.Data.Company;
using HRM_BE.Core.ISeedWorks;
using HRM_BE.Core.Models.Common;
using HRM_BE.Core.Models.Organization;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HRM_BE.Core.IRepositories
{
    public interface IOrganizationRepository:IRepositoryBase<Organization,int>
    {
        Task<OrganizationDto> Create(CreateOrganizationRequest request);
        //Task<OrganizationDto> CreateV2(CreateOrganizationRequest request);
        //Task<OrganizationSelectDto> GetSelectV2(int id);

        Task Update(int id ,UpdateOrganizationRequest request);
        Task Delete(int id);
        Task<OrganizationDto> GetById (int id);
        Task<OrganizationSelectDto> GetSelect(int organizationId);
        Task<PagingResult<GetOrganizationDto>> GetAll(string? keyWord,string? sortBy,string? orderBy, int pageIndex = 1, int pageSize = 10);

        Task<PagingResult<GetOrganizationDto>> Paging(string? keyWord, string? sortBy, string? orderBy,
            int pageIndex = 1, int pageSize = 10);
        int GetRootOrganizationId(int childOrganizationId);

    }
}
