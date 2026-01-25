using HRM_BE.Core.Models.Project;
using HRM_BE.Core.Models.Staff;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HRM_BE.Core.Models.Delegation
{
    public class DelegationDto
    {
        public int Id { get; set; }
        public int? EmployeeDelegationId { get; set; } // Nhân viên ủy quyền
        public DateTime? StartDate { get; set; } // Thời gian ủy quyền từ ngày
        public DateTime? EndDate { get; set; } // Thời gian ủy quyền đến ngày
        public EmployeeDelegationDto EmployeeDelegation { get; set; } // Thông tin nhân viên ủy quyền
        public List<EmployeeDelegationDto> Employees { get; set; } // Danh sách nhân viên nhận ủy quyền
        public List<ProjectDto> Projects { get; set; } // Danh sách dự án ủy quyền

    }

    public class EmployeeDelegationDto
    {
        public int Id { get; set; }
        public int? OrganizationId { get; set; }
        public int? CompanyId { get; set; }
        public string EmployeeCode { get; set; }
        public string LastName { get; set; }
        public string FirstName { get; set; }
        public DateTime? DateOfBirth { get; set; }
        public string? AvatarUrl { get; set; }
    }

}
