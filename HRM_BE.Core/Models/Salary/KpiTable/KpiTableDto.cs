using HRM_BE.Core.Data.Staff;
using HRM_BE.Core.Models.Organization;
using HRM_BE.Core.Models.Salary.KpiTableDetail;
using HRM_BE.Core.Models.Staff;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HRM_BE.Core.Models.Salary.KpiTable
{
    public class KpiTableDto
    {
        public int Id { get; set; }
        public string? NameKpiTable { get; set; }
        public int? OrganizationId { get; set; }
        public string? OrganizationName { get; set; }
        public DateTime? FromDate { get; set; }
        public DateTime? ToDate { get; set; }

        //public int? StaffPositionId { get; set; }
        //public virtual OrganizationDto? Organization { get; set; }
        public virtual List<KpiTablePositionDto>? KpiTablePositions { get; set; }
        public virtual List<KpiTableDetailDto>? KpiTableDetails { get; set; }

    }
}
