
using HRM_BE.Core.Data.Identity;
using HRM_BE.Core.Models.Common;

namespace HRM_BE.Core.Models.Identity.Permission
{
    public class GetPermissionRequest:PagingRequest
    {
        public string? Name { get; set; }
        public string? Description { get; set; }
        public string? DisplayName { get; set; }
        public Section? Section { get; set; }


    }
}
