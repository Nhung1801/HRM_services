using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HRM_BE.Core.Models.Contract.Allowance
{
    public class AllowanceDto
    {
        public int Id { get; set; }
        public int? AllowNameId { get; set; }
        public string? AllowanceName { get; set; } // tên khoản phụ cấp
        public int? StandardTypeId { get; set; }
        public string? StandardType { get; set; } // loại định mức
        public decimal? StandardValue { get; set; }
        public int? TypeValueId { get; set; } // loại giá trị  

        public string? TypeValue { get; set; } // loại giá trị  
        public decimal? Value { get; set; } // giá trị
        public string? Note { get; set; }
        public int ContractId { get; set; }
    }
}
