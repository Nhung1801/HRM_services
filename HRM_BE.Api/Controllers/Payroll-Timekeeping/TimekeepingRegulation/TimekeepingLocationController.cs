using HRM_BE.Core.ISeedWorks;
using HRM_BE.Core.Models.Common;
using HRM_BE.Core.Models.Payroll_Timekeeping.LeaveRegulation;
using HRM_BE.Core.Models.Payroll_Timekeeping.TimekeepingRegulation;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace HRM_BE.Api.Controllers.Payroll_Timekeeping.TimekeepingRegulation
{
    [Route("api/timekeeping-location")]
    [ApiController]
    public class TimekeepingLocationController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;
        public TimekeepingLocationController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        /// <summary>
        /// Là admin, tôi muốn Thêm địa điểm chấm công
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        [HttpPost("create")]
        public async Task<ApiResult<TimekeepingLocationDto>> Create(CreateTimekeepingLocationRequest request)
        {
            var result = await _unitOfWork.TimekeepingLocation.Create(request);
            return ApiResult<TimekeepingLocationDto>.Success("Thêm địa điểm chấm công thành công", result);
        }

        /// <summary>
        /// Là admin, tôi muốn Xem danh sách địa điểm chấm công
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        [HttpGet("paging")]
        public async Task<PagingResult<TimekeepingLocationDto>> Paging([FromQuery] PagingTimekeepingLocationRequest request)
        {
            var result = await _unitOfWork.TimekeepingLocation.Paging(request.OrganizationId, request.SortBy, request.OrderBy, request.PageIndex, request.PageSize);
            return result;
        }

        [HttpGet("get-by-id")]
        public async Task<TimekeepingLocationDto> GetById([FromQuery] EntityIdentityRequest<int> request)
        {
            var result = await _unitOfWork.TimekeepingLocation.GetById(request.Id);
            return result;
        }

        /// <summary>
        /// Là admin, tôi muốn chỉnh sửa địa điểm chấm công
        /// </summary>
        /// <param name="id"></param>
        /// <param name="request"></param>
        /// <returns></returns>
        [HttpPut("update")]
        public async Task<IActionResult> Update(int id, UpdateTimekeepingLocationRequest request)
        {
            await _unitOfWork.TimekeepingLocation.Update(id, request);
            return Ok(ApiResult<bool>.Success("Cập nhật địa điểm chấm công thành công", true));
        }

        /// <summary>
        /// HRM-là Admin, tôi muốn xóa địa điểm chấm công
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        [HttpDelete("delete")]
        public async Task<IActionResult> Delete([FromQuery] EntityIdentityRequest<int> request)
        {
            await _unitOfWork.TimekeepingLocation.Delete(request.Id);
            return Ok(ApiResult<bool>.Success("Xoá địa điểm chấm công thành công", true));
        }
    }
}
