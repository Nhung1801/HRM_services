using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HRM_BE.Core.Models.GroupWorkModel
{
    public class CreateGroupWorkRequest
    {
        public int? ProjectId { get; set; }
        public string? Name { get; set; } // Tên nhóm công việc
        public string? Color { get; set; } // Mã màu
    }
}
