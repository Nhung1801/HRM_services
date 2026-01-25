using HRM_BE.Core.Data.Task;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HRM_BE.Core.Models.Work
{
    public class ApprovalWorkDto
    {
        public int? ApproverId { get; set; } // Người phê duyệt cho công việc
        public DateTime? ApproveDate { get; set; } // Thời gian phê duyệt
        public string? FileUrl { set; get; } // Đường dẫn file
        public string? Description { get; set; } // Mô tả
        public bool? IsApprove { get; set; } // Trạng thái xác nhận
        public string? RejectReason { get; set; } // Lý do từ chối
        public ICollection<ApprovalEmployeeDto> ApprovalEmployees { get; set; }
    }
}
