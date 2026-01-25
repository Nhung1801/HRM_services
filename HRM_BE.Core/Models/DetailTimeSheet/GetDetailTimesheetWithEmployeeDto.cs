using HRM_BE.Core.Data.Official_Form;
using HRM_BE.Core.Models.Payroll_Timekeeping.LeaveRegulation;
using HRM_BE.Core.Models.Payroll_Timekeeping.TimekeepingRegulation;
using HRM_BE.Core.Models.Profile;
using HRM_BE.Core.Models.SumaryTimeSheet;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HRM_BE.Core.Models.DetailTimeSheet
{
    public class GetDetailTimesheetWithEmployeeDto
    {
        public int Id { get; set; }
        public string EmployeeCode { get; set; }
        public string? LastName { get; set; }
        public string? FirstName { get; set; }
        public List<ConfirmTimeSheetDto> Timesheets { get; set; }
        public List<PermittedLeaveDto>? PermittedLeaves { get; set; }
        public List<HolidayDto> Holidays { get; set; }
        public bool IsOffical { get; set; }
    }
}
