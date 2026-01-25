using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HRM_BE.Core.Models.DetailTimeSheet
{
    public class GetDetailTimeSheetStaffPositionDto
    {
        public int Id { get; set; }
        public string PositionCode { get; set; } // mã vị trí
        public string PositionName { get; set; } // tên vị trí
    }
}
