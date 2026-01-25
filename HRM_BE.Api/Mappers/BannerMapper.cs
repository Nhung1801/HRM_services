using HRM_BE.Core.Data.Content;
using HRM_BE.Core.Models.Content.Banner;
using AutoMapper;

namespace HRM_BE.Api.Mappers
{
    public class BannerMapper : Profile
    {
        public BannerMapper()
        {
            CreateMap<Banner, CreateBannerRequest>();
            CreateMap<CreateBannerRequest, Banner>();
            CreateMap<EditBannerRequest, Banner>();
            CreateMap<Banner, EditBannerRequest>();
            CreateMap<Banner, BannerDto>();
            CreateMap<BannerDto, Banner>();
        }
    }

}
