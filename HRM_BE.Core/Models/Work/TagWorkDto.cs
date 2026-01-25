using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HRM_BE.Core.Models.Work
{
    public class TagWorkDto
    {
        public int? Id { get; set; }
        public string? Name { get; set; } // Tên thẻ
        public string? Color { get; set; } // Mã màu
    }
}
