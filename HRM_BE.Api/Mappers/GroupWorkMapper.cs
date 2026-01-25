using AutoMapper;
using HRM_BE.Core.Data.Task;
using HRM_BE.Core.Models.GroupWorkModel;

namespace HRM_BE.Api.Mappers
{
    public class GroupWorkMapper:Profile
    {
        public GroupWorkMapper()
        {
            CreateMap<CreateGroupWorkRequest, GroupWork>();
            CreateMap<UpdateGroupWorkRequest, GroupWork>();
            CreateMap<GroupWork, GroupWorkDto>().ReverseMap();

        }
    }
}
