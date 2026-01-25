using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HRM_BE.Core.Models.Organization
{
    public class OrganizationSelectDto
    {
        public int Id { get; set; }
        public string OrganizationCode { get; set; } // mã đơn vị
        public string OrganizationName { get; set; } // tên đơn vị
        public int? CompanyId { get; set; }
        public int? OrganizatioParentId { get; set; } // Tổ chức cha nếu có FK Organization
        public int? Rank { get; set; } // sắp xếp thứ tự ưu tiên hiển thị
        public bool? OrganizationStatus { get; set; }
        public int? TotalEmployees { get; set; }
        public virtual List<OrganizationSelectDto> OrganizationChildren { get; set; }
    }
}
