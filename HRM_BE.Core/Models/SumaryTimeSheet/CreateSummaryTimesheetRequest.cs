using HRM_BE.Core.Data.Payroll_Timekeeping.Shift;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HRM_BE.Core.Models.SumaryTimeSheet
{
    public class CreateSummaryTimesheetRequest
    {
        public int? OrganizationId { get; set; } // Tên đơn vị, ví dụ: "CÔNG TY CÔNG NGHỆ VÀ TRUYỀN THÔNG..."
        public string? TimekeepingSheetName { get; set; } // Tên bảng chấm công, ví dụ: "Bảng chấm công tháng 10".
        public TimekeepingMethod? TimekeepingMethod { get; set; } = HRM_BE.Core.Data.Payroll_Timekeeping.Shift.TimekeepingMethod.Hour;// Hình thức chấm công, ví dụ: "Theo giờ".
        public virtual List<CreateSummaryTimeSheetDetailTimeSheetRequest> SummaryTimesheetNameDetailTimesheetNames { get; set; }
        public virtual List<CreateSummaryTimesheetNameStaffPositionRequest> SummaryTimesheetNameStaffPositions { get; set; }
    }
}
