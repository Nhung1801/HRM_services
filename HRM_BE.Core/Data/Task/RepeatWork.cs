using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HRM_BE.Core.Data.Task
{
    // Bảng Lặp lại công việc
    public class RepeatWork : EntityBase<int>
    {
        public bool? IsRepeat { get; set; } // Trạng thái lặp lại
        public DateTime? StartDate { get; set; } // Ngày bắt đầu
        public DateTime EndDate { get; set; } // Ngày kết thúc
        public int? RepeatNumberDay { get; set; } // Số ngày muốn lặp theo option enum Day
        public bool? IsMonday { get; set; }
        public bool? IsTuesday { get; set; }
        public bool? IsWednesday { get; set; }
        public bool? IsThursday { get; set; }
        public bool? IsFriday { get; set; }
        public bool? IsSaturday { get; set; }
        public bool? IsSunday { get; set; }
        public RepeatWorkType RepeatWorkType { get; set; } // Lặp theo
        public int? RepeatCycle { get; set; } // chu kỳ lặp
        public int? InDayOfWeek { get; set; } // Vào thứ đầu tiên trong tháng
        public int? InDayOfMonth { get; set; } // vào ngày thứ mấy của tháng
        public TimeSpan? RepeatHour { get; set; } // Giờ lặp

    }
    
    public enum RepeatWorkType
    {
        Day, // Ngày 
        Week, // Tuần
        Month, // Tháng 
        Year // Năm
    }

}
