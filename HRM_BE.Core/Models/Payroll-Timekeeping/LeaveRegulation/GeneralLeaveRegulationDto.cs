using HRM_BE.Core.Data.Payroll_Timekeeping.LeaveRegulation;
using HRM_BE.Core.Models.Organization;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HRM_BE.Core.Models.Payroll_Timekeeping.LeaveRegulation
{
    public class GeneralLeaveRegulationDto
    {
        public int Id { get; set; }
        public int? OrganizationId { get; set; } // tổ chức công ty

        public int? AdmissionDay { get; set; } // Ngày phép cho nhân viên vào

        public MonthlyLeaveAccrual? MonthlyLeaveAccrual { get; set; } //Số ngày phép đc cộng hàng tháng

        public LeaveCalculationStartPoint? LeaveCalculationStartPoint { get; set; } // Thời điểm bắt đầu tính phép: Thử việc, Chính thức, Thâm niên

        public int SeniorityMonths { get; set; } // Thâm niên tính bằng tháng

        public LeaveCalculationForPartialMonth LeaveCalculationForPartialMonth { get; set; } // Tính phép cho tháng nếu nghỉ việc ngay bắt kỳ trong tháng, sau ngày 2

        public int? NumberOfDaysOff { get; set; }// số ngày nghỉ nếu chọn   QuitAfterDay, // nghỉ việc  sau N ngày

    }

}

