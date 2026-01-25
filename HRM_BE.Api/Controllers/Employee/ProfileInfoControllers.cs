using HRM_BE.Api.Services.Interfaces;
using HRM_BE.Core.Constants;
using HRM_BE.Core.Helpers;
using HRM_BE.Core.ISeedWorks;
using HRM_BE.Core.Models.Common;
using HRM_BE.Core.Models.ProfileInfoModel;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace HRM_BE.Api.Controllers.Employee
{
    [Route("api/profile-info")]
    [ApiController]
    public class ProfileInfoController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IFileService _fileService;
        public ProfileInfoController(IUnitOfWork unitOfWork, IFileService fileService)
        {
            _unitOfWork = unitOfWork;
            _fileService = fileService;
        }
        [HttpGet("get-by-id")]
        public async Task<ApiResult<ProfileInfoDto>> GetById([FromQuery] EntityIdentityRequest<int> request)
        {
            var profile = await _unitOfWork.ProfileInfos.GetById(request.Id);
            return ApiResult<ProfileInfoDto>.Success("Lấy thông tin hồ sơ thành công", profile);
        }
        [HttpPost("create")]
        public async Task<ApiResult<ProfileInfoDto>> Create([FromBody] CreateProfileInfoRequest request)
        {
            //if (request.AvatarImage != null) {
            //    request.AvatarUrl = await _fileService.UploadFileAsync(request.AvatarImage, PathFolderConstant.Avatar);
            //}
            //else
            //{
            //    request.AvatarUrl = ImageConstant.Avatar;
            //}
            request.ProfileCode = $"SMO{StringHelper.GenerateRandomCode(8)}";
            var result = await _unitOfWork.ProfileInfos.Create(request);
            return ApiResult<ProfileInfoDto>.Success("Thêm thông tin hồ sơ thành công", result);
        }
        [HttpPut("Update")]
        public async Task<IActionResult> Update(int id, [FromBody] UpdateProfileInfoRequest request)
        {
            //if (request.AvatarImage != null)
            //{
            //    request.AvatarUrl = await _fileService.UploadFileAsync(request.AvatarImage, PathFolderConstant.Avatar);
            //}
            await _unitOfWork.ProfileInfos.Update(id, request);
            return Ok(ApiResult<bool>.Success("Cập nhật thông tin hồ sơ thành công", true));
        }

        /// <summary>
        /// là Admin/HR tôi muốn cập nhật thông tin chung trong hồ sơ
        /// </summary>
        /// <param name="profileInfoId"></param>
        /// <param name="request"></param>
        /// <returns></returns>
        [HttpPut("UpdateV2")]
        public async Task<IActionResult> UpdateV2(int profileInfoId, [FromForm] UpdateProfileInfoRequestV2 request)
        {
            if (request.AvatarImage != null)
            {
                request.AvatarUrl = await _fileService.UploadFileAsync(request.AvatarImage, PathFolderConstant.Avatar);
            }

            await _unitOfWork.ProfileInfos.UpdateV2(profileInfoId, request);
            return Ok(ApiResult<bool>.Success("Cập nhật thông tin chung trong hồ sơ thành công", true));
        }


    }
}
