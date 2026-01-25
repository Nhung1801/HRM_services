using HRM_BE.Core.Models.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HRM_BE.Core.Models.DetailTimeSheet
{
    public class GetDetailTimeSheetWithEmplopyeePagingRequest:PagingRequest
    {
        public required int DetailTimeSheetId { get; set; }
        public string? KeyWord { get; set; }
        public required int OrganizationId { get; set; }
    }
}
