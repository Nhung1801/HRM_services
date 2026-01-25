using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HRM_BE.Core.Models.SumaryTimeSheet
{
    public class GetStatusByEmployeeRequest
    {
        public int EmployeeId { get; set; }

        public int SumaryTimeSheetId { get; set; } 
    }
}
