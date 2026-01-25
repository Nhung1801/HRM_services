using HRM_BE.Core.Data.Identity;

namespace HRM_BE.Core.Models.Identity.Permission
{
    public class GetPermissonRequest
    {
        public Guid? RoleId { get; set; }
        public string? Name { get; set; }
        public string? Description { get; set; }
        public Section? Section { get; set; }

    }
}
