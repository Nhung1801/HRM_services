using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HRM_BE.Core.Models.ShiftCatalog
{
    public class ShiftCatalogDto
    {
        public int Id { get; set; } 
        public int? OrganizationId { get; set; }// Id công ty tổ chức trực thuộc
        public string? Code { get; set; }//Mã
        public string? Name { get; set; }//Tên
        public TimeSpan? StartTime { get; set; }//Giờ bắt đầu
        public TimeSpan? EndTime { get; set; }//Giờ tan 
        public bool? IsTimeChecked { get; set; }// Cho phép chấm vào
        public TimeSpan? StartTimeIn { get; set; }//Thời gian bắt đầu chấm vào
        public TimeSpan? EndTimeIn { get; set; }//Thời gian kết thúc chấm vào
        public bool? IsBreak { get; set; }// Cho phép chấm ra
        public TimeSpan? StartTimeOut { get; set; } //Thời gian bắt đầu chấm ra
        public TimeSpan? EndTimeOut { get; set; }//Thời gian kết thúc chấm ra
        public bool? TakeABreak { get; set; }//Cho phép nghỉ giữa ca
        public TimeSpan? StartTakeABreak { get; set; } //Thời gian bắt đầu nghỉ giữa
        public TimeSpan? EndTakeABreak { get; set; }//Thời gian kết thúc nghỉ giữa
        public double? WorkingHours { get; set; } // Số giờ làm việc 
        public int? WorkingDays { get; set; } // Số ngày làm việc
        public double? RegularMultiplier { get; set; } // Hệ số ngày thường.
        public double? HolidayMultiplier { get; set; } // Hệ số ngày lễ.
        public double? LeaveDaysMultiplier { get; set; } // Hệ số ngày nghỉ phép.
        public bool? DeductIfNoStartTime { get; set; } // Trừ công nếu không có giờ vào.
        public bool? DeductIfNoEndTime { get; set; } // Trừ công nếu không có giờ ra.
        public bool? AllowEarlyLeave { get; set; } // Cho phép đi về sớm.
        public int? AllowedEarlyLeaveMinutes { get; set; } // Số phút được phép về sớm.
        public bool? AllowLateArrival { get; set; } // Cho phép đi muộn.
        public int? AllowedLateArrivalMinutes { get; set; } // Số phút được phép đi muộn.
        public bool? AllowOvertime { get; set; } // Cho phép làm thêm giờ.
        public GetOrganizationShiftCatalogDto Organization { get; set; }
    }
}
