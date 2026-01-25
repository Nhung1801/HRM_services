using HRM_BE.Core.ISeedWorks;
using HRM_BE.Core.Models.Common;
using HRM_BE.Core.Models.Payroll_Timekeeping.LeaveRegulation;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace HRM_BE.Api.Controllers.Payroll_Timekeeping.LeaveRegulation
{
    [Route("api/type-of-leave")]
    [ApiController]
    public class TypeOfLeaveController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;
        public TypeOfLeaveController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        /// <summary>
        /// Là Admin, tôi muốn Thêm quy định loại nghỉ
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        [HttpPost("create")]
        public async Task<ApiResult<TypeOfLeaveDto>> Create(CreateTypeOfLeaveRequest request)
        {
            var result = await _unitOfWork.TypeOfLeave.Create(request);
            return ApiResult<TypeOfLeaveDto>.Success("Thêm quy định loại nghỉ thành công", result);
        }

        /// <summary>
        /// HRM-là Admin, tôi muốn xem danh sách quy định loại nghỉ
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        [HttpGet("paging")]
        public async Task<PagingResult<TypeOfLeaveDto>> Paging([FromQuery] PagingTypeOfLeaveRequest request)
        {
            var result = await _unitOfWork.TypeOfLeave.Paging(request.OrganizationId, request.SortBy, request.OrderBy, request.PageIndex, request.PageSize);
            return result;
        }

        [HttpGet("get-by-id")]
        public async Task<TypeOfLeaveDto> GetById([FromQuery] EntityIdentityRequest<int> request)
        {
            var result = await _unitOfWork.TypeOfLeave.GetById(request.Id);
            return result;
        }

        /// <summary>
        /// HRM-là Admin, tôi muốn sửa loại ngày nghỉ
        /// </summary>
        /// <param name="id"></param>
        /// <param name="request"></param>
        /// <returns></returns>
        [HttpPut("update")]
        public async Task<IActionResult> Update(int id, UpdateTypeOfLeaveRequest request)
        {
            await _unitOfWork.TypeOfLeave.Update(id, request);
            return Ok(ApiResult<bool>.Success("Cập nhật loại ngày nghỉ thành công", true));
        }

        /// <summary>
        /// HRM-là Admin, tôi muốn xóa quy định loại nghỉ
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        [HttpDelete("delete")]
        public async Task<IActionResult> Delete([FromQuery] EntityIdentityRequest<int> request)
        {
            await _unitOfWork.TypeOfLeave.Delete(request.Id);
            return Ok(ApiResult<bool>.Success("Xoá quy định loại nghỉ thành công", true));
        }
    }
}
