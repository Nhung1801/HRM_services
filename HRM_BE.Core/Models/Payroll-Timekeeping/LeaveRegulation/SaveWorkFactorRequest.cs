using HRM_BE.Core.Data.Payroll_Timekeeping.LeaveRegulation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HRM_BE.Core.Models.Payroll_Timekeeping.LeaveRegulation
{
    public class SaveWorkFactorRequest
    {
        public int? HolidayId { get; set; }
        public int? Year { get; set; } // Năm áp dụng
        public decimal? Factor { get; set; } // Hệ số công
        public bool IsFixed { get; set; } = false; // Cố định hệ số công giữa các năm 
    }
}
