using HRM_BE.Core.Data.Payroll_Timekeeping.Payroll;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HRM_BE.Core.Models.Payroll_Timekeeping.Payroll
{
    public class PayrollInquiryDto
    {
        public int Id { get; set; }
        public int? PayrollDetailId { get; set; } // ID của bảng lương chi tiết
        public int? EmployeeId { get; set; } // Id của nhân viên
        public string? Content { get; set; } // Nội dung thắc mắc
        public string? EmployeeName { get; set; } // Tên nhân viên
        public DateTime? TimeSent { get; set; } // Thời gian gửi thắc mắc của nhân viên về bảng lương
        public InquiryStatus Status { get; set; } = InquiryStatus.Pending; // Trạng thái thắc mắc
    }
}
