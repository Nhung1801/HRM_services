using HRM_BE.Core.Data.Company;
using HRM_BE.Core.Data.Staff;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HRM_BE.Core.Data.Payroll_Timekeeping.Shift
{
    //Tên bảng chấm công chi tiết
    public class DetailTimesheetName:EntityBase<int>
    {
        public int? OrganizationId { get; set; } // Tên đơn vị, ví dụ: "CÔNG TY CÔNG NGHỆ VÀ TRUYỀN THÔNG..."
        //public string? Location { get; set; } // Vị trí áp dụng chấm công, ví dụ: "Tất cả vị trí".
        public string? TimekeepingSheetName { get; set; } // Tên bảng chấm công, ví dụ: "Bảng chấm công tháng 10".
        public DateTime? StartDate { get; set; } // Ngày bắt đầu thời gian chấm công.
        public DateTime? EndDate { get; set; } // Ngày kết thúc thời gian chấm công.
        public TimekeepingMethod? TimekeepingMethod { get; set; } // Hình thức chấm công, ví dụ: "Theo giờ".
        public bool? IsLock { get; set; } = false;

        public virtual List<DetailTimesheetNameStaffPosition> DetailTimesheetNameStaffPositions { get; set; }// Vị trí áp dụng chấm công, ví dụ: "Tất cả vị trí".
        public virtual Organization Organization { get; set; }

        //public virtual StaffPosition
    }


    //Hình thức chấm công
    public enum TimekeepingMethod
    {
        Hour,//giờ
        Day//ngày
    }


    //Bảng nối giữa Tên bảng chấm công chi tiết và vị trí công việc
    public class DetailTimesheetNameStaffPosition
    {
        public int? StaffPositionId { get; set; }
        public int? DetailTimesheetNameId { get; set; }

        public virtual StaffPosition StaffPosition { get; set; }

        public virtual DetailTimesheetName DetailTimesheetName { get; set; }

    }

}
