using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HRM_BE.Core.Models.Staff
{
    public class GetOrganizationForEmployeeDto
    {
        public int Id { get; set; }
        public string? OrganizationName { get; set; } 
    }
}
