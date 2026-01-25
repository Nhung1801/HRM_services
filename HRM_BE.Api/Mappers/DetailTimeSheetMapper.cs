using AutoMapper;
using HRM_BE.Core.Data.Payroll_Timekeeping.Shift;
using HRM_BE.Core.Data.Staff;
using HRM_BE.Core.Models.DetailTimeSheet;

namespace HRM_BE.Api.Mappers
{
    public class DetailTimeSheetMapper:Profile
    {
        public DetailTimeSheetMapper()
        {
            CreateMap<CreateDetailTimeSheetRequest, DetailTimesheetName>();
            CreateMap<UpdateDetailTimeSheetRequest,DetailTimesheetName>()
            .ForMember(dest => dest.DetailTimesheetNameStaffPositions, opt => opt.Ignore());
            CreateMap<CreateDetailTimeSheetStaffPositionRequest,DetailTimesheetNameStaffPosition>();
            CreateMap<DetailTimesheetName,DetailTimeSheetDto>().ReverseMap();
            CreateMap<DetailTimesheetNameStaffPosition,GetDetailTimeSheetStaffPositionDto>()
                .ForMember(dest => dest.PositionName , opt => opt.MapFrom(src => src.StaffPosition.PositionName))
                .ForMember(dest => dest.Id , opt => opt.MapFrom(src => src.StaffPosition.Id))
                .ForMember(dest => dest.PositionCode , opt => opt.MapFrom(src => src.StaffPosition.PositionCode))
                .ReverseMap();
            CreateMap<Employee, GetDetailTimesheetWithEmployeeDto>();
        }
    }
}
