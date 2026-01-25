using HRM_BE.Core.Data.Company;
using HRM_BE.Core.Data.Payroll_Timekeeping.Payroll;
using HRM_BE.Core.Data.Staff;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HRM_BE.Core.Data.Payroll_Timekeeping.Shift
{
    //Tên bảng chấm công tổng  hợp
    public class SummaryTimesheetName:EntityBase<int>
    {
        public int? OrganizationId { get; set; } // Tên đơn vị, ví dụ: "CÔNG TY CÔNG NGHỆ VÀ TRUYỀN THÔNG..."
        //public string? Location { get; set; } // Vị trí áp dụng chấm công, ví dụ: "Tất cả vị trí".
        public string? TimekeepingSheetName { get; set; } // Tên bảng chấm công, ví dụ: "Bảng chấm công tháng 10".

        public TimekeepingMethod? TimekeepingMethod { get; set; } = HRM_BE.Core.Data.Payroll_Timekeeping.Shift.TimekeepingMethod.Hour; // Hình thức chấm công, ví dụ: "Theo giờ".

        public virtual ICollection<SummaryTimesheetNameStaffPosition> SummaryTimesheetNameStaffPositions { get; set; }// Vị trí áp dụng chấm công, ví dụ: "Tất cả vị trí".

        public virtual ICollection<SummaryTimesheetNameDetailTimesheetName> SummaryTimesheetNameDetailTimesheetNames { get; set; }// 1 Bảng công công tổng hợp gồm nhiều bảng chấm công chi tiết

        public virtual Organization Organization { get; set; }

        public virtual ICollection<SummaryTimesheetNameEmployeeConfirm>? SummaryTimesheetNameEmployeeConfirms { get; set; }
        
        public virtual ICollection<PayrollSummaryTimesheet> PayrollSummaryTimesheets { get; set; }

    }

    //Bảng nối giữa Tên bảng chấm công chi tiết và vị trí công việc
    public class SummaryTimesheetNameStaffPosition
    {
        public int? StaffPositionId { get; set; }
        public int? SummaryTimesheetNameId { get; set; }

        public virtual StaffPosition StaffPosition { get; set; }
        public virtual SummaryTimesheetName SummaryTimesheetName { get; set; }

    }

    public class SummaryTimesheetNameDetailTimesheetName
    { 
        public int? SummaryTimesheetNameId { get; set; }

        public int? DetailTimesheetNameId { get; set; }

        public virtual SummaryTimesheetName SummaryTimesheetName{ get; set; }

        public virtual DetailTimesheetName DetailTimesheetName{ get; set; }
    }



}
