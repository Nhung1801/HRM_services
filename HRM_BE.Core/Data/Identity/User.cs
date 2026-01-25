using HRM_BE.Core.Data.Staff;
using Microsoft.AspNetCore.Identity;

namespace HRM_BE.Core.Data.Identity
{
    public class User : IdentityUser<int>
    {
        public string? Name { get; set; }

        public string? AvatarUrl { get; set; }

        public int? Sex { get; set; }

        public string? Address { get; set; }

        //public int? CityId { get; set; }

        //public string? CityName { get; set; }

        //public int? DistrictId { get; set; }

        //public string? DistrictName { get; set; }

        //public int? WardId { get; set; }

        //public string? WardName { get; set; }

        public DateTime? BirthDay { get; set; }

        public bool? Status { get; set; } = true;

        public bool? IsDeleted { get; set; }=false;

        public string? RefreshToken { get; set; }

        public bool? IsRefreshToken { get; set; }

        public bool IsActivated { get; set; } = false; // Mặc định chưa kích hoạt
        public string? ActivationCode { get; set; } // Mã kích hoạt duy nhất
        public DateTime? ActivationExpiry { get; set; } // Thời gian hết hạn mã kích hoạt

        public bool? IsLockAccount { get; set; } = false; // Mặc định chưa bị khóa

        public int? EmployeeId { get; set; }

        public DateTime? CreatedAt { get; set; }

        public DateTime? UpdatedAt { get; set; }

        public DateTime? RefreshTokenExpiryTime { get; set; }

        #region Relationship

        public virtual Employee? Employee { get; set; }

        //public virtual List<UserRole>? UserRoles { get; set; }

        public virtual ICollection<IdentityUserRole<int>> UserRoles { get; set; }


        ////public virtual District? District { get; set; }

        ////public virtual City? City { get; set; }

        ////public virtual Ward? Ward { get; set; }

        ////public virtual ICollection<UserBranch>? UserBranch { get; set; }


        #endregion
    }
}
