using HRM_BE.Core.Data.Task;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HRM_BE.Core.Models.WorkNotification
{
    public class RemindWorkNotificationDto
    {
        public int? WorkId { get; set; }
        public int? RemindWorkId { get; set; }
        public NotificationType NotificationType { get; set; }
        public string? Content { get; set; }
    }
}
