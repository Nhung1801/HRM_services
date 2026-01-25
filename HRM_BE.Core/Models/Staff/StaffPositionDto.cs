using HRM_BE.Core.Data.Staff;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HRM_BE.Core.Models.Staff
{
    public class StaffPositionDto
    {
        public int Id { get; set; }
        public string PositionCode { get; set; } // mã vị trí
        public string PositionName { get; set; } // tên vị trí
        public int? GroupPositionId { get; set; } // nhóm vị trí FK GroupPosition
        public int? StaffTitleId { get; set; } // chức danh FK StaffTitle
        public bool? StaffPositionStatus { get; set; }
        public virtual GroupPositionDto GroupPosition { get; set; }
        public virtual StaffTitleDto StaffTitle { get; set; }
        public virtual List<GetOranizationPositionDto> OrganizationPositions { get; set; }

    }
}
