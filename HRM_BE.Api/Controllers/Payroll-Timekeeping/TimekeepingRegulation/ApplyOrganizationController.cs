using HRM_BE.Core.ISeedWorks;
using HRM_BE.Core.Models.Common;
using HRM_BE.Core.Models.Payroll_Timekeeping.LeaveRegulation;
using HRM_BE.Core.Models.Payroll_Timekeeping.TimekeepingRegulation;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace HRM_BE.Api.Controllers.Payroll_Timekeeping.TimekeepingRegulation
{
    [Route("api/apply-organization")]
    [ApiController]
    public class ApplyOrganizationController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;
        public ApplyOrganizationController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        /// <summary>
        /// Là admin, tôi muốn Thêm đơn vị chấm công
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        [HttpPost("create")]
        public async Task<ApiResult<ApplyOrganizationDto>> Create(CreateApplyOrganizationRequest request)
        {
            var result = await _unitOfWork.ApplyOrganization.Create(request);
            return ApiResult<ApplyOrganizationDto>.Success("Thêm đơn vị chấm công thành công", result);
        }

        [HttpGet("paging")]
        public async Task<PagingResult<ApplyOrganizationDto>> Paging([FromQuery] PagingApplyOrganizationRequest request)
        {
            var result = await _unitOfWork.ApplyOrganization.Paging(request.TimekeepingSettingId, request.OrganizationId, request.TimekeepingLocationId, request.SortBy, request.OrderBy, request.PageIndex, request.PageSize);
            return result;
        }

        [HttpGet("get-by-id")]
        public async Task<ApplyOrganizationDto> GetById([FromQuery] EntityIdentityRequest<int> request)
        {
            var result = await _unitOfWork.ApplyOrganization.GetById(request.Id);
            return result;
        }

        /// <summary>
        /// Là Admin, tôi muốn Chỉnh sửa đơn vị áp dụng chấm công
        /// </summary>
        /// <param name="id"></param>
        /// <param name="request"></param>
        /// <returns></returns>
        [HttpPut("update")]
        public async Task<IActionResult> Update(int id, UpdateApplyOrganizationRequest request)
        {
            await _unitOfWork.ApplyOrganization.Update(id, request);
            return Ok(ApiResult<bool>.Success("Chỉnh sửa đơn vị áp dụng chấm công thành công", true));
        }

        /// <summary>
        /// Lấy danh sách địa điểm chấm công theo từng tổ chức organizationId
        /// </summary>
        /// <param name="organizationId"></param>
        /// <returns></returns>
        [HttpGet("locations")]
        public async Task<IActionResult> GetTimekeepingLocations(int organizationId)
        {
            var locations = await _unitOfWork.ApplyOrganization.GetTimekeepingLocations(organizationId);
            return Ok(locations);
        }

        /// <summary>
        /// Là Admin, tôi muốn Xem tổng quát chấm công
        /// </summary>
        /// <param name="organizationId"></param>
        /// <returns></returns>
        [HttpGet("apply-organizations")]
        public async Task<IActionResult> GetApplyOrganizations([FromQuery] int? organizationId)
        {
            var result = await _unitOfWork.ApplyOrganization.GetApplyOrganizations(organizationId);
            return Ok(result);
        }

        /// <summary>
        /// Xóa đơn vị áp dụng
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpDelete("delete-apply-organization")]
        public async Task<IActionResult> DeleteApplyOrganization(int id)
        {
            await _unitOfWork.ApplyOrganization.DeleteApplyOrganization(id);
            return Ok(ApiResult<bool>.Success("Xoá đơn vị áp dụng thành công", true));
        }

    }
}
