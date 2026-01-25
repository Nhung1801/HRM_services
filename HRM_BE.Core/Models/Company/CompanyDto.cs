using HRM_BE.Core.Data;
using HRM_BE.Core.Data.Company;
using HRM_BE.Core.Models.Organization;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HRM_BE.Core.Models.Company
{
    public class CompanyDto
    {
        public int Id { get; set; }
        // Tên đầy đủ
        public string FullName { get; set; }

        // Tên viết tắt
        public string? Abbreviation { get; set; }

        // Mã số thuế
        public string TaxCode { get; set; }

        // Mã công ty - Sinh tự động (Định dạng TCTSMO)
        public string CompanyCode { get; set; }

        // Ngày thành lập
        public DateTime? IncorporationDate { get; set; }

        // Logo công ty
        public string? LogoPath { get; set; } // Đường dẫn file logo (có thể lưu trữ trong hệ thống)

        // Mã đăng ký kinh doanh
        public string? BusinessRegistrationCode { get; set; }

        // Ngày cấp mã đăng ký kinh doanh
        public DateTime? BusinessRegistrationDate { get; set; }

        // Nơi cấp đăng ký kinh doanh
        public string? IssuingAuthority { get; set; }

        // Người đại diện pháp luật
        public string? LegalRepresentative { get; set; }

        // Chức danh người đại diện pháp luật
        public string? LegalRepresentativeTitle { get; set; }
        public string? Address { get; set; }
        public string? PhoneNumber { get; set; }
        public string? Fax { get; set; }
        public string? Email { get; set; }
        public string? Website { get; set; }
 //       public List<OrganizationDto> organizationals { get; set; }

    }
}
