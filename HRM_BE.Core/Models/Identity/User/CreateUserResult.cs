using Microsoft.AspNetCore.Identity;

namespace HRM_BE.Core.Models.Identity.User
{
    public class CreateUserResult
    {
        public IdentityResult? AddUserResult { get; set; }

        public IdentityResult? AddRoleResult { get; set; }

    }
}
