using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HRM_BE.Core.Models.Department
{
    public class AddOrRemoveEmployeeFromDepartment
    {
        public int EmployeeId { get; set; }

        public int DepartmentId { get; set; }
    }
}
