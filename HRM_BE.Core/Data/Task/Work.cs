using HRM_BE.Core.Data.Staff;
using Microsoft.VisualBasic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HRM_BE.Core.Data.Task
{
    // Bảng công việc
    public class Work : EntityBase<int>
    {
        public int? ReporterId { get; set; } // Người giao việc
        public int? ExecutorId { get; set; } // Người thực hiện
        public int? ProjectId { get; set; } // Dự án
        public int? GroupWorkId { get; set; } // Nhóm công việc
        public string? Name { get; set; } // Tên công việc
        public WorkPiority WorkPiority { get; set; } // Độ Ưu tiên 
        public WorkStatus WorkStatus { get; set; } = WorkStatus.None;// Trạng thái công việc
        public string? Description { get; set; } // Mô tả
        public DateTime? StartTime { get; set; } // Thời gian bắt đầu
        public DateTime? DueDate { get; set; } // Hạn hoàn thành
        public bool IsPin { get; set; } // trạng thái ghim
        public string? FilePath { get; set; }
        public virtual GroupWork GroupWork { get; set; }
        public virtual Employee Reporter { get; set; } 
        public virtual Employee Executor { get; set; } 
        public virtual ICollection<SubWork> SubWorks { get; set; }
        public virtual ICollection<TagWork> TagWorks { get; set; }
        public virtual ICollection<Approval> Approvals { get; set; }
        public virtual RemindWork RemindWork { get; set; }
        public virtual ICollection<CheckList> CheckLists { get; set; }
        public virtual ICollection<WorkAssignment> WorkAssignments { get; set; } // người liên quan đến công việc

    }
    public enum WorkPiority
    {
        High,
        Medium,
        Low
    }
    public enum WorkStatus
    {
        None,
        InProgress,
        Done,
        Cancel,
        overdue
    }
}
