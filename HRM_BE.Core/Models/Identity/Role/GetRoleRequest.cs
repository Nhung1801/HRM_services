
using HRM_BE.Core.Models.Common;

namespace HRM_BE.Core.Models.Identity.Role
{
    public class GetRoleRequest: PagingRequest
    {
        public string? Name { get; set; }
        public string? Description { get; set; }
    }
}
