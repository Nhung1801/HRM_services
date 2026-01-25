using Microsoft.AspNetCore.Authorization;

namespace HRM_BE.Api.Attributes
{
    public class HasPermissionAttribute : AuthorizeAttribute
    {
        public HasPermissionAttribute(string permission) : base(policy: permission)
        {
        
        
        }
    }
}
