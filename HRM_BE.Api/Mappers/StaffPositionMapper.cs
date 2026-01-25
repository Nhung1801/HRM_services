using AutoMapper;
using HRM_BE.Core.Data.Staff;
using HRM_BE.Core.Models.Staff;

namespace HRM_BE.Api.Mappers
{
    public class StaffPositionMapper:Profile
    {
        public StaffPositionMapper()
        {
            CreateMap<CreateStaffPositionRequest, StaffPosition>();
            CreateMap<StaffPosition,StaffPositionDto>().ReverseMap();
            CreateMap<UpdateStaffPositionRequest, StaffPosition>();
        }
    }
}
