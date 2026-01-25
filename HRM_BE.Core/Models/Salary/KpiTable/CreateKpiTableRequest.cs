using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HRM_BE.Core.Models.Salary.KpiTable
{
    public class CreateKpiTableRequest
    {
        public string? NameKpiTable { get; set; }
        public int? OrganizationId { get; set; }
        public DateTime? FromDate { get; set; }
        public DateTime? ToDate { get; set; }
        //public int? StaffPositionId { get; set; }
        public List<CreateKpiTablePositionRequest>? KpiTablePositions { get; set; }
    }

    //public class CreateKpiTablePositionRequest
    //{
    //    public int StaffPositionId { get; set; } // FK đến Organization

    //}
}
