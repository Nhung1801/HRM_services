using HRM_BE.Core.Data.Payroll_Timekeeping.Payroll;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HRM_BE.Core.Models.Payroll_Timekeeping.Payroll
{
    public class UpdatePayrollRequest
    {
        public int? OrganizationId { get; set; } // Tổ chức công ty
        public int? SummaryTimesheetNameId { get; set; } // Chấm công tổng hợp
        public string? PayrollName { get; set; } // Tên bảng lương
        public PayrollStatus PayrollStatus { get; set; } // Trạng thái
        public PayrollConfirmationStatus PayrollConfirmationStatus { get; set; } // Trạng thái xác nhận
    }
}
