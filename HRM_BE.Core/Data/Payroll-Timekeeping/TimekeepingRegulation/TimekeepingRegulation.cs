using HRM_BE.Core.Data.Company;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HRM_BE.Core.Data.Payroll_Timekeeping.TimekeepingRegulation
{
    //Bảng quy định chấm công
    public class TimekeepingRegulation:EntityBase<int>
    {
        public int? OrganizationId { get; set; } // tổ chức công ty
        public bool? AllowEmployeesToRegisterForShifts { get; set; }//cho phép nhân viên đăng kí ca
        public bool? AllowDailyTimekeepingDetail { get; set; }// cho phép nhân viên theo dõi bảng chấm công chi tiết hàng ngày
        public bool? AllowTrackingWorkHoursOnTimekeepingSheet { get; set; } // cho phép nhân viên theo dỗi thời gian llamf vệc trên bảng chấm côcng
        public bool? AllowTimekeepingOutsideScheduledShifts { get; set; } //cho phép nhân viên chấm công ngoài khung giờ chấm công
        public bool? AllowShiftBasedTimekeeping { get; set; } // phân ca chấm công theo địa điểm làm việc 
        public PartTimePayrollType? PartTimePayrollType { get; set; } //tính công khi chưa đủ 1 ca

        public virtual Organization Organization { get; set; }
    }


    //Các option tính công khi chưa đủ 1 ca
    public enum PartTimePayrollType
    {
        CalculatePayForIncompleteShiftAsActualHoursWorked,// tính theo giờ thực tế
        CalculatePayForIncompleteShiftAsHalfShift // tính theo nửa công
    }
}
