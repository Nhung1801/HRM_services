using HRM_BE.Core.Helpers;
using HRM_BE.Core.ISeedWorks;
using HRM_BE.Core.Models.Common;
using HRM_BE.Core.Models.ProfileInfoModel;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace HRM_BE.Api.Controllers.Employee
{
    [Route("api/job-info")]
    [ApiController]
    public class JobInfoController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;
        public JobInfoController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        [HttpGet("get-by-id")]
        public async Task<ApiResult<JobInfoDto>> GetById([FromQuery] EntityIdentityRequest<int> request)
        {
            var jobInfo = await _unitOfWork.JobInfos.GetById(request.Id);
            return ApiResult<JobInfoDto>.Success("Lấy thông tin hồ sơ công việc thành công", jobInfo);
        }
        [HttpPost("create")]
        public async Task<ApiResult<JobInfoDto>> Create([FromBody] CreateJobInfoRequest request)
        {
            var result = await _unitOfWork.JobInfos.Create(request);
            return ApiResult<JobInfoDto>.Success("Thêm thông tin hồ sơ thành công", result);
        }

        [HttpPut("update")]
        public async Task<IActionResult> Update(int id, [FromBody] UpdateJobInfoRequest request)
        {
            await _unitOfWork.JobInfos.Update(id, request);
            return Ok(ApiResult<bool>.Success("Cập nhật thông tin công việc thành công",true));
        }
    }
}
