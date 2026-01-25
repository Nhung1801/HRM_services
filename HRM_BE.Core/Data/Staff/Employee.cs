using HRM_BE.Core.Data.Company;
using HRM_BE.Core.Data.Official_Form;
using HRM_BE.Core.Data.Payroll_Timekeeping.Payroll;
using HRM_BE.Core.Data.Payroll_Timekeeping.Shift;
using HRM_BE.Core.Data.Payroll_Timekeeping.TimekeepingRegulation;
using HRM_BE.Core.Data.Profile;
using HRM_BE.Core.Data.ProfileEntity;
using HRM_BE.Core.Data.Task;
using HRM_BE.Core.Models.ProfileInfoModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace HRM_BE.Core.Data.Staff
{
    public class Employee:EntityBase<int>
    {
        public int? CompanyId { get; set; }
        public int? OrganizationId { get; set; }
        public string EmployeeCode { get; set; }
        public string LastName { get; set; }
        public string FirstName { get; set; }

        public DateTime? DateOfBirth { get; set; }
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
        public int? StaffPositionId {  get; set; } // vị trí công việc FK StaffPosion
        public int? StaffTitleId {  get; set; } // chức danh FK StaffTitle
        public WorkingStatus WorkingStatus { get; set; }
        public DateTime? ProbationDate { get; set; }  // Ngày thử việc
        public DateTime? OfficialDate { get; set; }  // Ngày chính thức
        public string? WorkPhoneNumber { get; set; }  // ĐT cơ quan
        public string? CompanyEmail { get; set; }  // Email công ty
        public string AccountEmail { get; set; }  // Email tài khoản
        public AccountStatus AccountStatus { get; set; } = AccountStatus.NotSend;// Trạng thái tài khoản
        public DateTime? LeaveJobDate { get; set; }


        // add
        public int? ManagerDirectId { get; set; } // người quản lý trực tiếp 
        public Employee? ManagerDirect { get; set; }
        public int? ManagerIndirectId { get; set; } // người quản lý gián tiếp
        public Employee? ManagerIndirect { get; set; }

        public int? EmployeeApproveId { get; set; } // Người duyệt FK employee
        public Employee? EmployeeApprove { get; set; }

        public virtual ICollection<Deduction>? Deductions { get; set; }

        public StaffPosition StaffPosition { get; set; }    
        public StaffTitle StaffTitle { get; set; }
        
        [JsonIgnore]
        public virtual ICollection<OrganizationLeader> OrganizationLeaders { get; set; }
        
        public virtual ICollection<Contract> Contracts { get; set; }
        
        public virtual Company.Company Company { get; set; }
        public virtual JobInfo JobInfo { get; set; }
        public virtual ContactInfo ContactInfo { get; set; }
        public virtual ProfileInfo ProfileInfo { get; set; }
        public virtual Organization Organization { get; set; }
        public virtual ICollection<Timesheet> Timesheets { get; set; }
        public virtual ICollection<LeaveApplication> PermittedLeaves { get; set; }

        public virtual ICollection<SummaryTimesheetNameEmployeeConfirm> SummaryTimesheetNameEmployeeConfirms { get; set; }
        public virtual ICollection<PayrollDetail> PayrollDetails { get; set; }
        public virtual LeavePermission LeavePermissions { get; set; }


        public virtual ICollection<DepartmentEmployee> DepartmentEmployee { get; set; }
        public virtual ICollection<ProjectEmployee> ProjectEmployee { get; set; }


    }
    public enum WorkingStatus
    {
        Active = 0,
        Inactive = 1
    }
    public enum AccountStatus
    {
        NotSend,
        Peding,
        Active,
        InActive
    }
}
