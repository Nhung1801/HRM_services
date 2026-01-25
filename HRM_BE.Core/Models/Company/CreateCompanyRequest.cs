using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace HRM_BE.Core.Models.Company
{
    public class CreateCompanyRequest
    {
        // Tên đầy đủ
        [Required(ErrorMessage ="Tên đầy đủ là trường bắt buộc")]
        public string FullName { get; set; }

        // Tên viết tắt
        public string? Abbreviation { get; set; }

        // Mã số thuế
        [Required(ErrorMessage = "Mã số thuế là trường bắt buộc")]
        public string TaxCode { get; set; }

        // Ngày thành lập
        public DateTime? IncorporationDate { get; set; }

        [JsonIgnore] // Loại trừ khỏi JSON serialization
        public string? LogoPath { get; set; } // Đường dẫn file logo (có thể lưu trữ trong hệ thống)
        public IFormFile? LogoImage { get; set; }

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
    }
}
