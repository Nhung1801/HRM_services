using HRM_BE.Core.Data.Task;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HRM_BE.Core.Models.Work
{
    public class RemindWorkDto
    {
        public int WorkId { get; set; }
        public RemindWorkType RemindWorkType { get; set; }
        public double? TimeRemindStart { get; set; } // thời gian bắt đầu nhắc tính bằng giờ
        public double? TimeRemindEnd { get; set; }
    }
}
