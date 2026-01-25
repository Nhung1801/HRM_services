using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HRM_BE.Core.Models.Payroll_Timekeeping.TimekeepingRegulation
{
    public class TimesheetDurationLateOrEarlyDto
    {
        public int EmployeeId { get; set; }

        public double? LateDurationCount { get; set; } = 0; // Đi muộn (số lần)

        public double? EarlyLeaveDurationCount { get; set; } = 0; // Về sớm (số lần)

        public double? LateOrEarlyLeaveDurationCount { get; set; } = 0; // Về sớm hoặc đi muộn trong 1 ca (số lần)

        public double? LateDuration { get; set; } = 0; // Đi muộn (phút)

        public double? EarlyLeaveDuration { get; set; } = 0; // Về sớm (phút)
    }
}
