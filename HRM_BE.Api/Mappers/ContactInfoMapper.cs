using AutoMapper;
using HRM_BE.Core.Data.ProfileEntity;
using HRM_BE.Core.Models.Profile.ContactInfo;
namespace HRM_BE.Api.Mappers
{
    public class ContactInfoMapper: AutoMapper.Profile
    {
        public ContactInfoMapper()
        {
            CreateMap<CreateContactInfoRequest, ContactInfo>();
            CreateMap<UpdateContactInfoRequest, ContactInfo>();
            CreateMap<ContactInfo, ContactInfoDto>().ReverseMap();
        }
    }
}
