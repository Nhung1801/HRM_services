using HRM_BE.Core.Data.Company;
using HRM_BE.Core.Data.Payroll_Timekeeping.LeaveRegulation;
using HRM_BE.Core.Data.Staff;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HRM_BE.Core.Data.Official_Form
{
    //Đơn xin nghỉ việc
    public class LeaveApplication:EntityBase<int>
    {
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

        public LeaveApplicationStatus? Status { get; set; }= LeaveApplicationStatus.Pending;// Trạng thái mặc định là chờ duyệt

        public virtual ICollection<LeaveApplicationApprover> LeaveApplicationApprovers { get; set; }// Danh sách người duyệt đơn

        public virtual ICollection<LeaveApplicationReplacement> LeaveApplicationReplacements { get; set; } // Danh sách người thay thế

        public virtual ICollection<LeaveApplicationRelatedPerson> LeaveApplicationRelatedPeople { get; set; }// Danh sách người liên quan

        public virtual TypeOfLeave TypeOfLeave { get; set; }

        public virtual Employee Employee { get; set; }

        public virtual Organization Organization { get; set; }

        public virtual ICollection<LeavePermission> LeavePermission { get; set; } 
        //public string? Approver { get; set; } // Người duyệt đơn
        //public string? Replacement { get; set; } // Người thay thế trong thời gian nghỉ
        //public string? RelatedPerson { get; set; } // Người liên quan đến đơn xin nghỉ
    }


    //Bảng nối giữa đơn xin nghỉ và người duyệt đơn vì 1 đơn xin nghỉ có thể có nhiều người duyệt
    public class LeaveApplicationApprover
    {
        public int? LeaveApplicationId {  get; set; }
        
        public int? ApproverId { get; set; }

        public virtual LeaveApplication LeaveApplication { get; set; }

        public virtual Employee Approver { get; set; }

    }

    //Bảng nối giữa đơn xin nghỉ và người thay thế vì 1 đơn xin nghỉ có thể có nhiều người thay thế
    public class LeaveApplicationReplacement
    {
        public int? LeaveApplicationId { get; set; }

        public int? ReplacementId { get; set; }

        public virtual LeaveApplication LeaveApplication { get; set; }

        public virtual Employee Replacement { get; set; }
    }

    //Bảng nối giữa đơn xin nghỉ và người liên quan vì 1 đơn xin nghỉ có thể có nhiều người liên quan
    public class LeaveApplicationRelatedPerson
    {
        public int? LeaveApplicationId { get; set; }

        public int? RelatedPersonId { get; set; }

        public virtual LeaveApplication LeaveApplication { get; set; }

        public virtual Employee RelatedPerson { get; set; }
    }




    public enum LeaveApplicationStatus
    {
        Pending,    // Đang chờ duyệt
        Approved,   // Đã được phê duyệt
        Rejected    // Bị từ chối
    }

    public enum OnPaidLeaveStatus
    {
        Yes,
        No
    }

}
