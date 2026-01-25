using HRM_BE.Core.Data.Staff;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HRM_BE.Core.Models.Work
{
    public class ApprovalEmployeeDto
    {
        public string? Description { get; set; } // Mô tả
        public bool? IsApprove { get; set; } // Trạng thái xác nhận
        public string? RejectReason { get; set; } // Lý do từ chối
        public int? EmployeeId { get; set; }
        public int? ApprovalId { get; set; }
        public virtual ReportWorkDto Employee { get; set; }
    }
}
