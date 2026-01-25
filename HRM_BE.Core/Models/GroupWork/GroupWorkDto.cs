using HRM_BE.Core.Models.WorkModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HRM_BE.Core.Models.GroupWorkModel
{
    public class GroupWorkDto
    {
        public int Id { get; set; }
        public int? ProjectId { get; set; }
        public string? Name { get; set; } // Tên nhóm công việc
        public string? Color { get; set; } // Mã màu
        public virtual ICollection<WorkDto> Works { get; set; } 
    }
}
