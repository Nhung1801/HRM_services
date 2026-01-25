using HRM_BE.Core.Data.Staff;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace HRM_BE.Core.Models.Staff
{
    public class CreateStaffPositionRequest
    {
        public string PositionCode { get; set; } // mã vị trí
        public string PositionName { get; set; } // tên vị trí
        public int? GroupPositionId { get; set; } // nhóm vị trí FK GroupPosition
        public int? StaffTitleId { get; set; } // chức danh FK StaffTitle
        public List<CreateOrganizationPositionRequest> OrganizationPositions { get; set; }
    }
}
