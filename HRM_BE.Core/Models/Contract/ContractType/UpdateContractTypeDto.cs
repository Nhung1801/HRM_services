using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HRM_BE.Core.Models.Profile.ContractType
{
    public class UpdateContractTypeDto
    {
        public int? Id { get; set; }
        public string? Name { get; set; }
        public bool? ContractTypeStatus { get; set; }
        public bool? IsDeleted { get; set; }
    }
}
