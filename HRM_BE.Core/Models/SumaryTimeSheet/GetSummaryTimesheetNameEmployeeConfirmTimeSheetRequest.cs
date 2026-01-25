using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HRM_BE.Core.Models.SumaryTimeSheet
{
    public class GetSummaryTimesheetNameEmployeeConfirmTimeSheetRequest
    {
        public required int EmployeeId { get; set; } //Id nhân viên

        public DateTime? StartDate { get; set; }


        public DateTime? EndDate { get; set; }

    }
}
