using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HRM_BE.Core.Models.DetailTimeSheet
{
    public class StatiscTimeSheetDto
    {
        public int TotalWokring { get; set; } // đi làm
        public int TotalLeaveWorking { get; set; } // nghỉ làm
        public int TotalLateEarly { get; set; } // đi muộn về sớm
        public int TotalNotCheck { get; set; } // không chấm công
    }
}
