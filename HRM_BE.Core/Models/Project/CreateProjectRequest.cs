using HRM_BE.Core.Data.Task;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HRM_BE.Core.Models.Project
{
    public class CreateProjectRequest
    {
        public int? DepartmentId { get; set; }
        public int? OrganizationId { get; set; } // Công ty
        public string Name { get; set; }
        public string? Description { get; set; }
        //public ProjectType ProjectType { get; set; }
        public DateTime? StartDate { get; set; }
        public DateTime? EndDate { get; set; }
        public List<ProjectEmployeeRoleMapping> ProjectEmployeeRoleMappings { get; set; }
    }

    public class ProjectEmployeeRoleMapping
    {
        public int EmployeeId { get; set; }
        public int ProjectRoleId { get; set; }
    }


}
