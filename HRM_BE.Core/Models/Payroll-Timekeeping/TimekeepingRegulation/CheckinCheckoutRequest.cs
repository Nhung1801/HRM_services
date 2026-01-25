using HRM_BE.Core.Data.Payroll_Timekeeping.TimekeepingRegulation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HRM_BE.Core.Models.Payroll_Timekeeping.TimekeepingRegulation
{
    public class CheckinCheckoutRequest
    {
        public int EmployeeId { get; set; }
        public double Latitude { get; set; }    
        public double Longitude { get; set; }
        public TimekeepingGPSType Type { get; set; } // "Check-In" hoặc "Check-Out"
    }
}
