using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HRM_BE.Core.Models.Department
{
    public class UpdateDepartmentBasicInfoRequest
    {
        public int Id { get; set; }
        public string Name { get; set; } // Tên phòng ban
        public string Description { get; set; } // Mô tả phòng ban
    }

}
