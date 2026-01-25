using AutoMapper;
using HRM_BE.Core.Data.Payroll_Timekeeping.Shift;
using HRM_BE.Core.Data.Staff;
using HRM_BE.Core.Models.DetailTimeSheet;
using HRM_BE.Core.Models.SumaryTimeSheet;

namespace HRM_BE.Api.Mappers
{
    public class SummaryTimeSheetMapper : Profile
    {
        public SummaryTimeSheetMapper()
        {
            CreateMap<CreateSummaryTimesheetRequest, SummaryTimesheetName>();
            CreateMap<UpdateSummaryTimeSheetRequest, SummaryTimesheetName>();
            CreateMap<CreateSummaryTimesheetNameStaffPositionRequest, SummaryTimesheetNameStaffPosition>();
            CreateMap<CreateSummaryTimeSheetDetailTimeSheetRequest, SummaryTimesheetNameDetailTimesheetName>();

            CreateMap<SummaryTimesheetNameDetailTimesheetName, GetSummaryTimeSheetDetailTimeSheetDto>();

            CreateMap<SummaryTimesheetNameStaffPosition, GetSummaryTimesheetNameStaffPositionDto>()
                .ForMember(dest => dest.PositionName, opt => opt.MapFrom(s => s.StaffPosition.PositionName))
                .ForMember(dest => dest.PositionCode, opt => opt.MapFrom(s => s.StaffPosition.PositionCode))
                .ForMember(dest => dest.Id, opt => opt.MapFrom(s => s.StaffPosition.Id));


            CreateMap<SummaryTimesheetName, SummaryTimeSheetDto>().ReverseMap();

            CreateMap<SummaryTimesheetName, SummaryTimesheetNameEmployeeConfirmDto>().ReverseMap();


        }
    }
}
