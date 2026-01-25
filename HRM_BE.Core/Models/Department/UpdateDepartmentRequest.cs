using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HRM_BE.Core.Models.Department
{
    public class UpdateDepartmentRequest
    {
        public int Id { get; set; }
        public int? OrganizationId { get; set; }
        public string Name { get; set; }
        public string? Description { get; set; }
        public List<EmployeeRoleMapping> EmployeeRoleMappings { get; set; } // Thêm cấu trúc này
    }
}
