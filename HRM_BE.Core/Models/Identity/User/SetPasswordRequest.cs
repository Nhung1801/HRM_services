using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HRM_BE.Core.Models.Identity.User
{
    public class SetPasswordRequest
    {
        public string Email { get; set; }
        public string? ActivationCode { get; set; }
        public string? Otp { get; set; }
        public string? NewPassword { get; set; }
    }
}
