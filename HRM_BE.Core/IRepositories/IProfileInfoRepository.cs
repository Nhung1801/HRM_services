using HRM_BE.Core.Data;
using HRM_BE.Core.Data.ProfileEntity;
using HRM_BE.Core.ISeedWorks;
using HRM_BE.Core.Models.ProfileInfoModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HRM_BE.Core.IRepositories
{
    public interface IProfileInfoRepository:IRepositoryBase<ProfileInfo,int>
    {
        Task<ProfileInfoDto> GetById(int profileId);
        Task<ProfileInfoDto> Create(CreateProfileInfoRequest request);
        Task Delete(int profileId);
        Task Update(int profileId ,UpdateProfileInfoRequest request);
        Task UpdateV2(int profileInfoId, UpdateProfileInfoRequestV2 request);
    }
}
