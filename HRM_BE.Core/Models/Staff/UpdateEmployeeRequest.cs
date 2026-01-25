using HRM_BE.Core.Data.Staff;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HRM_BE.Core.Models.Staff
{
    public class UpdateEmployeeRequest
    {
        public string EmployeeCode { get; set; }
        public string LastName { get; set; }
        public string FirstName { get; set; }
        public DateTime? DateOfBirth { get; set; }
        public IFormFile? AvatarImage { get; set; }

        public string? AvatarUrl { get; set; }
        //================================ HỘ Khẩu THƯỜNG TRÚ
        public int? NationId { get; set; }
        public string? Nation { get; set; } // quốc gia
        public int? CityId { get; set; }
        public string? City { get; set; }
        public int? DistrictId { get; set; }
        public string? District { get; set; }
        public int? WardId { get; set; }
        public string? Ward { get; set; }
        public int? StreetId { get; set; }
        public string? Street { get; set; }
        public string? Address { get; set; }
        public string? PhoneNumber { get; set; }
        public string? PersonalEmail { get; set; }
        public int? Sex { get; set; }
        public int? OrganizationId { get; set; }
        public int? StaffPositionId { get; set; } // vị trí công việc FK StaffPosion
        public int? StaffTitleId { get; set; } // chức danh FK StaffTitle
        public int? ManagerDirectId { get; set; } // Quản lý trực tiếp FK Employee
        public int? EmployeeApproveId { get; set; } // Người duyệt FK employee
        public WorkingStatus WorkingStatus { get; set; }
        public DateTime? ProbationDate { get; set; }  // Ngày thử việc
        public DateTime? OfficialDate { get; set; }  // Ngày chính thức
        public DateTime? LeaveJobDate { get; set; } // ngày nghỉ việc
        public string? WorkPhoneNumber { get; set; }  // ĐT cơ quan
        public string? CompanyEmail { get; set; }  // Email công ty
        public string AccountEmail { get; set; }  // Email tài khoản
    }
}
