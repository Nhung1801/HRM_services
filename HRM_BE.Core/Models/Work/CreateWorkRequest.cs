using HRM_BE.Core.Data.Task;
using HRM_BE.Core.Models.Approval;
using HRM_BE.Core.Models.CheckList;
using HRM_BE.Core.Models.RemindWork;
using HRM_BE.Core.Models.SubWork;
using HRM_BE.Core.Models.Tag;
using HRM_BE.Core.Models.Work;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace HRM_BE.Core.Models.WorkModelModel
{
    public class CreateWorkRequest
    {
        public int? ReporterId { get; set; } // Người giao việc
        public int? ExecutorId { get; set; } // Người thực hiện
        public int? ProjectId { get; set; } // Dự án
        public int? GroupWorkId { get; set; } // Nhóm công việc
        public WorkPiority WorkPiority { get; set; }
        public string? Name { get; set; } // Tên công việc
        public string? Description { get; set; } // Mô tả
        public DateTime? StartTime { get; set; } // Thời gian bắt đầu
        public DateTime? DueDate { get; set; } // Hạn hoàn thành
        public bool IsPin { get; set; } // trạng thái ghim
        public string? FilePath { get; set; }
        public List<CreateTagWorkRequest>? TagWorks { get; set; }
        public List<CreateCheckListRequest>? CheckLists { get; set; }
        public List<CreateApprovalRequest>? Approvals { get; set; }
        public CreateRemindWorkRequest? RemindWork { get; set; }
        public List<CreateSubWorkRequest>? SubWorks { get; set; }
        public List<CreateWorkAssignmentRequest>? WorkAssignments { get; set; }

    }
}
