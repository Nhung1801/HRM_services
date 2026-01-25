using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HRM_BE.Core.Models.Work
{
    public class UpdateApprovalEmployeeRequest
    {
        public string? Description { get; set; } // Mô tả
        public bool? IsApprove { get; set; } // Trạng thái xác nhận
        public string? RejectReason { get; set; } // Lý do từ chối
    }
}
