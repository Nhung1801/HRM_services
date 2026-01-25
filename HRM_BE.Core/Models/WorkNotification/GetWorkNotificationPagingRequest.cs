using HRM_BE.Core.Models.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HRM_BE.Core.Models.WorkNotification
{
    public class GetWorkNotificationPagingRequest:PagingRequest
    {
        public string? KeyWord { get; set; }
        public int? EmployeeId { get; set; }
        public int? WorkId { get; set; }
        public int? RemindWorkId { get; set; }
        
    }
}
