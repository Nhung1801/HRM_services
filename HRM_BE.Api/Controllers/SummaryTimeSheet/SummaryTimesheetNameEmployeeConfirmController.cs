using HRM_BE.Core.ISeedWorks;
using HRM_BE.Core.Models.Common;
using HRM_BE.Core.Models.DetailTimeSheet;
using HRM_BE.Core.Models.SumaryTimeSheet;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace HRM_BE.Api.Controllers.SummaryTimeSheet
{
    [Route("api/summary-timesheet-name-employee-confirm")]
    [ApiController]
    public class SummaryTimesheetNameEmployeeConfirmController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;
        public SummaryTimesheetNameEmployeeConfirmController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }


        //[HttpGet("paging")]
        //public async Task<ApiResult<SummaryTimeSheetDto>> Create([FromBody] CreateSummaryTimesheetRequest request)
        //{
        //    var result = await _unitOfWork.SummaryTimeSheets.Create(request);
        //    return ApiResult<SummaryTimeSheetDto>.Success("Thêm bảng công tổng hợp thành công", result);
        //}

        [HttpGet("paging-by-employee")]
        public async Task<ApiResult<PagingResult<SummaryTimesheetNameEmployeeConfirmDto>>> PagingByEmployee([FromQuery] GetSummaryTimesheetNameEmployeeConfirmByEmployeeRequest request)
        {
            var result = await _unitOfWork.SummaryTimesheetNameEmployeeConfirms.PagingByEmployee(request.SummaryTimesheetNameId,request.StartDate,request.EndDate,request.Status,request.Note,request.Date,request.SortBy,request.OrderBy,request.EmployeeId,request.PageIndex,request.PageSize);
            return ApiResult<PagingResult<SummaryTimesheetNameEmployeeConfirmDto>>.Success("Lấy danh sách bảng công tổng hợp theo nhân viên thành công", result);
        }

        [HttpGet("get-status-by-employee")]
        public async Task<ApiResult<SummaryTimesheetNameSummaryTimesheetNameEmployeeConfirmDto>> GetStatusByEmployee([FromQuery] GetStatusByEmployeeRequest request)
        {
            var result = await _unitOfWork.SummaryTimesheetNameEmployeeConfirms.GetStatusByEmployee(request.SumaryTimeSheetId, request.EmployeeId);
            return ApiResult<SummaryTimesheetNameSummaryTimesheetNameEmployeeConfirmDto>.Success("Lấy trạng thái bảng chấm công nhân viên thành công", result);
        }

        [HttpGet("get-detail")]
        public async Task<ApiResult<List<SummaryTimesheetNameEmployeeConfirmTimeSheetDto>>> GetDetail([FromQuery] GetSummaryTimesheetNameEmployeeConfirmTimeSheetRequest request)
        {
            var result = await _unitOfWork.SummaryTimesheetNameEmployeeConfirms.GetDetail(request.StartDate, request.EndDate, request.EmployeeId);
            return ApiResult<List<SummaryTimesheetNameEmployeeConfirmTimeSheetDto>>.Success("Lấy chi tiết xác nhận bảng công tổng hợp thành công", result);
        }
        /// <summary>
        /// HRM- Vip pro hơn của /get-detail
        /// </summary> 
        /// <param name="request"></param>
        /// <returns></returns>
        [HttpGet("get-detail-by-shift-work")]
        public async Task<ApiResult<List<ConfirmTimeSheetDto>>> GetDetailByShiftWork([FromQuery] GetSummaryTimesheetNameEmployeeConfirmTimeSheetRequest request)
        {
            var result = await _unitOfWork.SummaryTimesheetNameEmployeeConfirms.GetDetailByShiftWork(request.StartDate, request.EndDate, request.EmployeeId);
            return ApiResult<List<ConfirmTimeSheetDto>>.Success("Lấy chi tiết xác nhận bảng công tổng hợp thành công", result);
        }

        /// <summary>
        /// HRM-Lấy ngày nghỉ có phép trong khoảng time
        /// </summary> 
        /// <param name="request"></param>
        /// <returns></returns>
        [HttpGet("get-permitted-leave")]
        public async Task<ApiResult<List<PermittedLeaveDto>>> GetPermittedLeaves([FromQuery] GetSummaryTimesheetNameEmployeeConfirmTimeSheetRequest request)
        {
            var result = await _unitOfWork.SummaryTimesheetNameEmployeeConfirms.GetPermittedLeaves(request.StartDate, request.EndDate, request.EmployeeId);
            return ApiResult<List<PermittedLeaveDto>>.Success("Lấy ngày nghỉ có phép thành công", result);
        }
        /// <summary>
        /// HRM-Thêm mới hoặc cập nhập
        /// </summary> 
        /// <param name="request"></param>
        /// <returns></returns>
        [HttpPost("create-or-update")]
        public async Task<ApiResult<SummaryTimesheetNameSummaryTimesheetNameEmployeeConfirmDto>> CreateOrUpdate([FromBody] CreateSummaryTimesheetNameEmployeeConfirmRequest request)
        {
            var result = await _unitOfWork.SummaryTimesheetNameEmployeeConfirms.CreateOrUpdate(request);
            return ApiResult<SummaryTimesheetNameSummaryTimesheetNameEmployeeConfirmDto>.Success("Thêm xác nhận bảng công tổng hợp thành công", result);
        }
        /// <summary>
        /// HRM-Thêm mới hoặc cập nhập nhiều 
        /// </summary> 
        /// <param name="request"></param>
        /// <returns></returns>
        [HttpPost("create-or-update-multiple")]
        public async Task<ApiResult<List<SummaryTimesheetNameSummaryTimesheetNameEmployeeConfirmDto>>> CreateOrUpdateMultiple([FromBody] CreateSummaryTimesheetNameEmployeeConfirmMultipleRequest request)
        {
            var result = await _unitOfWork.SummaryTimesheetNameEmployeeConfirms.CreateOrUpdateMultiple(request);
            return ApiResult<List<SummaryTimesheetNameSummaryTimesheetNameEmployeeConfirmDto>>.Success("Thêm xác nhận bảng công tổng hợp thành công", result);
        }



    }
}
