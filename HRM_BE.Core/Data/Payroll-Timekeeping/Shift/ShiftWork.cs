using HRM_BE.Core.Data.Company;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HRM_BE.Core.Data.Payroll_Timekeeping.Shift
{
    //Phân ca
    public class ShiftWork:EntityBase<int>
    {
        public string? ShiftTableName { get; set; } // Tên bảng phân ca.
        public int? ShiftCatalogId { get; set; } // Mã ca làm việc.
        public int? OrganizationId { get; set; } // Đơn vị áp dụng phân ca.
        public DateTime? StartDate { get; set; } // Ngày bắt đầu áp dụng.
        public DateTime? EndDate { get; set; } // Ngày kết thúc áp dụng.
        public RecurrenceType? RecurrenceType { get; set; }= HRM_BE.Core.Data.Payroll_Timekeeping.Shift.RecurrenceType.Week; // Loại lặp lại (ví dụ: Tuần).
        public int? RecurrenceCount { get; set; } // Số lần lặp lại.
        public int? TotalWork { get ; set; } // tổng số công chuẩn
        public bool? IsMonday { get; set; } // Áp dụng cho Thứ Hai.
        public bool? IsTuesday { get; set; } // Áp dụng cho Thứ Ba.
        public bool? IsWednesday { get; set; } // Áp dụng cho Thứ Tư.
        public bool? IsThursday { get; set; } // Áp dụng cho Thứ Năm.
        public bool? IsFriday { get; set; } // Áp dụng cho Thứ Sáu.
        public bool? IsSaturday { get; set; } // Áp dụng cho Thứ Bảy.
        public bool? IsSunday { get; set; } // Áp dụng cho Chủ Nhật.
        public ApplyObject? ApplyObject { get; set; }//Đối tượng áp dụng


        public virtual ShiftCatalog ShiftCatalog { get; set; }

        public virtual Organization Organization { get; set; }

    }


    // Loại lặp lại 
    public enum RecurrenceType
    {
        Day,
        Week,
        Month,
        Year,
        None
    }

    //Đối tượng áp dụng
    public enum ApplyObject
    {
        IsOrganizationTarget, // Áp dụng cho cả cơ cấu tổ chức.
        IsIndividualTarget,// Áp dụng cho danh sách nhân viên.
        Both//Cả 2
    }





    //public bool? IsOrganizationTarget { get; set; } // Áp dụng cho cả cơ cấu tổ chức.
    //public bool? IsIndividualTarget { get; set; } // Áp dụng cho danh sách nhân viên.
    //public int? StandardWorkingHours { get; set; } // Số giờ công chuẩn.



}
