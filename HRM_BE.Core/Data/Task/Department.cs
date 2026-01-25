using HRM_BE.Core.Data.Company;
using HRM_BE.Core.Data.Staff;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HRM_BE.Core.Data.Task
{
    // Bảng phòng ban
    public class Department : EntityBase<int>
    {
        public int? OrganizationId { get; set; } // Công ty
        public string? Name { get; set; } // Tên phòng ban
        public string? Description { get; set; } // Mô tả


        public virtual ICollection<DepartmentEmployee> DepartmentEmployees { get; set; } 

        public virtual ICollection<Project> Projects { get; set; }

        public virtual Organization Organization { get; set; }
    }

    public class DepartmentEmployee
    {
        public int EmployeeId { get; set; }
        public int DepartmentId { get; set; }
        public int DepartmentRoleId { get; set; }

        public virtual Employee Employee { get; set; }
        public virtual Department Department { get; set; }

        public virtual DepartmentRole DepartmentRole { get; set; }
    }
}
