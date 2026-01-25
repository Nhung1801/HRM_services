using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HRM_BE.Core.Data.Task
{
    // Bảng thẻ
    public class Tag : EntityBase<int>
    {
        public string? Name { get; set; } // Tên thẻ
        public string? Color { get; set; } // Mã màu

    }

    public class TagWork
    {
        public int? TagId { get; set; }
        public int? WorkId { get; set; }
        public virtual Tag Tag { get; set; }
        public virtual Work Work { get; set; }
    }
}
