using HRM_BE.Core.Data.Payroll_Timekeeping.Shift;
using HRM_BE.Core.Models.ShiftCatalog;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HRM_BE.Core.Models.ShiftWork
{
    public class ShiftWorkDto
    {
        public int Id { get; set; }
        public string? ShiftTableName { get; set; } // Tên bảng phân ca.
        public int? ShiftCatalogId { get; set; } // Mã ca làm việc.
        public int? OrganizationId { get; set; } // Đơn vị áp dụng phân ca.
        public DateTime? StartDate { get; set; } // Ngày bắt đầu áp dụng.
        public DateTime? EndDate { get; set; } // Ngày kết thúc áp dụng.
        public RecurrenceType? RecurrenceType { get; set; } // Loại lặp lại (ví dụ: Tuần).
        public int? TotalWork { get; set; } // tổng số công chuẩn
        public int? RecurrenceCount { get; set; } // Số lần lặp lại.
        public bool? IsMonday { get; set; } // Áp dụng cho Thứ Hai.
        public bool? IsTuesday { get; set; } // Áp dụng cho Thứ Ba.
        public bool? IsWednesday { get; set; } // Áp dụng cho Thứ Tư.
        public bool? IsThursday { get; set; } // Áp dụng cho Thứ Năm.
        public bool? IsFriday { get; set; } // Áp dụng cho Thứ Sáu.
        public bool? IsSaturday { get; set; } // Áp dụng cho Thứ Bảy.
        public bool? IsSunday { get; set; } // Áp dụng cho Chủ Nhật.
        public ApplyObject? ApplyObject { get; set; }//Đối tượng áp dụng


        public virtual ShiftCatalogDto ShiftCatalog { get; set; }

        public virtual GetOrganizationShiftWorkDto Organization { get; set; }
    }





    public class ShiftScheduleDto
    {
        public DateTime Date { get; set; }
        public List<ShiftCatalogScheduleDto> Shifts { get; set; }
    }

    public class ShiftCatalogScheduleDto
    {
        public int Id { get; set; }
        public string Code { get; set; }
        public string Name { get; set; }
        public TimeSpan? StartTime { get; set; }
        public TimeSpan? EndTime { get; set; }
    }


}
