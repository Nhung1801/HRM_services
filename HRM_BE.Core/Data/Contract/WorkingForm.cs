using HRM_BE.Core.Data.Company;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HRM_BE.Core.Data.Profile
{
    public class WorkingForm : EntityBase<int>
    {
        public string? Form {  get; set; }
        public bool? WorkingFormStatus { get; set; } = true;
        public virtual List<Contract> Contracts { get; set; }
    }
}
