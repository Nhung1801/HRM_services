using HRM_BE.Core.Data.Company;
using HRM_BE.Core.Data.Staff;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HRM_BE.Core.Data.Salary
{
    public  class KpiTablePosition
    {
        public int? StaffPositionId { get; set; } // FK đến Position
        public int KpiTableId { get; set; } // FK đến KpiTable
        public virtual StaffPosition? StaffPosition { get; set; }

        public virtual KpiTable? KpiTable { get; set; }
    }
}
