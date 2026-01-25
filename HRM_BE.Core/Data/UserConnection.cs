using HRM_BE.Core.Data.Identity;
using HRM_BE.Core.Data.Staff;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HRM_BE.Core.Data
{
    public class UserConnection:EntityBase<int>
    {
        public int EmployeeId { get; set; }
        public string ConnectionId { get; set; }
        public virtual Employee Employee { get; set; } 
    }
}
