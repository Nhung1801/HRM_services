using HRM_BE.Core.Data.Payroll_Timekeeping.Payroll;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HRM_BE.Core.Models.Payroll_Timekeeping.Payroll
{
    public class CreatePayrollInquiryRequest
    {
        public int? PayrollDetailId { get; set; } // ID của bảng lương chi tiết
        public string? Content { get; set; } // Nội dung thắc mắc
        public InquiryStatus Status { get; set; } = InquiryStatus.Pending; // Trạng thái thắc mắc
    }
}
