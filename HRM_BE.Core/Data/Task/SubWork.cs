using HRM_BE.Core.Data.Staff;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HRM_BE.Core.Data.Task
{
    public class SubWork:EntityBase<int>
    {
        public int WorkId { get; set; }
        public string? Name { get; set; }
        public int AssignEmployeeId { get; set; } // người được giao việc
        public DateTime? StartDate { get; set; }
        public DateTime? DueDate { get; set; }
        public bool IsFinish { get; set; } // trạng thái hoàn thành
        public virtual Employee AssignEmployee { get; set; }
        public virtual Work Work { get; set; }

    }
}
