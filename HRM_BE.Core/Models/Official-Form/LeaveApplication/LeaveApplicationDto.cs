using HRM_BE.Core.Data.Official_Form;
using HRM_BE.Core.Data.Payroll_Timekeeping.LeaveRegulation;
using HRM_BE.Core.Data.Staff;
using HRM_BE.Core.Models.Organization;
using HRM_BE.Core.Models.Staff;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HRM_BE.Core.Models.Official_Form.LeaveApplication
{
    public class LeaveApplicationDto
    {
        public int Id { get; set; }

        public int? OrganizationId { get; set; } // tổ chức công ty đơn vị

        public int? EmployeeId { get; set; }// Nhân viên tạo đơn

        public DateTime? StartDate { get; set; } // Ngày bắt đầu nghỉ

        public DateTime? EndDate { get; set; } // Ngày kết thúc nghỉ

        public double? NumberOfDays { get; set; } // Số ngày nghỉ

        public int? TypeOfLeaveId { get; set; } // Loại nghỉ phép

        public decimal? SalaryPercentage { get; set; } // Phần trăm lương được hưởng trong thời gian nghỉ == TypeOfLeave.SalaryRate

        public string? ReasonForLeave { get; set; } // Lý do xin nghỉ

        public string? Note { get; set; } // Ghi chú thêm cho đơn

        public string? ApproverNote { get; set; } // Ghi chú của người duyệt cho đơn

        public OnPaidLeaveStatus? OnPaidLeaveStatus { get; set; } = HRM_BE.Core.Data.Official_Form.OnPaidLeaveStatus.No; // Có chọn nghỉ trừ số ngày nghỉ không

        public LeaveApplicationStatus? Status { get; set; }

        public List<LeaveApplicationApproverDto> LeaveApplicationApprovers { get; set; }// Danh sách người duyệt đơn

        public List<LeaveApplicationReplacementDto> LeaveApplicationReplacements { get; set; } // Danh sách người thay thế

        public List<LeaveApplicationRelatedPersonDto> LeaveApplicationRelatedPeople { get; set; }// Danh sách người liên quan

        public virtual LeaveApplicationTypeOfLeaveDto TypeOfLeave { get; set; }

        public LeaveApplicationEmployeeDto Employee { get; set; }

        public int? CreatedBy { get; set; }

        public string? CreatedName { get; set; }

        public DateTime? CreatedAt { get; set; }

        public int? UpdatedBy { get; set; }

        public string? UpdatedName { get; set; }

        public DateTime? UpdatedAt { get; set; }

    }

    public class LeaveApplicationApproverDto
    {
        public int? LeaveApplicationId { get; set; }

        public int? ApproverId { get; set; }

        public LeaveApplicationEmployeeDto Approver { get; set; }
    }

    public class LeaveApplicationReplacementDto
    {
        public int? LeaveApplicationId { get; set; }

        public int? ReplacementId { get; set; }

        public LeaveApplicationEmployeeDto Replacement { get; set; }
    }

    public class LeaveApplicationRelatedPersonDto
    {
        public int? LeaveApplicationId { get; set; }

        public int? RelatedPersonId { get; set; }

        public  LeaveApplicationEmployeeDto RelatedPerson { get; set; }
    }

    public class LeaveApplicationEmployeeDto
    {
        public int Id { get; set; }

        public string? PersonalEmail { get; set; }

        public string? AvatarUrl { get; set; }

        public string EmployeeCode { get; set; }

        public string LastName { get; set; }

        public string FirstName { get; set; }

        public StaffTitleDto StaffTitle { get; set; }

        public LeaveApplicationEmployeeStaffPositionDto StaffPosition { get; set; }

        public virtual LeaveApplicationEmployeeOrganizationDto Organization { get; set; }

    }

    public class LeaveApplicationTypeOfLeaveDto
    {
        public int Id { get; set; }

        public int? OrganizationId { get; set; } // tổ chức công ty

        public string? Name { get; set; }//Tên loại

        public decimal? SalaryRate { get; set; }//Tỷ lệ hưởng lương

        public double? MaximumNumberOfDayOff { get; set; } //Số ngày nghỉ tối đa

        public string? Note { get; set; } //Ghi chú


    }

    public class LeaveApplicationEmployeeStaffPositionDto
    {
        public string PositionCode { get; set; } // mã vị trí
        public string PositionName { get; set; } // tên vị trí
        //public virtual StaffTitleDto StaffTitle { get; set; }
    }

    public class LeaveApplicationEmployeeOrganizationDto
    {
        public int Id { get; set; }
        public string OrganizationCode { get; set; } // mã đơn vị
        public string OrganizationName { get; set; } // tên đơn vị
        public string? Abbreviation { get; set; } // tên viết tắt
        public int? CompanyId { get; set; } // id công ty FK Company, nếu có companyId thì sẽ là cấp 2 dưới company

    }
}
