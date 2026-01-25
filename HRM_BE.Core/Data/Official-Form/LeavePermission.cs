using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HRM_BE.Core.Data.Official_Form
{
    public class LeavePermission:EntityBase<int> // bảng lưu số lượng ngày nghỉ phép của một nhân viên
    {
        public int? ContractId { get; set; }
        public int? LeaveApplicationId { get; set; }
        public int EmployeeId { get; set; }
        public double NumerOfLeave { get; set; } // số ngày được nghỉ
        public DateTime Date { get; set; }
        public LeavePerrmissionStatus LeavePerrmissionStatus { get; set; } = LeavePerrmissionStatus.None;

    }
    public enum LeavePerrmissionStatus
    {
        None,
        Active,
        InActive
    }
}
