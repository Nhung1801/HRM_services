using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HRM_BE.Core.Data.Company
{
    public class OrganizationType:EntityBase<int>
    {
        public int CompanyId { get; set; }
        public string OrganizationTypeName { get; set; } // tên của cấp tổ chức
        public virtual Company Company { get; set; }
    }
}
