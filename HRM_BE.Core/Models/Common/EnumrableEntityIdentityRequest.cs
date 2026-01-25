using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HRM_BE.Core.Models.Common
{
    public class EnumrableEntityIdentityRequest<T>
    {
        public IEnumerable<T?>? Ids { get; set; }
    }
}
