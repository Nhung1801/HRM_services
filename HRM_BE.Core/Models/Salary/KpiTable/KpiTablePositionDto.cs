using HRM_BE.Core.Data.Staff;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HRM_BE.Core.Models.Salary.KpiTable
{
    public class KpiTablePositionDto
    {
        public int StaffPositionId { get; set; } // FK đến Position
        public string? PositionName { get; set; }
        //public virtual StaffPosition? StaffPosition { get; set; }
    }
}
