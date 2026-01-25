using HRM_BE.Core.Data.Staff;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HRM_BE.Core.Data.ProfileEntity
{
    public class Deduction:EntityBase<int> // khấu trừ
    {
        public string? DeducationName { get; set; } // tên khoản
        public string? StandardType { get; set; } // loại định mức
        public decimal? StandardValue { get; set; }

        public string? TypeValue { get; set; } // loại giá trị  
        public decimal? Value { get; set; } // giá trị
        public string? Note { get; set; }
        //public int? ProfileInfoId { get; set; }
        //public virtual ProfileInfo ProfileInfo { get; set; }
        public int? EmployeeId { get; set; }
        public virtual Employee Employee { get; set; }
    }
}
