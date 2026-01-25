using HRM_BE.Core.Data.Staff;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace HRM_BE.Core.Data.Company
{
    public class OrganizationV2 : EntityBase<int>
    {
        public HierarchyId Patch { get; set; }
        public string OrganizationCode { get; set; } // mã đơn vị
        public string OrganizationName { get; set; } // tên đơn vị
        public string? Abbreviation { get; set; } // tên viết tắt
        public int? CompanyId { get; set; } // id công ty FK Company, nếu có companyId thì sẽ là cấp 2 dưới company
        public int? Rank { get; set; } // sắp xếp thứ tự ưu tiên hiển thị
        public int? OrganizationTypeId { get; set; } // cấp tổ chức id FK OrganizationType 
        public string? OrganizationTypeName { get; set; }
        public int? OrganizatioParentId { get; set; } // Tổ chức cha nếu có FK Organization
        public string? OrganizationDescription { get; set; } // mô tả chức năng và nhiệm vụ của tổ chức
        public string? BusinessRegistrationCode { get; set; } // số đăng kí giấp phép kinh doanh
        public DateTime? BusinessRegistrationDate { get; set; } // ngày cấp giấp phép kinh doanh
        public string? IssuingAuthority { get; set; } // Nơi cấp đăng ký kinh doanh
        public string? OrganizationAddress { get; set; } // địa chỉ tổ chức
        public string? OrganizationLeadersName { get; set; } // tên người quản lý
        public bool? OrganizationStatus { get; set; } = true;

        //public virtual Company Company { get; set; }
        //public virtual OrganizationType OrganizationType { get; set; }
        //public virtual Organization OrganizatioParent { get; set; }
        //// Thêm danh sách các vị trí thuộc về tổ chức này
        //[JsonIgnore]
        //public virtual List<OrganizationPosition> StaffPositionOrganizations { get; set; }

        //public virtual List<OrganizationLeader> OrganizationLeaders { get; set; }
        //[JsonIgnore]
        //public virtual List<Organization> OrganizationChildren { get; set; }
    }
}
