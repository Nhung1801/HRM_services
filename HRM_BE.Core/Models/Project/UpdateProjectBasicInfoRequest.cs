using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HRM_BE.Core.Models.Project
{
    public class UpdateProjectBasicInfoRequest
    {
        public int Id { get; set; }
        public int? DepartmentId { get; set; }
        public string Name { get; set; } // Tên dự án
        public string Description { get; set; } // Mô tả dự án
        public DateTime? StartDate { get; set; } // Ngày bắt đầu
        public DateTime? EndDate { get; set; } // Ngày kết thúc

    }
}
