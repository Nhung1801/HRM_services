using HRM_BE.Core.Data.Staff;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HRM_BE.Core.Models.Work
{
    public class WorkAssignmentDto
    {
        public int WorkId { get; set; }
        public int AssigneeId { get; set; }
        public virtual ExecutorWorkDto Assignee { get; set; }
    }
}
