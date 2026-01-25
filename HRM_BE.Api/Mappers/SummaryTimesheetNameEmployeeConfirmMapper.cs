using AutoMapper;
using HRM_BE.Core.Data.Payroll_Timekeeping.Shift;
using HRM_BE.Core.Models.SumaryTimeSheet;

namespace HRM_BE.Api.Mappers
{
    public class SummaryTimesheetNameEmployeeConfirmMapper:Profile
    {
        public SummaryTimesheetNameEmployeeConfirmMapper()
        {
            CreateMap<SummaryTimesheetNameEmployeeConfirm, SummaryTimesheetNameSummaryTimesheetNameEmployeeConfirmDto>().ReverseMap();
            CreateMap<SummaryTimesheetNameEmployeeConfirm, GetSummaryTimesheetNameEmployeeConfirmRequest>().ReverseMap();
            CreateMap<SummaryTimesheetNameEmployeeConfirm, CreateSummaryTimesheetNameEmployeeConfirmRequest>().ReverseMap();

        }
    }
}
