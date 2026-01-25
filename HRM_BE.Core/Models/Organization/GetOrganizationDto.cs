using HRM_BE.Core.Data;
using HRM_BE.Core.Models.Company;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HRM_BE.Core.Models.Organization
{
    public class GetOrganizationDto
    {
        public int Id { get; set; }
        public string OrganizationCode { get; set; } // mã đơn vị
        public string OrganizationName { get; set; } // tên đơn vị
        public string? Abbreviation { get; set; } // tên viết tắt
        public int? CompanyId { get; set; } // id công ty FK Company, nếu có companyId thì sẽ là cấp 2 dưới company
        public int? Rank { get; set; } // sắp xếp thứ tự ưu tiên hiển thị
        public int OrganizationTypeId { get; set; } // cấp tổ chức id FK OrganizationType 
        public int? OrganizatioParentId { get; set; } // Tổ chức cha nếu có FK Organization
        public int? TotalEmployees { get; set; } 
        public bool? OrganizationStatus { get; set; } = true;
        public virtual OrganizationTypeDto OrganizationType { get; set; }
        public virtual List<GetOrganizationDto> OrganizationChildren { get; set; }
        public virtual List<OrganizationLeaderDto> OrganizationLeaders { get; set; }
        public virtual List<GetOrganizationEmployeeDto> Employees { get; set; }


    }

}
