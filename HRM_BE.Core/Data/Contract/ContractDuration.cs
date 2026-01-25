using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HRM_BE.Core.Data.Profile
{
    public class ContractDuration : EntityBase<int>
    {
        public string? Duration { get; set; }
        public bool? ContractDurationStatus { get; set; } = true;
        public virtual List<Contract> Contracts { get; set; }
    }
}
