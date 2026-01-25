using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HRM_BE.Core.Models.Profile.WorkingForm
{
    public class UpdateWorkingFormDto
    {
        public int? Id { get; set; }
        public string? Form { get; set; }
        public bool? IsDeleted { get; set; }
        public bool? WorkingFormStatus { get; set; } 
    }
}
