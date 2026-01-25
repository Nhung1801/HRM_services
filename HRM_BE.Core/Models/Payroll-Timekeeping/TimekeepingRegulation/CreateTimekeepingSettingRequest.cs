using HRM_BE.Core.Data.Payroll_Timekeeping.TimekeepingRegulation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HRM_BE.Core.Models.Payroll_Timekeeping.TimekeepingRegulation
{
    public class CreateTimekeepingSettingRequest
    {
        public int? OrganizationId { get; set; } // tổ chức công ty

        public AllowApplication? AllowApplication { get; set; }
        public TimekeepingType? TimekeepingType { get; set; }

    }
}
