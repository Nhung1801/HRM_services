using HRM_BE.Core.Models.Identity.Role;
using HRM_BE.Core.Models.Staff;
using Microsoft.AspNetCore.Identity;


namespace HRM_BE.Core.Models.Identity.User
{
    public class UserDto : IdentityUser<int>
    {
        public string? Name { get; set; }

        public string? PhoneNumber { get; set; }

        public string? Email { get; set; }

        public string? AvatarUrl { get; set; }

        public List<string> Permissions { get; set; }

        public List<RoleDto> Roles { get; set; }

        public List<string> RoleNames { get; set; }

        public string? Address { get; set; }

        public bool? IsRefreshToken { get; set; }

        public  UserEmployeeDto? Employee { get; set; }

        public  UserCompanyDto? Company { get; set; }

        public UserOrganizationDto Organization { get; set; }

        //public int? CityId { get; set; }

        //public string? CityName { get; set; }

        //public int? DistrictId { get; set; }

        //public string? DistrictName { get; set; }

        //public int? WardId { get; set; }

        //public string? WardName { get; set; }





    }
}
