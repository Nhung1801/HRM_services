using HRM_BE.Core.Data.Task;
using HRM_BE.Core.Models.Department;
using HRM_BE.Core.Models.Staff;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HRM_BE.Core.Models.Project
{
    public class ProjectDto
    {
        public int Id { get; set; }
        public int? DepartmentId { get; set; }
        public string Name { get; set; } // Tên dự án
        public string Description { get; set; } // Mô tả
        public ProjectType ProjectType { get; set; } // Kiểu dự án
        public DateTime? StartDate { get; set; } // Ngày bắt đầu
        public DateTime? EndDate { get; set; } // Ngày kết thúc
        public DepartmentDto Department { get; set; } // Thông tin phòng ban
        public List<EmployeeDto> Employees { get; set; } // Danh sách thông tin nhân viên
    }
}
