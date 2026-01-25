using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HRM_BE.Core.Models.Work
{
    public class CheckListWorkDto
    {
        public int Id { get; set; } 
        public int? WorkId { get; set; } // Công việc
        public string? Name { get; set; } // Tên checklist
        public bool? IsDone { get; set; } = false; // Trạng thái hoàn thành
    }
}
