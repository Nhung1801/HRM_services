using HRM_BE.Core.Models.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HRM_BE.Core.Models.Salary.KpiTable
{
    public class GetKpiTableRequest: PagingRequest
    {
        public string? NameKpiTable { get; set; }
        public int? OrganizationId { get; set; }
        public DateTime? FromDate { get; set; }
        public DateTime? ToDate { get; set; }
        public int? StaffPositionId { get; set; }
    }
}
