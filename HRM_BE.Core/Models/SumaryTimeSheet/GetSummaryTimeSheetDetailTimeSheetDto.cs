using HRM_BE.Core.Data.Payroll_Timekeeping.Shift;
using HRM_BE.Core.Models.DetailTimeSheet;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HRM_BE.Core.Models.SumaryTimeSheet
{
    public class GetSummaryTimeSheetDetailTimeSheetDto
    {
        public int? DetailTimesheetNameId { get; set; }

        public virtual DetailTimeSheetDto DetailTimesheetName { get; set; }
    }
}
