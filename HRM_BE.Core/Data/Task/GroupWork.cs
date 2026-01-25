using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HRM_BE.Core.Data.Task
{
    // Nhóm công việc
    public class GroupWork : EntityBase<int>
    {
        public int? ProjectId { get;set; } 
        public string? Name { get; set; } // Tên nhóm công việc
        public string? Color { get; set; } // Mã màu
        public virtual Project Project { get;set; }
        public virtual ICollection<Work> Works { get; set; }
    }
}
