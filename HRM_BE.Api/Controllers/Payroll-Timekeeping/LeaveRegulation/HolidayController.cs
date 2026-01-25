using HRM_BE.Core.ISeedWorks;
using HRM_BE.Core.Models.Common;
using HRM_BE.Core.Models.Contract.Allowance;
using HRM_BE.Core.Models.Payroll_Timekeeping.LeaveRegulation;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace HRM_BE.Api.Controllers.Payroll_Timekeeping.LeaveRegulation
{
    [Route("api/[controller]")]
    [ApiController]
    public class HolidayController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;
        public HolidayController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        /// <summary>
        /// HRM-là Admin, tôi muốn thêm ngày nghỉ lễ
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        [HttpPost("create")]
        public async Task<ApiResult<HolidayDto>> Create(CreateHolidayRequest request)
        {
            var result = await _unitOfWork.Holiday.Create(request);
            return ApiResult<HolidayDto>.Success("Thêm ngày nghỉ lễ thành công", result);
        }

        /// <summary>
        /// HRM-là Admin, tôi muốn xem ngày nghỉ lễ
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        [HttpGet("paging")]
        public async Task<PagingResult<HolidayDto>> Paging([FromQuery] PagingHolidayRequest request)
        {
            var result = await _unitOfWork.Holiday.Paging(request.OrganizationId, request.Name, request.SortBy, request.OrderBy, request.PageIndex, request.PageSize);
            return result;
        }

        [HttpGet("get-by-id")]
        public async Task<HolidayDto> GetById([FromQuery] EntityIdentityRequest<int> request)
        {
            var result = await _unitOfWork.Holiday.GetById(request.Id);
            return result;
        }

        [HttpGet("get-day-holiday-by-employee")]
        public async Task<ApiResult<List<DateTime>>> GetDayHoliday([FromQuery] GetDayHolidayRequest request)
        {
            var result = await _unitOfWork.Holiday.GetDayHoliday(request.StartDate,request.EndDate,request.EmployeeId);
            return ApiResult<List<DateTime>>.Success("Thành công",result) ;
        }

        /// <summary>
        /// HRM-là Admin, tôi muốn sửa ngày nghỉ lễ
        /// </summary>
        /// <param name="id"></param>
        /// <param name="request"></param>
        /// <returns></returns>
        [HttpPut("update")]
        public async Task<IActionResult> Update(int id, UpdateHolidayRequest request)
        {
            await _unitOfWork.Holiday.Update(id, request);
            return Ok(ApiResult<bool>.Success("Cập nhật ngày nghĩ lễ thành công", true));
        }

        /// <summary>
        /// HRM-là Admin, tôi muốn xóa ngày nghỉ lễ
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        [HttpDelete("delete")]
        public async Task<IActionResult> Delete([FromQuery] EntityIdentityRequest<int> request)
        {
            await _unitOfWork.Holiday.Delete(request.Id);
            return Ok(ApiResult<bool>.Success("Xoá ngày nghỉ lễ thành công", true));
        }
    }
}
