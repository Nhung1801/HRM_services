using HRM_BE.Core.Data.Task;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HRM_BE.Core.Models.Project
{
    public class UpdateProjectRequest
    {
        public int Id { get; set; }
        public int? DepartmentId { get; set; }
        public string Name { get; set; }
        public string? Description { get; set; }
        //public ProjectType ProjectType { get; set; }
        public DateTime? StartDate { get; set; }
        public DateTime? EndDate { get; set; }
        public List<ProjectEmployeeRoleMapping> ProjectEmployeeRoleMappings { get; set; }
    }



}
