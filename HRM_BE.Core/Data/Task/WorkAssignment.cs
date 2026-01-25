using HRM_BE.Core.Data.Staff;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HRM_BE.Core.Data.Task
{
    public class WorkAssignment // người liên quan đến công việc
    {
        public int WorkId { get; set; }
        public int AssigneeId { get; set; }
        public virtual Work Work { get; set; }
        public virtual Employee Assignee { get; set; }
    }
}
