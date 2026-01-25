using HRM_BE.Api.Attributes;
using HRM_BE.Api.Hubs;
using HRM_BE.Api.Services;
using HRM_BE.Api.Services.Interfaces;
using HRM_BE.Core.Constants.Identity;
using HRM_BE.Core.Data.Identity;
using HRM_BE.Core.Models.Common;
using HRM_BE.Core.Models.Identity.Role;
using HRM_BE.Core.Models.Identity.User;
using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SignalR;
using Microsoft.EntityFrameworkCore;
using HRM_BE.Api.Extension;
using HRM_BE.Core.Data.Staff;
using HRM_BE.Core.Models.Staff;

namespace HRM_BE.Api.Controllers.Identity
{
    [Route("api/user")]
    [ApiController]
    public class UserController : ControllerBase
    {

        private readonly UserManager<User> _userManager;
        private readonly IUserService _userService;
        private readonly IMapper _mapper;
        private readonly IRoleService _roleService;
        private readonly IHubContext<RefreshTokenHub> _hubContext;



        public UserController(UserManager<User> userManager, IUserService userService, IMapper mapper, IRoleService roleService, IHubContext<RefreshTokenHub> hubContext)
        {
            _userManager = userManager;
            _userService = userService;
            _mapper = mapper;
            _roleService = roleService;
            _hubContext = hubContext;
        }


        [HttpGet("paging")]
        //[HasPermission(PermissionConstant.ManageUserView)]
        public async Task<ApiResult<PagingResult<UserDto>>> GetPaging([FromQuery] GetUserRequest request)
        {
            var query = _userManager.Users;

            if (!string.IsNullOrEmpty(request.Name))
            {
                query = query.Where(x => x.Name.Contains(request.Name));
            }
            if (!string.IsNullOrEmpty(request.PhoneNumber))
            {
                query = query.Where(x => x.PhoneNumber.Contains(request.PhoneNumber));
            }
            if (!string.IsNullOrEmpty(request.Email))
            {
                query = query.Where(x => x.Email.Contains(request.Email));
            }
            if (!string.IsNullOrEmpty(request.Address))
            {
                query = query.Where(x => x.Address.Contains(request.Address));
            }
            if (request.IsDeleted.HasValue)
            {
                query = query.Where(x => x.IsDeleted == request.IsDeleted);
            }

            var totalRow = await query.CountAsync();


            query = query.Skip((request.PageIndex - 1) * request.PageSize)
               .Take(request.PageSize);

            var users = await _mapper.ProjectTo<UserDto>(query).ToListAsync();


            return new ApiResult<PagingResult<UserDto>>()
            {
                Status = true,
                Message = "Lấy danh sách người dùng thành công",
                Data = new PagingResult<UserDto>(users, request.PageIndex, request.PageSize, totalRow)
            };


        }

        [HttpGet("paging-info")]
        public async Task<ApiResult<PagingResult<UserDto>>> GetPagingInfo([FromQuery] GetUserRequest request)
        {
            var query = _userManager.Users;

            if (!string.IsNullOrEmpty(request.Name))
            {
                query = query.Where(x => x.Name.Contains(request.Name));
            }
            if (!string.IsNullOrEmpty(request.PhoneNumber))
            {
                query = query.Where(x => x.PhoneNumber.Contains(request.PhoneNumber));
            }
            if (!string.IsNullOrEmpty(request.Email))
            {
                query = query.Where(x => x.Email.Contains(request.Email));
            }
            if (!string.IsNullOrEmpty(request.Address))
            {
                query = query.Where(x => x.Address.Contains(request.Address));
            }
            if (request.IsDeleted.HasValue)
            {
                query = query.Where(x => x.IsDeleted == request.IsDeleted);
            }

            var totalRow = await query.CountAsync();


            query = query.Skip((request.PageIndex - 1) * request.PageSize)
               .Take(request.PageSize);

            var users = await _mapper.ProjectTo<UserDto>(query).ToListAsync();


            return new ApiResult<PagingResult<UserDto>>()
            {
                Status = true,
                Message = "Lấy danh sách người dùng thành công",
                Data = new PagingResult<UserDto>(users, request.PageIndex, request.PageSize, totalRow)
            };
        }

        [HttpGet("get-by-id")]
        public async Task<ApiResult<UserDto>> GetById([FromQuery] GetRoleByUserRequest request)
        {
            var id = new EntityIdentityRequest<int>()
            {
                Id = request.UserId,
            };
            var user = await _userService.GetById(id);
            var roles = await _roleService.GetByUser(request);
            if (user == null)
            {

                return new ApiResult<UserDto>
                {
                    Status = false,
                    Message = "Không có user có id như vậy",
                    Data = null
                };
            }
            user.Roles = roles.Items;

            return new ApiResult<UserDto>
            {
                Status = true,
                Message = "Thành công",
                Data = user
            };

        }

