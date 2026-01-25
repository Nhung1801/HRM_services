using HRM_BE.Core.Data.Company;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HRM_BE.Core.Data.Payroll_Timekeeping.LeaveRegulation
{
    //Bảng ngày nghỉ lễ 
    public class Holiday:EntityBase<int>
    {
        public int? OrganizationId { get; set; } // tổ chức công ty

        public string? Name { get; set; }//Tên ngày nghỉ

        public bool? IsACompensatoryDayOff { get; set; }=false;// Là ngày nghỉ bù

        public DateTime FromDate { get; set; }// Ngày bắt đầu

        public DateTime ToDate { get; set; } //Ngày kết thúc

        public string? Note { get; set; } //Ghi chú

        public ApplyObject ApplyObject { get; set; } // ĐỐi tượng áp dụng

        public virtual Organization Organization { get; set; }
    }

    // Bảng hệ số công theo từng ngày lễ
    public class WorkFactor : EntityBase<int>
    {
        public int? HolidayId { get; set; }
        public int? Year { get; set; } // Năm áp dụng
        public decimal? Factor { get; set; } // Hệ số công
        public bool IsFixed { get; set; } = false; // Cố định hệ số công giữa các năm 
        public virtual Holiday Holiday { get; set; }
    }
}
