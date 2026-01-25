using HRM_BE.Core.Data;
using HRM_BE.Core.Data.Company;
using HRM_BE.Core.Data.Staff;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HRM_BE.Core.Models.Organization
{
    public class OrganizationLeaderDto
    {
        public OrganizationLeaderType OrganizationLeaderType { get; set; }
        public GetOrganizationLeaderDto Employee { get; set; }
    }
}
