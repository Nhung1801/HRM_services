using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HRM_BE.Core.Data.Profile
{
    public class ContractType : EntityBase<int>
    {
        public string? Name { get; set; }
        public bool? ContractTypeStatus { get; set; } = true;
        public virtual List<Contract> Contracts { get; set; }
    }
}
