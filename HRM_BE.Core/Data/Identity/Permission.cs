using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HRM_BE.Core.Data.Identity
{
    public class Permission : EntityBase<int>
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string DisplayName { get; set; }

        public int? ParentPermissionId { get; set; }

        public string? Description { get; set; }

        public Section? Section { get; set; } = HRM_BE.Core.Data.Identity.Section.Privilege; // Phần

        public Permission? ParentPermission { get; set; }

        public virtual List<RolePermission> RolePermissions { get; set; }
    }


    public enum Section
    {
        Privilege,//Đặc quyền
        HumanResourcesInformation,//Thông tin nhân sự
        Timekeeping,//Chấm công
        Payroll//Tính lương
    }

}
