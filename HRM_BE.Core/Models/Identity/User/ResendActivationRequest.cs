using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HRM_BE.Core.Models.Identity.User
{
    public class ResendActivationRequest
    {
        [Required]
        public List<string> Emails { get; set; } = new List<string>();
        public string? UrlClient { get; set; }
    }
}
