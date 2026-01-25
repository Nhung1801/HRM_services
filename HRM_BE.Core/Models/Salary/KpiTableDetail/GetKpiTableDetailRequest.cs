using HRM_BE.Core.Models.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HRM_BE.Core.Models.Salary.KpiTableDetail
{
    public class GetKpiTableDetailRequest: PagingRequest
    {
        public string? EmployeeId { get; set; }
        public int? KpiTableId { get; set; }
        public string? EmployeeCode { get; set; }
        public string? EmployeeName { get; set; }
        public double? CompletionRate { get; set; }
        public double? Bonus { get; set; }
        public int? OrganizationId { get; set; }
        public int? StaffPositionId { get; set; }
    }
}
