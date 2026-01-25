using HRM_BE.Core.Data.Staff;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HRM_BE.Core.Data.Official_Form
{
    //ĐƠn xin từ chức, nghỉ việc hẳn
    public class ResignationLetter:EntityBase<int>
    {
        public int? EmployeeId { get; set; }
        public virtual Employee Employee { get; set; }
    }
}
