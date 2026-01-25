using HRM_BE.Core.Data.Staff;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HRM_BE.Core.Data.ProfileEntity
{
    public class ProfileInfo:EntityBase<int>
    {
        public int? EmployeeId { get; set; }
        public Employee? Employee { get; set; }
        // =================================== THÔNG TIN CÁ NHÂN CHUNG ===================================
        //public string? AvatarUrl { get; set; }
        public string? ProfileCode { get; set; }
        //public string? FirstName { get; set; } 
        //public string? LastName { get; set; }
        public string? AnotherName { get; set; }
        //public DateTime? DateOfBirth { get; set; } // ngày sinh
        //public bool? Sex;
        public string? BornLocation { get; set; } // nơi sinh
        //public string? PhoneNumber { get; set; }
        public string? OriginalLocation { get; set; }
        public string? MarriageStatus { get; set; } // tình trạng hôn nhân
        public string? PersonalTaxNumber { get; set; } // mã số thuế cá nhân
        public string? TypeFamily { get; set; } // thành phần gia đình 
        public string? TypePersonal {  get; set; } // thành phần bản thân 
        public string? Tripe {  get; set; } // dân tộc
        public string? Religion { get; set; } // tôn giáo 
        public string? Nation { get; set; } // quốc tịch
        // =============================== CMND CĂN CƯỚC ===================================================
        public string? TypePaper { get; set; } // loại giấy tờ
        public string? PaperNumber { get; set; } // số giấy tờ
        public DateTime? PaperProvideDate { get; set; } // ngày cấp
        public string? PaperProvideLocation { get; set; } // nơi cấp giấy tờ
        public DateTime? ExpirePaperDate { get; set; } // ngày hết hạn
        public string? PassportNumber { get; set; } // số hộ chiếu
        public DateTime? PassportProvideDate { get; set; } // ngày cấp hộ chiếu
        public string? PassportProvideLocation { get; set; } // nơi cấp hộ chiếu
        public DateTime? ExpirePassportDate { get; set; } // ngày hết hạn hộ chiếu
        // ============================ TRÌNH ĐỘ BẰNG CẤP ================================================= 
        public string? CultureLevel { get; set; }
        public string? EducationLevel { get; set; }
        public string? EducationTraningLocation { get; set; }
        public string? Faculty { get; set; }
        public string? Specialized { get; set; } // chuyên ngành
        public string? GraduateDate { get; set; } // ngày tốt nghiệp 
        public string? GraduationClassification { get; set; } // Loại tốt nghiệp

    }
}
