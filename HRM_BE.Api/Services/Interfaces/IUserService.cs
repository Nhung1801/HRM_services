using HRM_BE.Core.Data.Identity;
using HRM_BE.Core.Models.Common;
using HRM_BE.Core.Models.Identity.User;
using HRM_BE.Core.Models.Staff;

namespace HRM_BE.Api.Services.Interfaces
{
    public interface IUserService
    {
        Task<UserDto> GetById(EntityIdentityRequest<int> request);

        Task<UserDto> GetUserInfo(HttpContext httpContext);

        Task<UserDto> GetUserInfoAsync();

        Task<List<string>> GetRoleByUserAsync(User user);

        Task<List<string>> GetPermissionByUserAsync(User user);

        Task<User> EditUserInfo(EditUserInfoRequest request);

        Task<UserDto> AssignUserToRolesAsync(AssignUserToRoleRequest request);

        Task<UserDto> AssignEmployeeToRolesAsync(AssignEmployeeToRoleRequest request);

        Task<ConfirmEmailResult> VerifyEmailWithOtp(string? email, string otp);



    }
}
