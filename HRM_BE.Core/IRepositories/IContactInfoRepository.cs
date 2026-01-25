using HRM_BE.Core.Data.ProfileEntity;
using HRM_BE.Core.ISeedWorks;
using HRM_BE.Core.Models.Profile.ContactInfo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HRM_BE.Core.IRepositories
{
    public interface IContactInfoRepository:IRepositoryBase<ContactInfo,int>
    {
        Task<ContactInfoDto> Create(CreateContactInfoRequest request);
        Task Update(int id,UpdateContactInfoRequest request);
        Task Delete(int id);
        Task<ContactInfoDto> GetById(int id);

    }
}
