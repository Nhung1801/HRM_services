using HRM_BE.Core.Data.Payroll_Timekeeping.Payroll;
using HRM_BE.Core.Models.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HRM_BE.Core.Models.Payroll_Timekeeping.Payroll
{
    public class PagingPayrollInquiryRequest : PagingRequest
    {
        public int? PayrollDetailId { get; set; } // ID của bảng lương chi tiết
        public int? PayrollId { get; set; } // Id của bảng lương 
    }
}
