using HRM_BE.Core.Data.Payroll_Timekeeping.Payroll;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HRM_BE.Core.Models.Payroll_Timekeeping.Payroll
{
    public class CreatePayrollRequest
    {
        public int? OrganizationId { get; set; } // Tổ chức công ty
        public string? PayrollName { get; set; } // Tên bảng lương
        public PayrollStatus PayrollStatus { get; set; } // Trạng thái
        public List<int>? StaffPositionIds { get; set; } // Vị trí công việc
        public PayrollConfirmationStatus PayrollConfirmationStatus { get; set; } // Trạng thái xác nhận
        public List<int>? SummaryTimesheetNameIds { get; set; } // Danh sách ID bảng chấm công tổng hợp
    }
}
