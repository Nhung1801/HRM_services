using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HRM_BE.Core.Models.Salary.KpiTable
{
    public class CreateKpiTablePositionRequest
    {
        public int StaffPositionId { get; set; } // FK đến Position
        //public int OrganizationId { get; set; } // FK đến Organization
    }
}
