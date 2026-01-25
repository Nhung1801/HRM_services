using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HRM_BE.Core.Models.Contract
{
    public class UpdateContractExpiredStatusRequest
    {
        public DateTime? ExpiryDate { get; set; }
        public bool? ExpiredStatus { get; set; } = false;

    }
}
