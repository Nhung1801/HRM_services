using HRM_BE.Core.Data.Payroll_Timekeeping.TimekeepingRegulation;
using HRM_BE.Core.Data.Staff;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HRM_BE.Core.Models.Payroll_Timekeeping.TimekeepingRegulation
{
    public class TimesheetDto
    {
        public int Id { get; set; }
        public int? ShiftWorkId { get; set; }// Dữ liệu bảng phân ca nào

        public int? EmployeeId { get; set; } //Id nhân viên

        //public int? TimekeepingTypeId { get; set; }// Loại chấm công, bằng GPS hay...

        public TimekeepingType? TimekeepingType { get; set; }// Loại chấm công, bằng GPS hay...

        public DateTime? Date { get; set; }// Ngày chấm công

        public TimeSpan? StartTime { get; set; }//Giờ bắt đầu chấm

        public TimeSpan? EndTime { get; set; }//Giờ ra 

        public double? NumberOfWorkingHour { get; set; }// Số giờ làm bằng bằng EndTime - StartTime
        public double? LateDuration { get; set; } // Đi muộn (phút)
        public double? EarlyLeaveDuration { get; set; } // Về sớm (phút)

    }
}
