using Google.Apis.Upload;
using HRM_BE.Core.ISeedWorks;
using HRM_BE.Core.Models.Common;
using HRM_BE.Core.Models.WorkNotification;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace HRM_BE.Api.Controllers.Notification
{
    [Route("api/notification-work")]
    [ApiController]
    public class NotificationWorkController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;
        public NotificationWorkController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        [HttpGet("paging")]
        public async Task<ApiResult<PagingResult<RemindWorkNotificationDto>>> Paging([FromQuery]GetWorkNotificationPagingRequest request)
        {
            var result = await _unitOfWork.RemindWorkNotifications.Paging(request.KeyWord, request.EmployeeId, request.WorkId, request.RemindWorkId, request.OrderBy, request.SortBy, request.PageIndex, request.PageSize);
            return ApiResult<PagingResult<RemindWorkNotificationDto>>.Success("Lấy thông báo thành công",result);
        }
    }
}
