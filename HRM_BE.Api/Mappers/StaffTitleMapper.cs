using AutoMapper;
using HRM_BE.Core.Data.Staff;
using HRM_BE.Core.Models.Staff;

namespace HRM_BE.Api.Mappers
{
    public class StaffTitleMapper:Profile
    {
        public StaffTitleMapper()
        {
            CreateMap<CreateStaffTitleRequest, StaffTitle>();
            CreateMap<UpdateStaffTitleRequest, StaffTitle>();
            CreateMap<StaffTitleDto, StaffTitle>().ReverseMap();
        }
    }
}
