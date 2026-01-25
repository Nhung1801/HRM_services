using HRM_BE.Core.Models.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HRM_BE.Core.Models.Project
{
    public class GetPagingProjectByEmployeeRequest:PagingRequest
    {
        public string? KeyWord { get; set; }

        public int EmployeeId { get; set; }
    }
}
