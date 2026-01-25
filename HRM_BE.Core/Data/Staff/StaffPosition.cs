using HRM_BE.Core.Data.Payroll_Timekeeping.Payroll;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace HRM_BE.Core.Data.Staff
{
    public class StaffPosition:EntityBase<int> 
    {
        public string PositionCode { get; set; } // mã vị trí
        public string PositionName { get; set; } // tên vị trí
        public int? GroupPositionId { get; set; } // nhóm vị trí FK GroupPosition
        public int? StaffTitleId {  get; set; } // chức danh FK StaffTitle
        [JsonIgnore]
        public virtual List<OrganizationPosition> OrganizationPositions { get; set; }
        public bool? StaffPositionStatus { get; set; } = true;
        // Thêm danh sách các vị trí thuộc về tổ chức này
        public virtual GroupPosition GroupPosition { get; set; }
        public virtual StaffTitle StaffTitle { get; set; }
        public virtual ICollection<PayrollStaffPosition> PayrollStaffPositions { get; set; }


    }
}
