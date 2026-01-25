using HRM_BE.Core.Data.Payroll_Timekeeping.Shift;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HRM_BE.Core.Models.DetailTimeSheet
{
    public class CreateDetailTimeSheetRequest
    {
        public int? OrganizationId { get; set; } // Tên đơn vị, ví dụ: "CÔNG TY CÔNG NGHỆ VÀ TRUYỀN THÔNG..."
        //public string? Location { get; set; } // Vị trí áp dụng chấm công, ví dụ: "Tất cả vị trí".
        public string? TimekeepingSheetName { get; set; } // Tên bảng chấm công, ví dụ: "Bảng chấm công tháng 10".
        public DateTime? StartDate { get; set; } // Ngày bắt đầu thời gian chấm công.
        public DateTime? EndDate { get; set; } // Ngày kết thúc thời gian chấm công.
        public TimekeepingMethod? TimekeepingMethod { get; set; } // Hình thức chấm công, ví dụ: "Theo giờ".
        public virtual List<CreateDetailTimeSheetStaffPositionRequest> DetailTimesheetNameStaffPositions { get; set; }
    }
}
