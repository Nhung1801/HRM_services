using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HRM_BE.Core.Models.Department
{
    public class GetAllDepartmentRequest
    {
        public string? KeyWord { get; set; }

        public int? OrganizationId { get; set; } // Công ty


    }
}
