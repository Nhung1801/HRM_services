using AutoMapper;
using HRM_BE.Core.ISeedWorks;
using HRM_BE.Core.Models.Common;
using HRM_BE.Core.Models.Official_Form.LeaveApplication;
using HRM_BE.Data;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace HRM_BE.Api.Controllers.Official_Form
{
    [Route("api/leave-permission")]
    [ApiController]
    public class LeavePermissionController : ControllerBase
    {
        public readonly IUnitOfWork _unitOfWork;
        public readonly IMapper _mapper;

        public LeavePermissionController(IUnitOfWork unitOfWork, IMapper mapper, HrmContext context)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        [HttpGet("get-number-of-days-off-paid-leave")]
        public async Task<ApiResult<double>> GetLeavePermissionByEmployee([FromQuery] EntityIdentityRequest<int> request)
        {
            var result = await _unitOfWork.LeavePermissions.CountDayOff(request.Id);
            return new ApiResult<double>("Số ngày nghỉ phép có lương còn lại đã được lấy thành công!", result);
        }
    }
}
