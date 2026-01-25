using HRM_BE.Core.Models.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HRM_BE.Core.Models.ShiftCatalog
{
    public class GetShiftCatalogPagingRequest:PagingRequest
    {
        public string? Name { get; set; }//Tên 
        public int? OrganizationId { get; set; }
    }
}
