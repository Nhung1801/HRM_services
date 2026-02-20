using HRM_BE.Core.Data.Identity;

namespace HRM_BE.Core.Models.Identity.Permission
{
    public class UpdatePermissionRequest
    {
        public string? Name { get; set; }

        public string? DisplayName { get; set; }

        public int? ParentPermissionId { get; set; }

        public string? Description { get; set; }

        public Section? Section { get; set; }
    }
}

