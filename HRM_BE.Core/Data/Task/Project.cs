using HRM_BE.Core.Data.Staff;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HRM_BE.Core.Data.Task
{
    // Bảng dự án
    public class Project : EntityBase<int>
    {
        public int? DepartmentId { get; set; }
        public int? OrganizationId { get; set; } // Công ty
        public string? Name { get; set; } // Tên dự án
        public string? Description { get; set; } // Mô tả
        public ProjectType ProjectType { get; set; } // Kiểu dự án
        public DateTime? StartDate { get; set; } // Ngày bắt đầu
        public DateTime? EndDate { get; set; } // Ngày kết thúc


        public virtual ICollection<ProjectEmployee> ProjectEmployees { get; set; }    
        public virtual Department Department { get; set; }
    }

    public enum ProjectType
    {
        In, // Trong phòng ban 
        Out // Ngoài phòng ban
    }

    public class ProjectEmployee
    {
        public int ProjectId { get; set; }
        public int EmployeeId { get; set; }
        public int ProjectRoleId { get; set; }
        public virtual Project Project { get; set; }
        public virtual Employee Employee { get; set; }
        public virtual ProjectRole ProjectRole { get;set; }
    }
}
