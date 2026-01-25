using HRM_BE.Core.Models.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HRM_BE.Core.Models.Payroll_Timekeeping.Payroll
{
    public class PagingPayrollRequest : PagingRequest
    {
        public int? OrganizationId { get; set; }
        public string? Name { get; set; }
        public int? EmployeeId { get; set; }
        public int? Year { get; set; }
    }
}
