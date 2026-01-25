using HRM_BE.Core.Data.Staff;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HRM_BE.Core.Data.Task
{
    // Bảng phê duyệt
    public class Approval : EntityBase<int>
    {
        public int? WorkId { get; set; } // Người phê duyệt cho công việc
        public DateTime? ApproveDate { get; set; } // Thời gian phê duyệt
        public string? FileUrl { set; get; } // Đường dẫn file
        public string? Description { get; set; } // Mô tả
        public bool? IsApprove { get; set; } // Trạng thái xác nhận
        public string? RejectReason { get; set; } // Lý do từ chối
        public virtual ICollection<ApprovalEmployee> ApprovalEmployees { get; set; }
        public virtual Work Work { get; set; }
    }
    public class ApprovalEmployee : EntityBase<int> // chi tiết phê duyệt
    {
        //public DateTime? ApproveDate { get; set; } // Thời gian phê duyệt
        //public string? FileUrl { set; get; } // Đường dẫn file
        public string? Description { get; set; } // Mô tả
        public bool? IsApprove { get; set; } // Trạng thái xác nhận
        public string? RejectReason { get; set; } // Lý do từ chối
        public int? EmployeeId { get; set; }
        public int? ApprovalId { get; set; }
        public virtual Employee Employee { get; set; }
        public virtual Approval Approval { get; set; }
    }
}
