using HRM_BE.Core.Data.Staff;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace HRM_BE.Core.Data.Company
{
    public class OrganizationLeader
    {
        public int OrganizationId { get; set; }
        [JsonIgnore]
        public Organization Organization { get; set; }
        public OrganizationLeaderType OrganizationLeaderType { get; set; } = OrganizationLeaderType.Member;
        public int EmployeeId { get; set; }
        public Employee Employee { get; set; }
    }

    public enum OrganizationLeaderType
    {
        Leader,
        Member
    }
}
