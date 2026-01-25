using HRM_BE.Core.Data.Task;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HRM_BE.Core.Models.RemindWork
{
    public class CreateRemindWorkRequest
    {
        public RemindWorkType RemindWorkType { get; set; }
        public double? TimeRemindStart { get; set; } // thời gian bắt đầu nhắc tính bằng giờ
        public double? TimeRemindEnd { get; set; }
    }
}
