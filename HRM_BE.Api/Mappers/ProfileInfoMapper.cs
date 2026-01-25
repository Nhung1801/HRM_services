using AutoMapper;
using HRM_BE.Core.Data.ProfileEntity;
using HRM_BE.Core.Data.Staff;
using HRM_BE.Core.Models.ProfileInfoModel;

namespace HRM_BE.Api.Mappers
{
    public class ProfileInfoMapper:Profile
    {
        public ProfileInfoMapper()
        {
            CreateMap<CreateProfileInfoRequest, ProfileInfo>();
            CreateMap<UpdateProfileInfoRequest,ProfileInfo>();
            CreateMap<ProfileInfo, ProfileInfoDto>().ReverseMap();
            CreateMap<UpdateProfileInfoRequestV2, ProfileInfo>()
                .ForMember(dest => dest.Employee, opt => opt.Ignore());
            CreateMap<UpdateProfileInfoRequestV2, Employee>();
        }
    }
}
