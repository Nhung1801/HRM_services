using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HRM_BE.Core.Data.Staff
{
    public class StaffTitle:EntityBase<int>
    {
        public string StaffTitleName { get; set; }
    }
}
