using HRM_BE.Core.Data.Company;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HRM_BE.Core.Models.Identity.User
{
    public class UserCompanyDto
    {
        public int Id { get; set; }
        // Tên đầy đủ
        public string FullName { get; set; }

        // Tên viết tắt
        public string? Abbreviation { get; set; }

        // Logo công ty
        public string? LogoPath { get; set; } // Đường dẫn file logo (có thể lưu trữ trong hệ thống)

    }

    public class UserOrganizationDto
    {
        public int Id { get; set; }
        // Tên đầy đủ
        public OrganizationEnum OrganizationEnum { get; set; }
        public string OrganizationCode { get; set; } // mã đơn vị
        public string OrganizationName { get; set; } // tên đơn vị
        public string? Abbreviation { get; set; } // tên viết tắt
        public int? CompanyId { get; set; } // id công ty FK Company, nếu có companyId thì sẽ là cấp 2 dưới company

    }
}
