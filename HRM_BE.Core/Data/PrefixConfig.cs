using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HRM_BE.Core.Data
{
    public class PrefixConfig:EntityBase<int>
    {
        public string Key { get; set; }
        public string Value { get; set; }
    }
}
