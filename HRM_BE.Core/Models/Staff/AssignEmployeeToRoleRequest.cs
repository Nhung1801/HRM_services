using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HRM_BE.Core.Models.Staff
{
    public class AssignEmployeeToRoleRequest
    {
        public int EmployeeId { get; set; }
        public List<string>? RoleNames { get; set; }

    }
}

