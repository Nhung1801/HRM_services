using HRM_BE.Core.Models.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HRM_BE.Core.Models.Payroll_Timekeeping.LeaveRegulation
{
    public class PagingHolidayRequest : PagingRequest
    {
        public int? OrganizationId { get; set; }
        public string? Name { get; set; }
    }
}
