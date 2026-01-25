using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HRM_BE.Core.Models.Payroll_Timekeeping.LeaveRegulation
{
    public class ApplyOrganizationListDto
    {
        public int Id { get; set; }
        public string OrganizationName { get; set; } // Tên đơn vị
        public bool IsForAllEmployees { get; set; } // Áp dụng cho tất cả nhân viên
        public double AllowableRadius { get; set; } // Bán kính chấm công cho phép
    }
}
