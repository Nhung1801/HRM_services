using HRM_BE.Core.Data.Staff;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HRM_BE.Core.Data.Payroll_Timekeeping.Shift
{
    //bảng xác nhận chấm công
    public class SummaryTimesheetNameEmployeeConfirm:EntityBase<int>
    {
        public int? SummaryTimesheetNameId { get; set; }

        public int? EmployeeId { get; set; }

        public SummaryTimesheetNameEmployeeConfirmStatus? Status { get; set; }= SummaryTimesheetNameEmployeeConfirmStatus.None;

        public string? Note { get; set; }

        public DateTime? Date { get; set; }

        public virtual SummaryTimesheetName SummaryTimesheetName { get; set; }

        public virtual Employee Employee { get; set; }
    }


    public enum SummaryTimesheetNameEmployeeConfirmStatus
    {
        None,
        Pending,
        Reject,
        Confirm,
        SendedNotConfirm
    }

}
