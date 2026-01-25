using HRM_BE.Core.Models.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HRM_BE.Core.Models.DetailTimeSheet
{
    public class GetDetailTimeSheetPagingRequest:PagingRequest
    {
        public string? Name { get; set; }
        public int? Month {  get; set; }
        public int? Year {  get; set; }

        public int? OrganizationId { get; set; }
        public string? StaffPositionId { get; set; }
    }
}
