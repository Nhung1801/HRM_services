using HRM_BE.Core.Models.Staff;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HRM_BE.Core.Models.Salary.KpiTable
{
    public class UpdateKpiTablePositionRequest
    {
        public int StaffPositionId { get; set; } // FK đến Position
    }
}
