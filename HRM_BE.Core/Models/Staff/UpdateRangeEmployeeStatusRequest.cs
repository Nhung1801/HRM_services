using HRM_BE.Core.Data.Staff;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HRM_BE.Core.Models.Staff
{
    public class UpdateRangeEmployeeStatusRequest
    {
        public List<int> ids { get; set; }
        public AccountStatus accountStatus { get; set; }
    }
}
