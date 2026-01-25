using HRM_BE.Core.ISeedWorks;
using HRM_BE.Core.Models.Common;
using HRM_BE.Core.Models.Payroll_Timekeeping.TimekeepingRegulation;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace HRM_BE.Api.Controllers.Payroll_Timekeeping.TimekeepingRegulation
{
    [Route("api/timekeeping-setting")]
    [ApiController]
    public class TimekeepingSettingController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;
        public TimekeepingSettingController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        [HttpPost("create")]
        public async Task<ApiResult<TimekeepingSettingDto>> Create(CreateTimekeepingSettingRequest request)
        {
            var result = await _unitOfWork.TimekeepingSetting.Create(request);
            return ApiResult<TimekeepingSettingDto>.Success("Thêm cài đặt chấm công thành công", result);
        }

        [HttpGet("paging")]
        public async Task<PagingResult<TimekeepingSettingDto>> Paging([FromQuery] PagingTimekeepingSettingRequest request)
        {
            var result = await _unitOfWork.TimekeepingSetting.Paging(request.OrganizationId, request.SortBy, request.OrderBy, request.PageIndex, request.PageSize);
            return result;
        }

        [HttpGet("get-by-id")]
        public async Task<TimekeepingSettingDto> GetById([FromQuery] EntityIdentityRequest<int> request)
        {
            var result = await _unitOfWork.TimekeepingSetting.GetById(request.Id);
            return result;
        }
    }
}
