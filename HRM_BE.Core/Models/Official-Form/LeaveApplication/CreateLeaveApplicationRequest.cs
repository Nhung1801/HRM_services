using HRM_BE.Core.Data.Official_Form;
using HRM_BE.Core.Data.Payroll_Timekeeping.LeaveRegulation;
using HRM_BE.Core.Models.Payroll_Timekeeping.LeaveRegulation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace HRM_BE.Core.Models.Official_Form.LeaveApplication
{
    public class CreateLeaveApplicationRequest
    {
        public int? OrganizationId { get; set; } // tổ chức công ty đơn vị
        public int? EmployeeId { get; set; }// Nhân viên tạo đơn
        public DateTime? StartDate { get; set; } // Ngày bắt đầu nghỉ
        public DateTime? EndDate { get; set; } // Ngày kết thúc nghỉ
        public double? NumberOfDays { get; set; } // Số ngày nghỉ
        public int? TypeOfLeaveId { get; set; } // Loại nghỉ phép
        public string? TypeOfLeaveName { get; set; } // Tên loại nghỉ phép truyền về để thông báo dễ hơn, ko lưu db
        public decimal? SalaryPercentage { get; set; } // Phần trăm lương được hưởng trong thời gian nghỉ == TypeOfLeave.SalaryRate
        public string? ReasonForLeave { get; set; } // Lý do xin nghỉ
        public string? Note { get; set; } // Ghi chú thêm cho đơn
        public UpdateDaysRemainingTypeOfLeaveEmployeeRequest UpdateDaysRemainingTypeOfLeaveEmployeeRequest { get; set; }// kiểm tra số ngày nghỉ còn ko
        public LeaveApplicationStatus? Status { get; set; } = LeaveApplicationStatus.Pending;// Trạng thái mặc định là chờ duyệt
        public OnPaidLeaveStatus? OnPaidLeaveStatus { get; set; } = HRM_BE.Core.Data.Official_Form.OnPaidLeaveStatus.No; // Có chọn nghỉ trừ số ngày nghỉ không

        public List<int> ApproverIds { get; set; } = new(); // Danh sách ID người duyệt đơn
        public List<int> ReplacementIds { get; set; } = new(); // Danh sách ID người thay thế
        public List<int> RelatedPersonIds { get; set; } = new(); // Danh sách ID người liên quan


        //addition
        //[JsonIgnore]
        //public int? CreatedBy { get; set; }
        //[JsonIgnore]
        //public string? CreatedName { get; set; }
        //[JsonIgnore]
        //public DateTime? CreatedAt { get; set; }

    }
}
