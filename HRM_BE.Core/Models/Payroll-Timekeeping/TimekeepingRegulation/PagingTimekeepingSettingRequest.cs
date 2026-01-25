using HRM_BE.Core.Models.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HRM_BE.Core.Models.Payroll_Timekeeping.TimekeepingRegulation
{
    public class PagingTimekeepingSettingRequest : PagingRequest
    {
        public int? OrganizationId { get; set; }

    }
}
