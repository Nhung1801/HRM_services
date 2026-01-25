using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HRM_BE.Core.Data.ProfileEntity
{
    public class JobType:EntityBase<int>
    {
       public string? JobTypeName { get; set; }
    }
}
