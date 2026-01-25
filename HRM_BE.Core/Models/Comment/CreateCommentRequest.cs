using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HRM_BE.Core.Models.Comment
{
    public class CreateCommentRequest
    {
        public int WorkId { get; set; }

        public string? Content { get; set; }

        public string? Attachment { get; set; }

        public int? EmployeeId { get; set; }

        public string? EmployeeName { get; set; }

        public int? ParentCommentId { get; set; }


    }
}
