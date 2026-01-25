using HRM_BE.Core.Data.Payroll_Timekeeping.Payroll;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HRM_BE.Core.Models.Payroll_Timekeeping.Payroll
{
    public class UpdateSalaryComponentRequest
    {
        public int? OrganizationId { get; set; } // Tổ chức công ty
        public string? ComponentName { get; set; } // Tên thành phần
        public string? ComponentCode { get; set; } // Mã thành phần
        public Nature Nature { get; set; } // Tính chất
        public Characteristic Characteristic { get; set; } // Thuộc tính
        public string? ValueFormula { get; set; } // Công thức giá trị
        public string? Description { get; set; } // Mô tả

        // Trạng thái (Đang theo dõi hoặc ngừng theo dõi)
        public Status Status { get; set; }
    }
}
