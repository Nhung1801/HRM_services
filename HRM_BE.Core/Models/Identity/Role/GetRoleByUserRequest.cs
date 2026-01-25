

using HRM_BE.Core.Models.Common;

namespace HRM_BE.Core.Models.Identity.Role
{
    public class GetRoleByUserRequest:PagingRequest
    {
        public int UserId { get; set; }
    }
}
