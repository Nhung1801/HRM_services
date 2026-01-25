using HRM_BE.Core.Data.Staff;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HRM_BE.Core.Data.Payroll_Timekeeping.LeaveRegulation
{
    //Bảng xem số lượng ngày nghỉ còn lại của nhân viên
    public class TypeOfLeaveEmployee:EntityBase<int>
    {
        public int? TypeOfLeaveId { get; set; }

        public int? EmployeeId { get; set; }

        public double? DaysRemaining {  get; set; }// số ngày nghỉ ngày còn lại

        //public int? MaximumNumberOfDayOff { get; set; } //Số ngày nghỉ tối đa

        public int? Year { get; set; }// Năm 

        public virtual TypeOfLeave TypeOfLeave { get; set; }

        public virtual Employee Employee { get; set; }
    }
}
