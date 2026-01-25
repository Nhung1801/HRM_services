using HRM_BE.Core.ISeedWorks;
using HRM_BE.Core.Models.Common;
using HRM_BE.Core.Models.Official_Form.LeaveApplication;
using HRM_BE.Core.Models.ShiftCatalog;
using HRM_BE.Core.Models.ShiftWork;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace HRM_BE.Api.Controllers.ShiftWork
{
    [Route("api/shift-work")]
    [ApiController]
    public class ShiftWorkController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;
        public ShiftWorkController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        [HttpGet("get-by-id")]
        public async Task<ApiResult<ShiftWorkDto>> GetById([FromQuery] EntityIdentityRequest<int> request)
        {
            var result = await _unitOfWork.ShiftWorks.GetById(request.Id);
            return ApiResult<ShiftWorkDto>.Success("Lấy thông tin phân ca thành công", result);
        }
        [HttpGet("paging")]
        public async Task<ApiResult<PagingResult<ShiftWorkDto>>> Paging([FromQuery] GetShiftWorkPagingRequest request)
        {
            var result = await _unitOfWork.ShiftWorks.Paging(request.Name, request.OrganizationId,
                request.SortBy, request.OrderBy, request.PageIndex, request.PageSize);
            return ApiResult<PagingResult<ShiftWorkDto>>.Success("Lấy danh sách thông tin phân ca thành công", result);
        }
        [HttpPost("create")]
        public async Task<ApiResult<ShiftWorkDto>> Create([FromBody] CreateShiftWorkRequest request)
        {
            var result = await _unitOfWork.ShiftWorks.Create(request);
            return ApiResult<ShiftWorkDto>.Success("Thêm phân ca thành công", result);
        }
        [HttpPut("update")]
        public async Task<IActionResult> update(int shiftWorkId, [FromBody] UpdateShiftWorkRequest request)
        {
            await _unitOfWork.ShiftWorks.Update(shiftWorkId, request);
            return Ok(ApiResult<bool>.Success("Cập nhật phân ca thành công", true));
        }

        [HttpGet("get-by-employee")]
        public async Task<ApiResult<List<ShiftWorkDto>>> GetByEmployee([FromQuery] GetTotalNumberOfDaysOffRequest request)
        {
            var result = await _unitOfWork.ShiftWorks.GetByEmployee((DateTime)request.StartDate,(DateTime)request.EndDate,request.EmployeeId);
            return ApiResult<List<ShiftWorkDto>>.Success("Lấy danh sách thông tin phân ca thành công", result);
        }

        [HttpPut("delete")]
        public async Task<IActionResult> Delete([FromQuery] EntityIdentityRequest<int> request)
        {
            await _unitOfWork.ShiftWorks.Delete(request.Id);
            return Ok(ApiResult<bool>.Success("Xoá phân ca thành công", true));
        }

        [HttpGet("get-schedule")]
        public async Task<ApiResult<List<ShiftScheduleDto>>> GetShiftsForPeriod([FromQuery] GetTotalNumberOfDaysOffRequest request)
        {
            var result = await _unitOfWork.ShiftWorks.GetShiftsForPeriod((DateTime)request.StartDate, (DateTime)request.EndDate, request.EmployeeId);
            return ApiResult<List<ShiftScheduleDto>>.Success("Lấy lịch đi làm theo khoảng thời gian thành công", result);
        }




    }
}
