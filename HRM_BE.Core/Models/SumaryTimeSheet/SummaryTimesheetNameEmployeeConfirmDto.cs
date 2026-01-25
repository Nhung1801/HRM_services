using HRM_BE.Core.Data.Payroll_Timekeeping.Shift;
using HRM_BE.Core.Data.Staff;
using HRM_BE.Core.Models.ShiftWork;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HRM_BE.Core.Models.SumaryTimeSheet
{
    public class SummaryTimesheetNameEmployeeConfirmDto
    {
        public int Id { get; set; }

        public int? OrganizationId { get; set; } // Tên đơn vị, ví dụ: "CÔNG TY CÔNG NGHỆ VÀ TRUYỀN THÔNG..."

        public DateTime? StartDate { get; set; } // Ngày bắt đầu thời gian chấm công.

        public DateTime? EndDate { get; set; } // Ngày kết thúc thời gian chấm công.

        public string? TimekeepingSheetName { get; set; } // Tên bảng chấm công, ví dụ: "Bảng chấm công tháng 10".

        public TimekeepingMethod? TimekeepingMethod { get; set; } // Hình thức chấm công, ví dụ: "Theo giờ".

        public SummaryTimesheetNameSummaryTimesheetNameEmployeeConfirmDto? SummaryTimesheetNameEmployeeConfirm { get; set; }

        //public virtual List<GetSummaryTimesheetNameStaffPositionDto> SummaryTimesheetNameStaffPositions { get; set; }

        //public virtual List<GetSummaryTimeSheetDetailTimeSheetDto> SummaryTimesheetNameDetailTimesheetNames { get; set; }

        //public virtual GetOrganizationShiftWorkDto Organization { get; set; }




    }

    public class SummaryTimesheetNameSummaryTimesheetNameEmployeeConfirmDto
    {
        public int Id { get; set; }

        public int? SummaryTimesheetNameId { get; set; }

        public int? EmployeeId { get; set; }

        public SummaryTimesheetNameEmployeeConfirmStatus? Status { get; set; } = SummaryTimesheetNameEmployeeConfirmStatus.None;

        public string? Note { get; set; }

        public DateTime? Date { get; set; }

    }
}
