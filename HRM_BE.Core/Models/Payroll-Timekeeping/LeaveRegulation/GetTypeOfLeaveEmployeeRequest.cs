using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HRM_BE.Core.Models.Payroll_Timekeeping.LeaveRegulation
{
    public class GetTypeOfLeaveEmployeeRequest
    {
        public int? EmployeeId { get; set; }

        public int? TypeOfLeaveId { get; set; }

        public int? Year { get; set; }
    }
}
