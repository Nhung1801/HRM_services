using HRM_BE.Core.Data.Company;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HRM_BE.Core.Data.Payroll_Timekeeping.LeaveRegulation
{
    public class GeneralLeaveRegulation : EntityBase<int>
    {
        public int? OrganizationId { get; set; } // tổ chức công ty

        public int? AdmissionDay { get; set; } // Ngày phép cho nhân viên vào

        public MonthlyLeaveAccrual? MonthlyLeaveAccrual { get; set; } //Số ngày phép đc cộng hàng tháng

        public LeaveCalculationStartPoint? LeaveCalculationStartPoint { get; set; } // Thời điểm bắt đầu tính phép: Thử việc, Chính thức, Thâm niên

        public int SeniorityMonths { get; set; } // sau số tháng thì tính phép

        public  LeaveCalculationForPartialMonth LeaveCalculationForPartialMonth { get; set; } // Tính phép cho tháng nếu nghỉ việc ngay bắt kỳ trong tháng, sau ngày 2

        public int? NumberOfDaysOff {  get; set; }// số ngày nghỉ nếu chọn   QuitAfterDay, // nghỉ việc  sau N ngày

        public virtual Organization Organization { get; set; }

    }

    //Số ngày phép đc cộng hàng tháng
    public enum MonthlyLeaveAccrual
    {
        AccrueLeaveMonthly,// Mỗi tháng được cộng 1 ngày phép
        DivideAnnualLeave // Tổng số ngày phép trong năm chia đều cho 12 tháng

    }
   
    //Thời điểm bắt đầy tính phép
    public enum LeaveCalculationStartPoint
    {
        Probationary,//Thử việc
        Official,// Chính thức
        Seniority //Nhân viên
    }

    //Tính phép cho tháng nếu nghỉ việc ngay bắt kỳ trong tháng, sau ngày 2
    public enum LeaveCalculationForPartialMonth
    {
        QuitJobAnyTimeOfTheMonth,//nghỉ việc bất cứ lúc nào trong tháng
        QuitAfterDay, // nghỉ việc  sau N ngày

    }
}
