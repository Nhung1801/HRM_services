using HRM_BE.Core.Models.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HRM_BE.Core.Models.Payroll_Timekeeping.TimekeepingRegulation
{
    public class PagingApplyOrganizationRequest : PagingRequest
    {
        public int? TimekeepingSettingId { get; set; }//Bảng chấm công
        public int? OrganizationId { get; set; } // tổ chức công ty
        public int? TimekeepingLocationId { get; set; } // Địa điểm chấm công   
    }
}
