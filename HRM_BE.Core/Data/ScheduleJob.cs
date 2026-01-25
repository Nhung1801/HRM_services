using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HRM_BE.Core.Data
{
    public class ScheduleJob:EntityBase<int>
    {
        public int WorkId { get; set; }
        public string JobId { get; set; }
        public string JobType { get; set; }
    }
}
