using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HRM_BE.Core.Models.Department
{
    public class CreateDepartmentRequest
    {
        public int? OrganizationId { get; set; }
        public string Name { get; set; }
        public string? Description { get; set; }

        public List<EmployeeRoleMapping> EmployeeRoleMappings { get; set; } // Nhân viên và vai trò trong phòng ban
    }

    public class EmployeeRoleMapping
    {
        public int EmployeeId { get; set; }
        public int DepartmentRoleId { get; set; }
    }

}
