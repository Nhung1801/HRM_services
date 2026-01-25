using HRM_BE.Core.Data.ProfileEntity;

using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace HRM_BE.Core.Data.Profile
{
    public class Allowance : EntityBase<int>
    {
        public int? AllowNameId { get; set; }
        public string? AllowanceName {  get; set; } // tên khoản phụ cấp
        public int? StandardTypeId { get; set; }
        public string? StandardType { get; set; } // loại định mức
        public decimal? StandardValue { get; set; }
        public int? TypeValueId { get; set; } // loại giá trị  

        public string? TypeValue { get; set; } // loại giá trị  
        public decimal? Value { get; set; } // giá trị
        public string? Note { get; set; }
        public int ContractId { get; set; }
        [ForeignKey("ContractId")]
        public virtual Contract? Contract { get; set; }
        


    }
}
