using HRM_BE.Core.Data.Payroll_Timekeeping.LeaveRegulation;
using HRM_BE.Core.Data.Payroll_Timekeeping.TimekeepingRegulation;
using HRM_BE.Core.Models.Payroll_Timekeeping.LeaveRegulation;
using HRM_BE.Core.Models.Payroll_Timekeeping.TimekeepingRegulation;
using HRM_BE.Core.Models.SumaryTimeSheet;

namespace HRM_BE.Api.Mappers
{
    public class TimesheetMapper : AutoMapper.Profile
    {
        public TimesheetMapper()
        {
            CreateMap<Timesheet, TimesheetDto>().ReverseMap();
            CreateMap<UpdateTimesheetRequest, Timesheet>();
            CreateMap<Timesheet, PagingTimesheetRequest>().ReverseMap();
            CreateMap<Timesheet, SummaryTimesheetNameEmployeeConfirmTimeSheetDto>().ReverseMap();

        }
    }
}
