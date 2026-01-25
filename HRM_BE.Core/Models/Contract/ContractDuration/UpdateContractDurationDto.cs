using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HRM_BE.Core.Models.Profile.ContractDuration
{
    public class UpdateContractDurationDto
    {
        public int? Id { get; set; }
        public string? Duration { get; set; }
        public bool? ContractDurationStatus { get; set; }
        public bool? IsDeleted { get; set; }
    }
}
