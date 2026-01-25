using AutoMapper;
using HRM_BE.Core.Data.Task;
using HRM_BE.Core.Models.Tag;

namespace HRM_BE.Api.Mappers
{
    public class TagMapper:Profile
    {
        public TagMapper()
        {
            CreateMap<CreateTagRequest, Tag>();
            CreateMap<UpdateTagRequest, Tag>();
            CreateMap<Tag, TagDto>().ReverseMap();
            
        }
    }
}
