using HRM_BE.Core.Data.Staff;
using HRM_BE.Core.Models.Work;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HRM_BE.Core.Models.Approval
{
    public class CreateApprovalRequest
    {
        public DateTime? ApproveDate { get; set; } // Thời gian phê duyệt
        public string? FileUrl { set; get; } // Đường dẫn file
        public string? Description { get; set; } // Mô tả
        public bool? IsApprove { get; set; } // Trạng thái xác nhận
        public string? RejectReason { get; set; } // Lý do từ chối
        public List<CreateApprovalEmployeeRequest> CreateApprovalEmployeeRequests { get; set; }
    }
}
