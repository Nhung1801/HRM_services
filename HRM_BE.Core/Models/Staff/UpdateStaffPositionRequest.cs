using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HRM_BE.Core.Models.Staff
{
    public class UpdateStaffPositionRequest
    {
        public string PositionCode { get; set; } // mã vị trí
        public string PositionName { get; set; } // tên vị trí
        public int? GroupPositionId { get; set; } // nhóm vị trí FK GroupPosition
        public int? StaffTitleId { get; set; } // chức danh FK StaffTitle
        public bool? StaffPositionStatus { get; set; }
        public List<UpdateOrganizationPositionRequest> OrganizationPositions { get; set; }

    }
}
