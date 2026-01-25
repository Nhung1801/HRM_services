using HRM_BE.Core.Data.Staff;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HRM_BE.Core.Data.Task
{
    public class Comment : EntityBase<int>
    {
        public int WorkId { get; set; }

        public string Content { get; set; }

        public string? Attachment { get; set; }

        public int? CommentsCount { get; set; }

        public int? EmployeeId { get; set; }

        public string? EmployeeName { get; set; }
        
        public int? ParentCommentId { get; set; }

        public virtual Employee? Employee { get; set; }

    }

}
