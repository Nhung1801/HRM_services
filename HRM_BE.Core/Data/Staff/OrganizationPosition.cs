using HRM_BE.Core.Data.Company;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HRM_BE.Core.Data.Staff
{
    public class OrganizationPosition 
    {
        public int? StaffPositionId { get; set; } // FK đến Position
        public int OrganizationId { get; set; } // FK đến Organization
        public virtual StaffPosition StaffPosition { get; set; }
        public virtual Organization Organization { get; set; }
    }
}
