using HRM_BE.Core.Models.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HRM_BE.Core.Models.Profile
{
    public class GetContractPagingRequest : PagingRequest
    {
        public string? NameEmployee { get; set; }
        public string? Unit { get; set; }
        public int? UnitId { get; set; }
        public bool? ExpiredStatus { get; set; } 

    }
}
