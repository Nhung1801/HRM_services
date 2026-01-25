using AutoMapper;
using HRM_BE.Core.Data.Staff;
using HRM_BE.Core.Models.Staff;
using Microsoft.EntityFrameworkCore.Query.SqlExpressions;

namespace HRM_BE.Api.Mappers
{
    public class GroupPositionMapper:Profile
    {
        public GroupPositionMapper()
        {
            CreateMap<GroupPosition, GroupPositionDto>().ReverseMap();  
            CreateMap<CreateGroupPositionRequest, GroupPosition>();
            CreateMap<UpdateGrouptPositonRequest,GroupPosition>();
        }
    }
}
