using HRM_BE.Core.Data.Payroll_Timekeeping.Shift;
using HRM_BE.Core.Models.Common;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HRM_BE.Core.Models.SumaryTimeSheet
{
    public class GetSummaryTimesheetNameEmployeeConfirmRequest:PagingRequest
    {
        public int? SummaryTimesheetNameId { get; set; }

        public int? EmployeeId { get; set; }

        public DateTime? StartDate { get; set; } // Ngày bắt đầu thời gian chấm công.

        public DateTime? EndDate { get; set; } // Ngày kết thúc thời gian chấm công.

        public SummaryTimesheetNameEmployeeConfirmStatus? Status { get; set; } = SummaryTimesheetNameEmployeeConfirmStatus.None;

        public string? Note { get; set; }

        public DateTime? Date { get; set; }// Ngày duyệt


    }

    public class GetSummaryTimesheetNameEmployeeConfirmByEmployeeRequest : PagingRequest
    {
        //[Required]
        public required int EmployeeId { get; set; }

        public int? SummaryTimesheetNameId { get; set; }

        public DateTime? StartDate { get; set; } // Ngày bắt đầu thời gian chấm công.

        public DateTime? EndDate { get; set; } // Ngày kết thúc thời gian chấm công.

        public SummaryTimesheetNameEmployeeConfirmStatus? Status { get; set; } = SummaryTimesheetNameEmployeeConfirmStatus.None;

        public string? Note { get; set; }

        public DateTime? Date { get; set; }// Ngày duyệt


    }
}
