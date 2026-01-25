using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HRM_BE.Core.Models.CheckList
{
    public class CreateCheckListRequest
    {
        public string? Name { get; set; } // Tên checklist
        public bool? IsDone { get; set; } = false; // Trạng thái hoàn thành
    }
}
