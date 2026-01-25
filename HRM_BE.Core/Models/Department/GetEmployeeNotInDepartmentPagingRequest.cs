using HRM_BE.Core.Data.Staff;
using HRM_BE.Core.Models.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HRM_BE.Core.Models.Department
{
    public class GetEmployeeNotInDepartmentPagingRequest: PagingRequest
    {
        public string? keyWord { get; set; }
        public int? OrganizationId { get; set; }
        public int? LeaderOrganizationId { get; set; }
        public int? StaffPositionId { get; set; }
        public WorkingStatus? WorkingStatus { get; set; }
        public AccountStatus? AccountStatus { get; set; }
        public int? CityId { get; set; }
        public int? DistrictId { get; set; }
        public int? WardId { get; set; }
        public int? StreetId { get; set; }

        public int DepartmentId { get; set; }

    }
}
