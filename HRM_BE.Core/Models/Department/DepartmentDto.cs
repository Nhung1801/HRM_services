using HRM_BE.Core.Data.Task;
using HRM_BE.Core.Models.Project;
using HRM_BE.Core.Models.Staff;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HRM_BE.Core.Models.Department
{
    public class DepartmentDto
    {
        public int Id { get; set; }
        public int? OrganizationId { get; set; } // Công ty
        public string? Name { get; set; } // Tên phòng ban
        public string? Description { get; set; } // Mô tả
        public List<EmployeeDto> Employees { get; set; } // Danh sách thông tin nhân viên
        public List<ProjectDepartmentDto> Projects { get; set; } // Danh sách dự án của phòng ban


    }

    public class ProjectDepartmentDto
    {
        public int Id { get; set; }
        public int? DepartmentId { get; set; }
        public string Name { get; set; } // Tên dự án
        public string Description { get; set; } // Mô tả
        public ProjectType ProjectType { get; set; } // Kiểu dự án
        public DateTime? StartDate { get; set; } // Ngày bắt đầu
        public DateTime? EndDate { get; set; } // Ngày kết thúc

    }
}
