using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HRM_BE.Core.Models.ProfileInfoModel
{
    public class UpdateDeductionRequest
    {
        public string? DeducationName { get; set; } // tên khoản
        public string? StandardType { get; set; } // loại định mức
        public decimal? StandardValue { get; set; }

        public string? TypeValue { get; set; } // loại giá trị  
        public decimal? Value { get; set; } // giá trị
        public string? Note { get; set; }
        public int? EmployeeId { get; set; }
    }
}
