using HRM_BE.Core.Models.Staff;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HRM_BE.Core.Models.SumaryTimeSheet
{
    public class GetSummaryTimesheetNameStaffPositionDto
    {
        public int Id { get; set; }
        public string PositionCode { get; set; } // mã vị trí
        public string PositionName { get; set; } // tên vị trí
    }
}
