using HRM_BE.Core.Data;
using HRM_BE.Core.Models.Company;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HRM_BE.Core.Models.Organization
{
    public class OrganizationTypeDto
    {
        public int Id { get; set; }
        public int CompanyId { get; set; }
        public string OrganizationTypeName { get; set; } // tên của cấp tổ chức

    }
}
