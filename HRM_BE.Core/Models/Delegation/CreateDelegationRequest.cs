using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HRM_BE.Core.Models.Delegation
{
    public class CreateDelegationRequest
    {
        public int? EmployeeDelegationId { get; set; } // Nhân viên ủy quyền
        public DateTime? StartDate { get; set; } // Thời gian ủy quyền từ ngày
        public DateTime? EndDate { get; set; } // Thời gian ủy quyền đến ngày
        public List<int> EmployeeIds { get; set; } // Danh sách nhân viên nhận ủy quyền
        public List<int> ProjectIds { get; set; } // Danh sách dự án ủy quyền
    }

}
