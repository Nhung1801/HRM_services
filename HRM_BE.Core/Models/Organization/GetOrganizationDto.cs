using HRM_BE.Core.Data;
using HRM_BE.Core.Data.Company;
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

    public class OrgHierarchyResult
    {
        public int Id { get; set; }
        public string OrganizationCode { get; set; }
        public string OrganizationName { get; set; }
        public string? Abbreviation { get; set; }

        public int? CompanyId { get; set; }
        public int? Rank { get; set; }
        public int? OrganizationTypeId { get; set; }
        public int? OrganizatioParentId { get; set; }
        public bool? OrganizationStatus { get; set; }

        public int RootId { get; set; }
        public int Level { get; set; }

        public int TotalEmployees { get; set; }
        public int LeaderCount { get; set; }

        public int? OrganizationType_Id { get; set; }
        public int? OrganizationType_CompanyId { get; set; }
        public string? OrganizationType_OrganizationTypeName { get; set; }
    }


    public class OrgNode
    {
        public int Id { get; set; }
        public int? ParentId { get; set; }

        public string OrganizationCode { get; set; } = null!;
        public string OrganizationName { get; set; } = null!;
        public string? Abbreviation { get; set; }

        public int DirectEmployees { get; set; }
        public int TotalEmployees { get; set; }

        public OrganizationType? OrganizationType { get; set; }
        public List<OrganizationLeaderDto> Leaders { get; set; } = new();

        public List<OrgNode> Children { get; set; } = new();
    }


}
