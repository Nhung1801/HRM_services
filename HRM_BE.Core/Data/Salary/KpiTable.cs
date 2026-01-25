using HRM_BE.Core.Data.Company;
using HRM_BE.Core.Data.Staff;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HRM_BE.Core.Data.Salary
{
    public  class KpiTable:EntityBase<int>
    {
        public string? NameKpiTable { get; set; }   
        public int? OrganizationId { get; set; }
        public DateTime? FromDate { get; set; }   
        public DateTime? ToDate { get; set; }
        public int? StaffPositionId { get; set; }
        //public virtual StaffPosition? StaffPosition { get; set; }
        public virtual List<KpiTablePosition>? KpiTablePositions { get; set; }
        public virtual Organization? Organization { get; set; }
        //public virtual Employee? Employee { get; set; }
        //dsfdsfjd
        public List<KpiTableDetail>? KpiTableDetails { get; set; }
    }
}
