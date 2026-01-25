using HRM_BE.Core.Data.Payroll_Timekeeping.LeaveRegulation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HRM_BE.Core.Models.Payroll_Timekeeping.LeaveRegulation
{
    public class HolidayDto
    {
        public int Id { get; set; }
        public int? OrganizationId { get; set; } // tổ chức công ty

        public string? Name { get; set; }//Tên 

        public bool? IsACompensatoryDayOff { get; set; } = false;// Là ngày nghỉ bù

        public DateTime FromDate { get; set; }// Ngày bắt đầu

        public DateTime ToDate { get; set; } //Ngày kết thúc

        public string? Note { get; set; } //Ghi chú

        public ApplyObject ApplyObject { get; set; } // ĐỐi tượng áp dụng

    }

    public class GetDayHolidayRequest()
    {
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public int EmployeeId { get; set; }

     }
    //từng ngày nghỉ 1
    public class HolidayByDayDto
    {
        public int Id { get; set; }
        public int? OrganizationId { get; set; } // tổ chức công ty

        public string? Name { get; set; }//Tên 

        public bool? IsACompensatoryDayOff { get; set; } = false;// Là ngày nghỉ bù

        public DateTime Date { get; set; }//Ngày

        public string? Note { get; set; } //Ghi chú

        public ApplyObject ApplyObject { get; set; } // ĐỐi tượng áp dụng

    }


}
