using HRM_BE.Core.Exceptions;
using HRM_BE.Core.ISeedWorks;
using HRM_BE.Core.Models.Common;
using HRM_BE.Core.Models.DetailTimeSheet;
using HRM_BE.Core.Models.ShiftWork;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace HRM_BE.Api.Controllers.DetailTimesheet
{
    [Route("api/detail-timesheet")]
    [ApiController]
    public class DetailTimesheetController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;
        public DetailTimesheetController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        [HttpGet("get-by-id")]
        public async Task<ApiResult<DetailTimeSheetDto>> GetById([FromQuery] EntityIdentityRequest<int> request)
        {
            var result = await _unitOfWork.DetailTimeSheets.GetById(request.Id);
            return ApiResult<DetailTimeSheetDto>.Success("Lấy thông tin bảng chi tiết chấm công thành công", result);
        }
        [HttpGet("statistic-detail-time-sheet")]
        public async Task<ApiResult<StatiscTimeSheetDto>> StatisticDetailTimeSheet([FromQuery] EntityIdentityRequest<int> request)
        {
            var result = await _unitOfWork.DetailTimeSheets.StatiscTimeSheetDto(request.Id);
            return ApiResult<StatiscTimeSheetDto>.Success("Thống kê chi tiết chấm công thành công", result);
        }
        [HttpGet("paging")]
        public async Task<ApiResult<PagingResult<DetailTimeSheetDto>>> Paging([FromQuery] GetDetailTimeSheetPagingRequest request)
        {
            var result = await _unitOfWork.DetailTimeSheets.Paging(request.Name, request.Month,request.Year, request.OrganizationId,request.StaffPositionId,request.SortBy, request.OrderBy, request.PageIndex, request.PageSize);
            return ApiResult<PagingResult<DetailTimeSheetDto>>.Success("Lấy danh sách thông tin chi tiết chấm công", result);
        } 
        [HttpGet("get-select")]
        public async Task<ApiResult<PagingResult<DetailTimeSheetDto>>> GetSelect([FromQuery] GetDetailTimeSheetPagingRequest request)
        {
            var result = await _unitOfWork.DetailTimeSheets.GetSelect(request.Name, request.Month,request.Year, request.OrganizationId,request.StaffPositionId,request.SortBy, request.OrderBy, request.PageIndex, request.PageSize);
            return ApiResult<PagingResult<DetailTimeSheetDto>>.Success("Lấy danh sách chọn thông tin chi tiết chấm công", result);
        } 
        [HttpGet("get-detail-time-sheet-with-time-sheet")]
        public async Task<ApiResult<PagingResult<GetDetailTimesheetWithEmployeeDto>>> DetailTimeSheetWithEmployee([FromQuery] GetDetailTimeSheetWithEmplopyeePagingRequest request)
        {
            var result = await _unitOfWork.DetailTimeSheets.DetailTimeSheetWithEmployeePaging(request.DetailTimeSheetId,request.KeyWord, request.OrganizationId,request.SortBy, request.OrderBy, request.PageIndex, request.PageSize);


            return ApiResult<PagingResult<GetDetailTimesheetWithEmployeeDto>>.Success("Lấy danh sách thông tin chi tiết chấm công", result);
        }

        [HttpGet("get-detail-time-sheet")]
        public async Task<ApiResult<List<GetDetailTimesheetWithEmployeeDto>>> DetailTimeSheetWithEmployeeNoPaging(
            [FromQuery] int detailTimeSheetId,
            [FromQuery] string? keyWord,
            [FromQuery] int? organizationId,
            [FromQuery] string? sortBy,
            [FromQuery] string? orderBy)
        {
            var result = await _unitOfWork.DetailTimeSheets.DetailTimeSheetWithEmployee(
                detailTimeSheetId,
                keyWord,
                organizationId,
                sortBy,
                orderBy);

            return ApiResult<List<GetDetailTimesheetWithEmployeeDto>>.Success("Lấy thông tin chi tiết chấm công ", result);
        }
        
        [HttpPost("create")]
        public async Task<ApiResult<DetailTimeSheetDto>> Create([FromBody] CreateDetailTimeSheetRequest request)
        {
            var result = await _unitOfWork.DetailTimeSheets.Create(request);
            return ApiResult<DetailTimeSheetDto>.Success("Thêm bảng chi tiết chấm công thành công", result);
        }
        [HttpPut("update")]
        public async Task<IActionResult> update(int shiftWorkId, [FromBody] UpdateDetailTimeSheetRequest request)
        {
            await _unitOfWork.DetailTimeSheets.Update(shiftWorkId, request);
            return Ok(ApiResult<bool>.Success("Cập nhật chi tiết chấm công thành công", true));
        }
        [HttpPut("Lock")]
        public async Task<IActionResult> Lock(int shiftWorkId, [FromBody] UpdateLockDetailTimeSheetRequest request )
        {
            await _unitOfWork.DetailTimeSheets.LockDetailTimeSheet(shiftWorkId,request.IsLock);
            return Ok(ApiResult<bool>.Success("Khóa chi tiết chấm công thành công", true));
        }
        [HttpPut("delete")]
        public async Task<IActionResult> Delete([FromQuery] EntityIdentityRequest<int> request)
        {
            try
            {
                await _unitOfWork.DetailTimeSheets.Delete(request.Id);
                return Ok(ApiResult<bool>.Success("Xoá chi tiết chấm công thành công", true));
            }
            catch (InvalidOperationException ex)
            {
                return BadRequest(ApiResult<bool>.Failure(ex.Message, false));
            }
            catch (EntityNotFoundException ex)
            {
                return NotFound(ApiResult<bool>.Failure(ex.Message, false));
            }
        }
    }
}
