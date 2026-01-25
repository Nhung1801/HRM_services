using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HRM_BE.Core.Models.Payroll_Timekeeping.LeaveRegulation
{
    public class TypeOfLeaveEmployeeDto
    {
        public int Id { get; set; }

        public int? TypeOfLeaveId { get; set; }

        public int? EmployeeId { get; set; }

        public double? DaysRemaining { get; set; }// số ngày nghỉ ngày còn lại

        public int? Year { get; set; }// Năm 
    }
}
