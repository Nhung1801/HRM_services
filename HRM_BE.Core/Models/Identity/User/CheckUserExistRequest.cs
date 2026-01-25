using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HRM_BE.Core.Models.Identity.User
{
    public class CheckUserExistRequest
    {
        public string? PhoneNumber { get; set; }

        public string? Email { get; set; }
    }
}
