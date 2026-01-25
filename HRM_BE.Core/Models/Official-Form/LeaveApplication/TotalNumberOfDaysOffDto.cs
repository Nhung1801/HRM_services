using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HRM_BE.Core.Models.Official_Form.LeaveApplication
{
    public class TotalNumberOfDaysOffDto
    {

        public required int EmployeeId { get; set; } //Id nhân viên

        public DateTime? StartDate { get; set; }

        public DateTime? EndDate { get; set; }

        public double? TotalNumberOfDaysOff { get; set; } = 0;

        public List<TotalNumberOfDaysOffGroupByTypeOfLeave> TotalNumberOfDaysOffGroupByTypeOfLeaves { get; set; }

    }

    public class TotalNumberOfDaysOffGroupByTypeOfLeave
    {
        public int? TypeOfLeaveId { get; set; }

        public string? TypeOfLeaveName { get; set; }

        public double? NumberOfDaysOff { get; set; } = 0;
    

    }
}
