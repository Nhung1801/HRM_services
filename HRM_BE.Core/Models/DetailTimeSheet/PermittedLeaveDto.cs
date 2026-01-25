using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HRM_BE.Core.Models.DetailTimeSheet
{
    public class PermittedLeaveDto
    {
        public int Id { get; set; }
        public List<DateTime> Date { get; set; }
        public double NumberOfDays { get; set; }

    }
}
