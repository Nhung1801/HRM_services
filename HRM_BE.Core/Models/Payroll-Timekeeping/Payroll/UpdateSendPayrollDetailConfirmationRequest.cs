using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HRM_BE.Core.Models.Payroll_Timekeeping.Payroll
{
    public class UpdateSendPayrollDetailConfirmationRequest
    {
        public List<int> PayrollDetailIds { get; set; } // Danh sách Id bảng lương chi tiết
        public DateTime ResponseDeadline { get; set; } // Hạn phản hồi của nhân viên
    }
}
