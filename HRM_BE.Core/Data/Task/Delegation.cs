using HRM_BE.Core.Data.Staff;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HRM_BE.Core.Data.Task
{
    // Bảng ủy quyền dự án
    public class Delegation : EntityBase<int>
    {
        public int? EmployeeDelegationId { get; set; } // Nhân viên ủy quyền
        public DateTime? StartDate { get; set; } // Thời gian ủy quyền từ ngày
        public DateTime? EndDate { get; set; } // Thời gian ủy quyền đến ngày

        public virtual Employee EmployeeDelegation { get; set; }

        public virtual ICollection<DelegationEmployee> DelegationEmployees { get; set; }// Danh sách nhân viên nhận ủy quyền
        public virtual ICollection<DelegationProject> DelegationProjects { get; set; }// Danh sách dự án ủy quyền

    }

    public class DelegationEmployee
    {
        public int EmployeeId { get; set; }
        public int DelegationId { get; set; }


        public virtual Employee Employee { get; set; }
        public virtual Delegation Delegation { get; set; }
    }

    public class DelegationProject
    {
        public int ProjectId { get; set; }
        public int DelegationId { get; set; }


        public virtual Project Project { get; set; }
        public virtual Delegation Delegation { get; set; }
    }
}
