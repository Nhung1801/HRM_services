using HRM_BE.Core.Data.Staff;
using HRM_BE.Core.Models.Staff;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HRM_BE.Core.Models.Contract
{
    public class GetContractEmployeeDto
    {
        public string EmployeeCode { get; set; }
        public string LastName { get; set; }
        public string FirstName { get; set; }
        public DateTime? DateOfBirth { get; set; }
        public string? AvatarUrl { get; set; }
        public string? Address { get; set; }
        public string? PhoneNumber { get; set; }
        public string? PersonalEmail { get; set; }
        public int? Sex { get; set; }
        public int? StaffPositionId { get; set; } // vị trí công việc FK StaffPosion
        public int? StaffTitleId { get; set; } // chức danh FK StaffTitle
        public WorkingStatus WorkingStatus { get; set; }
        public DateTime? ProbationDate { get; set; }  // Ngày thử việc
        public DateTime? OfficialDate { get; set; }  // Ngày chính thức
        public string? WorkPhoneNumber { get; set; }  // ĐT cơ quan
        public string? CompanyEmail { get; set; }  // Email công ty
        public string AccountEmail { get; set; }  // Email tài khoản
        public AccountStatus AccountStatus { get; set; } = AccountStatus.NotSend;// Trạng thái tài khoản
        public DateTime? LeaveJobDate { get; set; }
        public StaffTitleDto StaffTitle { get; set; }
        public StaffPositionDto StaffPosition { get; set; }
    }
}
