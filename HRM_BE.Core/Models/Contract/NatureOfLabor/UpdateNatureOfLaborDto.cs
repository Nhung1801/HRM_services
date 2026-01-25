using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HRM_BE.Core.Models.Contract.NatureOfLabor
{
    public class UpdateNatureOfLaborDto
    {
        public string? Name { get; set; }
        public bool? IsDeleted { get; set; }
    }
}
