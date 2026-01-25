using HRM_BE.Core.Data.Payroll_Timekeeping.Shift;
using HRM_BE.Core.Data.Payroll_Timekeeping.TimekeepingRegulation;
using HRM_BE.Core.ISeedWorks;
using HRM_BE.Core.Models.Common;
using HRM_BE.Core.Models.ShiftWork;
using HRM_BE.Core.Models.SumaryTimeSheet;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace HRM_BE.Api.Controllers.SummaryTimeSheet
{
    [Route("api/summary-time-sheet")]
    [ApiController]
    public class SummaryTimeSheetController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;
        public SummaryTimeSheetController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        [HttpGet("get-by-id")]
        public async Task<ApiResult<SummaryTimeSheetDto>> GetById([FromQuery] EntityIdentityRequest<int> request)
        {
            var result = await _unitOfWork.SummaryTimeSheets.GetById(request.Id);
            return ApiResult<SummaryTimeSheetDto>.Success("Lấy thông tin bảng công tổng hợp thành công", result);
        }
        /// <summary>
        /// HRM-Lấy chấm công tổng hợp theo nhân viên
        /// </summary> 
        /// <param name="request"></param>
        /// <returns></returns>
        [HttpGet("get-summary-time-sheet-with-employee")]
        public async Task<ApiResult<PagingResult<GetSummaryTimeSheetWithEmployeeDto>>> GetSummaryTimeSheetWithEmployeePaging([FromQuery] GetSummarySheetWorkWithEmployeePagingRequest request)
        {
            var result = await _unitOfWork.SummaryTimeSheets.GetSummaryTimeSheetPaging(request.Id,request.OrganizationId,request.KeyWord,request.StaffPositionId,request.SortBy,request.OrderBy,request.PageIndex,request.PageSize);

            var shitCatalog = _unitOfWork.ShiftCatalogs.Find(g => g.OrganizationId == request.OrganizationId).FirstOrDefault();
            var shitWork = _unitOfWork.ShiftWorks.Find( s => s.ShiftCatalogId == shitCatalog.Id ).ToList();
            var totalWorkingDay = (double) shitWork.Select(s => s.TotalWork).Sum();
            foreach ( var item in result.Items)
            {
                var totalLeaveDay = await _unitOfWork.LeaveApplications.GetTotalLeaveEmployee(item.StartDate, item.EndDate, item.Id);
                var workingHours = _unitOfWork.Timesheet.Find(t => t.EmployeeId == item.Id);
                var totalWorkingHours = workingHours.Where( t => t.TimeKeepingLeaveStatus == TimeKeepingLeaveStatus.None).Sum(t => t.NumberOfWorkingHour) ?? 0;
                //var leaveHours = shitCatalog.WorkingHours * totalLeaveDay;
                //var totalLeaveHours = (totalWorkingHours - leaveHours) < 0 ? (totalWorkingHours - leaveHours)  : 0 ;
                var totalHoliday = await _unitOfWork.Holiday.GetNumberHoliday(item.StartDate, item.EndDate, request.OrganizationId);
                var totalHoureHoliday = totalHoliday * shitCatalog.WorkingHours.Value ; // số giờ nghỉ lễ
                item.TotalLeaveDay = totalLeaveDay + totalHoliday;
                item.TotalHour = totalWorkingHours  ;
                item.TotalWorkingDay = totalWorkingDay ;
                item.EqualDay = item.TotalHour > 0 ? ((totalWorkingHours + totalHoureHoliday) / shitCatalog.WorkingHours.Value) : 0; 
                //item.TotalExistLeaveDay = Math.Max((12 - item.TotalLeaveDay),0);

            }
            return ApiResult<PagingResult<GetSummaryTimeSheetWithEmployeeDto>>.Success("Lấy chi tiết chấm công tổng hợp thành công",result);
        }
        /// <summary>
        /// APi dùng để get chấm công tổng hợp cho màn bảng lương
        /// </summary>
        /// <returns></returns>
        [HttpGet("get-summary-select")]
        public async Task<ApiResult<List<GetSelectSummaryTimeSheetDto>>> GetSummaryTimeSheetSelect()
        {
            var result = await _unitOfWork.SummaryTimeSheets.GetSelectSummaryTimeSheet();

            return ApiResult<List<GetSelectSummaryTimeSheetDto>>.Success("Lấy chi tiết chấm công tổng hợp thành công", result);
        }
        /// <summary>
        /// HRM-Phân trang
        /// </summary> 
        /// <param name="request"></param>
        /// <returns></returns>
        [HttpGet("paging")]
        public async Task<ApiResult<PagingResult<SummaryTimeSheetDto>>> Paging([FromQuery] GetSummaryTimeSheetPagingRequest request)
        {
            var result = await _unitOfWork.SummaryTimeSheets.Paging(request.SummaryTimesheetId,request.Name,request.Month,request.Year, request.OrganizationId,request.SortBy, request.OrderBy, request.PageIndex, request.PageSize);
            return ApiResult<PagingResult<SummaryTimeSheetDto>>.Success("Lấy danh sách thông tin bảng công tổng hợp", result);
        }
        [HttpPost("create")]
        public async Task<ApiResult<SummaryTimeSheetDto>> Create([FromBody] CreateSummaryTimesheetRequest request)
        {
            var result = await _unitOfWork.SummaryTimeSheets.Create(request);
            return ApiResult<SummaryTimeSheetDto>.Success("Thêm bảng công tổng hợp thành công", result);
        }
        [HttpPut("update")]
        public async Task<IActionResult> update(int shiftWorkId, [FromBody] UpdateSummaryTimeSheetRequest request)
        {
            await _unitOfWork.SummaryTimeSheets.Update(shiftWorkId, request);
            return Ok(ApiResult<bool>.Success("Cập nhật bảng công tổng hợp thành công", true));
        }

        [HttpPut("delete")]
        public async Task<IActionResult> Delete([FromQuery] EntityIdentityRequest<int> request)
        {
            var result = _unitOfWork.SummaryTimeSheets.Delete(request.Id);
            return Ok(ApiResult<bool>.Success("Xoá bảng công tổng hợp thành công", true));
        }
    }
}
