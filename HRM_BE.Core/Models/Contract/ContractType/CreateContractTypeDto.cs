using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HRM_BE.Core.Models.Profile.ContractType
{
    public class CreateContractTypeDto
    {
        public string? Name { get; set; }
        public bool? IsDeleted { get; set; } = false;
    }
}
