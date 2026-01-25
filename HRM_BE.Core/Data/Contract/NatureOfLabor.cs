using HRM_BE.Core.Data.Profile;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HRM_BE.Core.Data.Profile
{
    public class NatureOfLabor : EntityBase<int>
    {
        public string? Name { get; set; }
        public virtual List<Contract> Contracts { get; set; }
    }
}
