using HRM_BE.Core.Data.Staff;
using HRM_BE.Core.Data.Task;
using HRM_BE.Core.Models.GroupWorkModel;
using HRM_BE.Core.Models.Work;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HRM_BE.Core.Models.WorkModel
{
    public class WorkDto
    {
        public int Id { get; set; }
        public int? ExecutorId { get; set; } // người thực hiện
        public int? ReporterId { get; set; } // Người giao việc
        public int? ProjectId { get; set; } // Dự án
        public int? GroupWorkId { get; set; } // Nhóm công việc
        public string? Name { get; set; } // Tên công việc
        public WorkPiority WorkPiority { get; set; } // Độ Ưu tiên 
        public string? Description { get; set; } // Mô tả
        public DateTime? StartTime { get; set; } // Thời gian bắt đầu
        public DateTime? DueDate { get; set; } // Hạn hoàn thành
        public bool IsPin { get; set; } // trạng thái ghim
        public string? FilePath { get; set; }
        public virtual GroupWorkDto GroupWork { get; set; }
        public virtual ReportWorkDto Reporter { get; set; }
        public virtual ExecutorWorkDto Executor { get; set; }

        public virtual ICollection<SubWorkDto> SubWorks { get; set; }
        public virtual ICollection<TagWorkDto> TagWorks { get; set; }
        public virtual ICollection<ApprovalWorkDto> Approvals { get; set; }
        public virtual RemindWorkDto RemindWork { get; set; }
        public virtual ICollection<CheckListWorkDto> CheckLists { get; set; }
        public virtual ICollection<WorkAssignmentDto> WorkAssignments { get; set; } // người liên quan đến công việc
    }
}
