using HRM_BE.Core.Data;
using HRM_BE.Core.Data.Company;
using HRM_BE.Core.ISeedWorks;
using HRM_BE.Core.Models.Organization;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HRM_BE.Data.Repositories
{
    public interface IOrganizationTypeRepository:IRepositoryBase<OrganizationType,int>
    {
        Task<OrganizationTypeDto> Create(CreateOrganizationTypeRequest request);
        Task Update(int id,UpdateOrganizationTypeRequest request);
        Task Delete(int id);
        Task<OrganizationTypeDto> GetById(int id);
        Task<List<OrganizationTypeDto>> GetAll();
    }
}