        [HttpGet("user-info")]
        public async Task<ApiResult<UserDto>> GetCurrentUser()
        {
            var user = await _userService.GetUserInfo(HttpContext);

            if (user == null)
            {
                return new ApiResult<UserDto>()
                {
                    Status = false,
                    Message = "Không tìm thấy thông tin người dùng hợp lệ!",
                    Data = null
                };
            }

            return new ApiResult<UserDto>()
            {
                Status = true,
                Message = "Lấy thông tin người dùng thành công!",
                Data = user
            };
        }

        [HttpGet("user-info-async")]
        public async Task<ApiResult<UserDto>> GetCurrentUserAsync()
        {
            var user = await _userService.GetUserInfoAsync();

            if (user == null)
            {
                return new ApiResult<UserDto>()
                {
                    Status = false,
                    Message = "Không tìm thấy thông tin người dùng hợp lệ!",
                    Data = null
                };
            }

            return new ApiResult<UserDto>()
            {
                Status = true,
                Message = "Lấy thông tin người dùng thành công!",
                Data = user
            };
        }

        [HttpPost("set-password")]
        public async Task<ApiResult<bool>> SetPassword([FromBody] SetPasswordRequest request)
        {
            var user = await _userManager.FindByEmailAsync(request.Email);
            if (user == null)
            {
                return new ApiResult<bool>
                {
                    Status = false,
                    Message = "Tài khoản không tồn tại trong hệ thống",
                    Data = false
                };
            }

            var success = await _userService.VerifyEmailWithOtp(request.Email, request.Otp);
            if (success.Success == false)
            {
                return new ApiResult<bool>
                {
                    Status = false,
                    Message = "Mã OTP không hợp lệ hoặc đã hết hạn",
                    Data = false
                };
            }

            user.PasswordHash = _userManager.PasswordHasher.HashPassword(user, request.NewPassword);
            var result = await _userManager.UpdateAsync(user);
            if (!result.Succeeded)
            {
                return new ApiResult<bool>
                {
                    Status = false,
                    Message = string.Join("<br>", result.Errors.Select(x => x.Description)),
                    Data = false
                };
            }

            return new ApiResult<bool>
            {
                Status = true,
                Message = "Tạo mới mật khẩu thành công",
                Data = true
            };
        }

        [HttpPut("edit-user-info")]
        public async Task<ApiResult<UserDto>> EditUserInfo([FromBody] EditUserInfoRequest request)
        {
            var result = await _userService.EditUserInfo(request);
            var userDto = _mapper.Map<UserDto>(result);

            return new ApiResult<UserDto>()
            {
                Status = true,
                Message = "Cập nhật thông tin người dùng thành công!",
                Data = userDto
            };
        }

        [HttpPut("assign-user-to-roles")]
        //[HasPermission(PermissionConstant.ManageUserEdit)]
        public async Task<ApiResult<UserDto>> AssignUserToRolesAsync([FromBody] AssignUserToRoleRequest request)
        {
            var user = await _userService.AssignUserToRolesAsync(request);

            await _hubContext.Clients.All.SendAsync("RefreshToken", user);

            return new ApiResult<UserDto>()
            {
                Status = true,
                Message = "Thành công",
                Data = user
            };
        }
        /// <summary>
        /// HRM-Gán quyền cho nhân viên
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        [HttpPut("assign-employee-to-roles")]
        //[HasPermission(PermissionConstant.ManageUserEdit)]
        public async Task<ApiResult<UserDto>> AssignEmployeeToRolesAsync([FromBody] AssignEmployeeToRoleRequest request)
        {
            var user = await _userService.AssignEmployeeToRolesAsync(request);

            await _hubContext.Clients.All.SendAsync("RefreshToken", user);

            return new ApiResult<UserDto>()
            {
                Status = true,
                Message = "Thành công",
                Data = user
            };
        }
        /// <summary>
        /// Là nhân viên, tôi muốn thay đổi mật khẩu tài khoản của mình
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>

