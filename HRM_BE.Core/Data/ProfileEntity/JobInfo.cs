using HRM_BE.Core.Data.Profile;
using HRM_BE.Core.Data.Staff;
using Microsoft.VisualBasic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HRM_BE.Core.Data.ProfileEntity
{
    public class JobInfo:EntityBase<int>
    {
        public int? EmployeeId { get; set; }
        public Employee? Employee { get; set; }
        // ==================================== THÔNG TIN CÔNG VIỆC ====================================
        public int? OrganizationId { get; set; }
        public int? StaffPositioId { get; set; }
        public int? StaffTitleId { get; set; }
        public WorkingStatus WorkingStatus { get; set; }
        public int? TimeKeepingId { get; set; } // MÃ CHẤM CÔNG (Làm Sau)
        public int? NatureOfLaborId { get; set; } // FK tính chất lao động
        public string? NatureOfLaborName { get; set; }
        public NatureOfLabor NatureOfLabor { get; set; }
        public string? WorkingArea { get; set; } // khu vực làm việc 
        public string? WorkingLocation { get; set; } // địa điểm làm việc
        public int? ContractTypeId { get; set; } // loại hợp đồng FK ContractType
        public ContractType ContractType { get; set; }
        public DateTime? InternshipStartDate { get; set; } // ngày học việc
        public DateTime? ProbationStartDate { get; set; } // ngày thử việc
        public DateTime? OfficialStartDate { get; set; } // ngày chính thức
        public double? Seniority { get; set; } // Thâm niên
        public DateTime? RetiredDate { get; set; } // ngày nghỉ hưu

        // ================================= THÔNG TIN NGHỈ VIỆC =======================================
        public string? ReasonGroupQuitJob { get; set; } // nhóm lý do nghỉ việc
        public string? ReasonQuitJob { get; set; } // lý do nghỉ việc
        public DateTime? QuitJobDate { get; set; } // ngày nghi việc
        public string? OpinionContribute { get; set; } // ý kiến đóng góp

        //================================== THÔNG TIN LƯƠNG ===========================================
        public decimal? SalaryLevel { get; set; } // bậc lương 
        public decimal? BasicSalary { get; set; } // lương cơ bản
        public decimal? InsuranceSalary { get; set; } // lương đóng bảo hiểm
        public decimal? TotalSalary { get; set; } // tổng lương
        public string? BankAccountNumber { get; set; } // số tài khoản nhận
        public string? BankName { get; set; }
        // ================================ CÁC KHOẢN PHỤ CẤP ==========================================
        //public int? AllowanceId { get; set; } // Phụ cấp  FK Allowance
        //public virtual List<Allowance> Allowances { get; set; }
        //public int? DeductionId { get; set; } // Khấu trừ FK Deduction
        //public virtual List<Deduction> Deductions { get; set; } 


    }

}
