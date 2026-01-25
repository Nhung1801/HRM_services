using HRM_BE.Core.Data.Identity;
using HRM_BE.Core.Models.Auth;
using HRM_BE.Core.Models.Common;
using HRM_BE.Core.Models.Identity.User;
using HRM_BE.Core.Models.Mail;
using Microsoft.AspNetCore.Mvc;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;

namespace HRM_BE.Api.Services.Interfaces
{
    public interface IAuthService
    {

        Task<string> CreateToken(User user);

        Task<bool> SendOtpMail(string toMail, string subject, string body);
    
        Task<string> VerifyOtpLoginEmail(VerifyOtpLoginEmailRequest request);

        #region Token
        JwtSecurityToken CreateToken(List<Claim> claims);

        string CreateRefreshToken();

        Task<bool> RevokeRefreshToken(string username);

        Task<LoginResult> RefreshTokenNoTranRole(string refreshToken);

        Task<LoginResult> RefreshToken(string refreshToken);

        #endregion


        #region User
        Task<bool> Logout();

        #endregion
    }
}
