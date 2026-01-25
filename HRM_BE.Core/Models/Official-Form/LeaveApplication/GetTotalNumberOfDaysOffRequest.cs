using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HRM_BE.Core.Models.Official_Form.LeaveApplication
{
    public class GetTotalNumberOfDaysOffRequest
    {
        public required int EmployeeId { get; set; } //Id nhân viên

        public DateTime? StartDate { get; set; }


        public DateTime? EndDate { get; set; }

    }
}
