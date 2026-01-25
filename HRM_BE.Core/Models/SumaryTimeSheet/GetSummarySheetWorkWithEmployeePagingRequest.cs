using HRM_BE.Core.Models.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HRM_BE.Core.Models.SumaryTimeSheet
{
    public class GetSummarySheetWorkWithEmployeePagingRequest:PagingRequest
    {
        public int Id { get; set; }
        public required int OrganizationId { get; set; }
        public string? KeyWord { get; set; }
        public int? StaffPositionId { get; set; }

    }
}
