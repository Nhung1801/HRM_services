using HRM_BE.Core.Data.Payroll_Timekeeping.Shift;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HRM_BE.Core.Models.SumaryTimeSheet
{
    public class CreateSummaryTimesheetNameEmployeeConfirmRequest
    {
        public int? SummaryTimesheetNameId { get; set; }

        public int? EmployeeId { get; set; }

        public SummaryTimesheetNameEmployeeConfirmStatus? Status { get; set; } = SummaryTimesheetNameEmployeeConfirmStatus.None;

        public string? Note { get; set; }

        public DateTime? Date { get; set; }


    }

    public class CreateSummaryTimesheetNameEmployeeConfirmMultipleRequest
    {
        public int? SummaryTimesheetNameId { get; set; }

        public List<int>? EmployeeIds { get; set; }

        public SummaryTimesheetNameEmployeeConfirmStatus? Status { get; set; } = SummaryTimesheetNameEmployeeConfirmStatus.None;

        public string? Note { get; set; }

        public DateTime? Date { get; set; }


    }
}
