using HRM_BE.Core.Models.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HRM_BE.Core.Models.SumaryTimeSheet
{
    public class GetSummaryTimeSheetPagingRequest:PagingRequest
    {
        public int? SummaryTimesheetId { get ; set; }
        public string? Name { get; set; }
        public int? OrganizationId { get; set; }
        public int? Month { get; set; }
        public int? Year { get; set; }

    }
}
