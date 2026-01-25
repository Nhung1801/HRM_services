using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HRM_BE.Core.Models.Tag
{
    public class CreateTagRequest
    {
        public string? Name { get; set; } // Tên thẻ
        public string? Color { get; set; } // Mã màu
    }
}
