using HRM_BE.Core.Models.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HRM_BE.Core.Models.Staff
{
    public class GetPagingStaffPositionRequest : PagingRequest
    {
        public string? KeyWord { get; set; } // mã vị trí
        public bool? Status { get; set; }
    }
}
