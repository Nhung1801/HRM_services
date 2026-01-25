using HRM_BE.Core.Data.Payroll_Timekeeping.Payroll;
using HRM_BE.Core.Data.Payroll_Timekeeping.Shift;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HRM_BE.Core.Models.Payroll_Timekeeping.Payroll
{
    public class PayrollDto
    {
        public int Id { get; set; }
        public int? OrganizationId { get; set; } // Tổ chức công ty
        public string? OrganizationName { get; set; } // Tên tổ chức
        public string? PayrollName { get; set; } // Tên bảng lương
        public PayrollStatus PayrollStatus { get; set; } // Trạng thái
        public PayrollConfirmationStatus PayrollConfirmationStatus { get; set; } // Trạng thái xác nhận
        public DateTime? CreatedAt { get; set; }
        public DateTime? UpdatedAt { get; set; }

        // Các bảng chấm công tổng hợp liên kết với bảng lương
        public List<PayrollSummaryTimesheetDto> PayrollSummaryTimesheets { get; set; }
        // Các vị trí công việc liên kết với bảng lương
        public List<PayrollStaffPositionDto> PayrollStaffPositions { get; set; }
    }

    public class PayrollSummaryTimesheetDto
    {
        public int PayrollId { get; set; }
        public int SummaryTimesheetNameId { get; set; }
        public string SummaryTimesheetName { get; set; } // Tên bảng chấm công
    }

    public class PayrollStaffPositionDto
    {
        public int? PayrollId { get; set; }
        public int? StaffPositionId { get; set; }
        public string PositionName { get; set; } // Tên vị trí công việc
    }
}
