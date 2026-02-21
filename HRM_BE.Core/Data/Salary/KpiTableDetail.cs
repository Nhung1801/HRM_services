using HRM_BE.Core.Data.Staff;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HRM_BE.Core.Data.Salary
{
    public class KpiTableDetail:EntityBase<int>
    {
        public int? KpiTableId { get; set; }
        public int? EmployeeId { get; set; }
        public string? EmployeeCode { get; set; }   
        public string? EmployeeName { get; set; }
        public double? CompletionRate { get; set; }
        public double? Bonus { get; set; }

        // Doanh thu theo nhân viên (nhập theo KPI table)
        public decimal? Revenue { get; set; }

        // Cho phép nhập tay hoa hồng (override)
        public bool? IsCommissionManual { get; set; }
        public decimal? CommissionManualAmount { get; set; }

        public virtual KpiTable? KpiTable { get; set; }
        public virtual Employee? Employee { get; set; }
    }
}