        [HttpPost("change-password")]
        public async Task<ApiResult<bool>> ChangePassword([FromBody] ChangePasswordRequest request)
        {
            var userID = User.GetUserId(); // Lấy UserId từ token hoặc thông tin người dùng hiện tại
            var user = await _userManager.FindByIdAsync(userID.ToString());
            if (user == null)
            {
                return new ApiResult<bool>
                {
                    Status = false,
                    Message = "Người dùng không tồn tại",
                    Data = false
                };
            }

            // Check
            if (request.OldPassword == request.NewPassword)
            {
                return new ApiResult<bool>
                {
                    Status = false,
                    Message = "Mật khẩu mới không được phép giống mật khẩu cũ",
                    Data = false
                };
            }

            // Kiểm tra mật khẩu cũ
            var checkPassword = await _userManager.CheckPasswordAsync(user, request.OldPassword);
            if (!checkPassword)
            {
                return new ApiResult<bool>
                {
                    Status = false,
                    Message = "Mật khẩu cũ không đúng",
                    Data = false
                };
            }

            // Thay đổi mật khẩu
            var result = await _userManager.ChangePasswordAsync(user, request.OldPassword, request.NewPassword);
            if (!result.Succeeded)
            {
                return new ApiResult<bool>
                {
                    Status = false,
                    Message = string.Join("<br>", result.Errors.Select(e => e.Description)),
                    Data = false
                };

            }

            return new ApiResult<bool>
            {
                Status = true,
                Message = "Đổi mật khẩu thành công",
                Data = false
            };
        }

        /// <summary>
        ///  Là nhân viên/người dùng tôi muốn lấy lại mật khẩu khi quên API này sẽ thiết lập lại mật khẩu khi quên
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        [HttpPost("set-password-after-forgot-password")]
        public async Task<ApiResult<bool>> SetPasswordAfterForgotPassword([FromBody] SetPasswordRequest request)
        {
            // Tìm người dùng bằng email
            var user = await _userManager.FindByEmailAsync(request.Email);
            if (user == null)
            {
                return new ApiResult<bool>
                {
                    Status = false,
                    Message = "Tài khoản không tồn tại trong hệ thống",
                    Data = false
                };
            }

            // Xác thực OTP
            var otpVerification = await _userService.VerifyEmailWithOtp(request.Email, request.Otp);
            if (!otpVerification.Success)
            {
                return new ApiResult<bool>
                {
                    Status = false,
                    Message = "Mã OTP không hợp lệ hoặc đã hết hạn",
                    Data = false
                };
            }

            // Kiểm tra nếu mật khẩu không được cung cấp
            if (string.IsNullOrWhiteSpace(request.NewPassword))
            {
                return new ApiResult<bool>
                {
                    Status = false,
                    Message = "Mật khẩu không được để trống",
                    Data = false
                };
            }

            // Đặt mật khẩu mới
            user.PasswordHash = _userManager.PasswordHasher.HashPassword(user, request.NewPassword);
            var result = await _userManager.UpdateAsync(user);
            if (!result.Succeeded)
            {
                return new ApiResult<bool>
                {
                    Status = false,
                    Message = string.Join("<br>", result.Errors.Select(x => x.Description)),
                    Data = false
                };
            }

            return new ApiResult<bool>
            {
                Status = true,
                Message = "Tạo mới mật khẩu thành công",
                Data = true
            };
        }

        /// <summary>
        /// Kích hoạt/ngừng kích hoạt tài khoản
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        [HttpPost("toggle-account-status")]
        public async Task<ApiResult<bool>> ToggleAccountStatus([FromBody] LockUnlockUserRequest request)
        {
            var user = await _userManager.Users
                       .Include(u => u.Employee)
                       .FirstOrDefaultAsync(u => u.EmployeeId == request.EmployeeId);

            if (user == null)
            {
                return new ApiResult<bool>
                {
                    Status = false,
                    Message = "Không tìm thấy tài khoản tương ứng với nhân viên",
                    Data = false
                };
            }

            // Kiểm tra nhân viên liên kết với tài khoản
            if (user.Employee == null)
            {
                return new ApiResult<bool>
                {
                    Status = false,
                    Message = "Không tìm thấy thông tin nhân viên liên kết với tài khoản",
                    Data = false
                };
            }

            // Cập nhật trạng thái tài khoản
            if (request.AccountStatus == (int)AccountStatus.Active || request.AccountStatus == (int)AccountStatus.InActive)
            {
                user.Employee.AccountStatus = (AccountStatus)request.AccountStatus;

                // Set IsLock theo AccountStatus
                if (request.AccountStatus == (int)AccountStatus.Active)
                {
                    user.IsLockAccount = false;
                }
                else
                {
                    user.IsLockAccount= true;
                }
            }
            else
            {
                return new ApiResult<bool>
                {
                    Status = false,
                    Message = "Trạng thái tài khoản không hợp lệ. Chỉ được phép là 2 (Active) hoặc 3 (InActive).",
                    Data = false
                };
            }

            var result = await _userManager.UpdateAsync(user);
            if (!result.Succeeded)
            {
                return new ApiResult<bool>
                {
                    Status = false,
                    Message = "Cập nhật trạng thái tài khoản không thành công",
                    Data = false
                };
            }

            return new ApiResult<bool>
            {
                Status = true,
                Message = $"Trạng thái tài khoản đã được cập nhật thành: {(AccountStatus)request.AccountStatus}",
                Data = true
            };
        }
    }
}
