using HRM_BE.Core.Data.Staff;
using HRM_BE.Core.Models.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HRM_BE.Core.Models.Profile
{
    public class GetProfilePagingRequest : PagingRequest
    {
        public int? employeeId { get; set; }
        public int? organizationId { get; set; }
        public WorkingStatus? workingStatus { get; set; }
    }
}
