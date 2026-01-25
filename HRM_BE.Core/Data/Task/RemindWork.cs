using HRM_BE.Core.Data.Staff;
using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HRM_BE.Core.Data.Task
{
    public class RemindWork : EntityBase<int>
    {
        public int WorkId { get; set; }
        public RemindWorkType RemindWorkType { get; set; }
        public double? TimeRemindStart { get; set; } // thời gian bắt đầu nhắc tính bằng giờ
        public double? TimeRemindEnd { get; set; }
        public virtual Work Work { get; set; }
    }
    public enum RemindWorkType
    {
        None,
        RemindStart,
        RemindEnd,
        BothRemind
    }
    public class RemindWorkNotification : EntityBase<int>
    {
        public int? WorkId { get; set; }
        public int? RemindWorkId { get; set; }
        public NotificationType NotificationType { get; set; }
        public string? Content { get; set; }

        public virtual RemindWork RemindWork { get; set; }
        public virtual Work Work { get; set; }

    }
    public enum NotificationType
    {
        None,
        RemindWork,
        Work
        
    }

}
