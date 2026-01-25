using HRM_BE.Core.Data.Official_Form;
using HRM_BE.Core.Models.Payroll_Timekeeping.LeaveRegulation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HRM_BE.Core.Models.Official_Form.LeaveApplication
{

    public class UpdateStatusLeaveApplicationMultipleRequest
    {
        public List<UpdateStatusLeaveApplicationItemRequest> UpdateStatusLeaveApplicationRequests { get; set; }


    }

    public class UpdateStatusLeaveApplicationItemRequest
    {
        public int Id { get; set; }
        public LeaveApplicationStatus Status { get; set; }

        public UpdateDaysRemainingTypeOfLeaveEmployeeRequest UpdateDaysRemainingTypeOfLeaveEmployeeRequest { get; set; }// kiểm tra số ngày nghỉ còn ko

        public string? ApproverNote { get; set; } // Ghi chú của người duyệt cho đơn

    }




    #region ignore
    //public class UpdateStatusLeaveApplicationMultipleRequest
    //{
    //    public List<int> Ids { get; set; }
    //    public LeaveApplicationStatus Status { get; set; }
    //    public string ApproverNote { get; set; }
    //}
    #endregion
}
