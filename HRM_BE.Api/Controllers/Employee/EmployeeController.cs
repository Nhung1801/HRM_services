using HRM_BE.Api.Services.Interfaces;
using HRM_BE.Core.Constants;
using HRM_BE.Core.Data.Staff;
using HRM_BE.Core.ISeedWorks;
using HRM_BE.Core.Models.Common;
using HRM_BE.Core.Models.Staff;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Metadata;
using System.Security.AccessControl;

namespace HRM_BE.Api.Controllers.Employee
{
    [Route("api/employee")]
    [ApiController]
    public class EmployeeController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IFileService _fileService;
        public EmployeeController(IUnitOfWork unitOfWork, IFileService fileService)
        {
            _unitOfWork = unitOfWork;
            _fileService = fileService;
        }
        [HttpGet("paging")]
        public async Task<PagingResult<EmployeeDto>> Paging([FromQuery]GetEmployeePagingRequest request)
        {
            var result = await _unitOfWork.Employees.Paging(request.keyWord, request.OrganizationId,request.LeaderOrganizationId, request.StaffPositionId, request.WorkingStatus,request.AccountStatus,request.CityId,request.DistrictId,request.WardId,request.StreetId, request.SortBy, request.OrderBy, request.PageIndex, request.PageSize);
            return result;
        }
        [HttpGet("get-by-id")]
        public async Task<EmployeeDto> GetById([FromQuery] EntityIdentityRequest<int> request)
        {
            var result = await _unitOfWork.Employees.GetById(request.Id);
            return result;
        }  
        [HttpGet("get-profile-info-by-id")]
        public async Task<GetEmployeeProfileDto> GetEmployeeProfileById([FromQuery] EntityIdentityRequest<int> request)
        {
            var result = await _unitOfWork.Employees.GetProfileInfoByEmployeeId(request.Id);
            return result;
        }
        [HttpPost("create")]
        public async Task<ApiResult<EmployeeDto>> Create([FromForm] CreateEmployeeRequest request)
        {
            if (request.AvatarImage != null)
            {
                request.AvatarUrl = await _fileService.UploadFileAsync(request.AvatarImage,PathFolderConstant.Avatar);
            }
            else
            {
                request.AvatarUrl = ImageConstant.Avatar;
            }
            request.EmployeeCode = await _unitOfWork.PrefixConfigs.GetAndUpdatePrefix("employee");
            var result = await _unitOfWork.Employees.Create(request);
            return ApiResult<EmployeeDto>.Success("Thêm nhân viên thành công",result);
        }
        [HttpPut("update")]
        public async Task<IActionResult> Update(int id, [FromForm] UpdateEmployeeRequest request)
        {
            if (request.AvatarImage != null)
            {
                request.AvatarUrl = await _fileService.UploadFileAsync(request.AvatarImage,PathFolderConstant.Avatar);
            }
            await _unitOfWork.Employees.Update(id,request); 
            return Ok(ApiResult<bool>.Success("Cập nhật nhân viên thành công",true));
        }
        [HttpDelete("delete")]
        public async Task<IActionResult> Delete(int id)
        {
            await _unitOfWork.Employees.Delete(id);
            return Ok(ApiResult<bool>.Success("Xoá nhân viên thành công",true));
        }
        [HttpPut("update-account-status")]
        public async Task<IActionResult> UpdateAccountStatus(int id,UpdateAccountStatusRequest request)
        {
            await _unitOfWork.Employees.UpdateAccountStatus(id, request);
            return Ok(ApiResult<bool>.Success("Cập nhật trạng thái tài khoản nhân viên thành công",true));
        } 
        [HttpPut("update-range-account-status")]
        public async Task<IActionResult> UpdateRangeAccountStatus(UpdateRangeEmployeeStatusRequest request)
        {
            await _unitOfWork.Employees.UpdateRangeAccountStatus(request.ids,request.accountStatus);
            return Ok(ApiResult<bool>.Success("Cập nhật trạng thái tài khoản nhân viên thành công",true));
        }
        [HttpPatch("update")]
        public async Task<IActionResult> UpdatePatch(int id, [FromBody] JsonPatchDocument<UpdateEmployeeRequest> patchDoc )
        {
            if (patchDoc is null)
                return BadRequest("đối tượng patchDoc được gửi từ máy khách là rỗng");
            var result = await _unitOfWork.Employees.GetEmployeeForPatch(id);

            patchDoc.ApplyTo(result.employeePath);
            await _unitOfWork.Employees.SaveChangesForPatch(result.employeePath,
            result.employeeEntity);

            return Ok(ApiResult<bool>.Success("Cập nhật thông tin thành công",true));
        }
    }
}
