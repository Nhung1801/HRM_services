using HRM_BE.Core.ISeedWorks;
using HRM_BE.Core.Models.Common;
using HRM_BE.Core.Models.Profile.WorkingForm;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace HRM_BE.Api.Controllers.WorkingForm
{
    [Route("api/workingform")]
    [ApiController]
    public class WorkingFormController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;
        public WorkingFormController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        [HttpPost("create")]
        public async Task<ApiResult<WorkingFormDto>> Create(CreateWorkingFormDto request)
        {
            var result = await _unitOfWork.WorkingForms.Create(request);
            return ApiResult<WorkingFormDto>.Success("Thêm hình thức làm việc thành công", result);
        }

        [HttpGet("paging")]
        public async Task<PagingResult<WorkingFormDto>> Paging([FromQuery] GetPagingWorkingFormRequest request)
        {
            var result = await _unitOfWork.WorkingForms.Paging(request.keyWord, request.SortBy, request.OrderBy, request.PageIndex, request.PageSize);
            return result;
        }
        [HttpGet("get-by-id")]
        public async Task<WorkingFormDto> GetById([FromQuery] EntityIdentityRequest<int> request)
        {
            var result = await _unitOfWork.WorkingForms.GetById(request.Id);
            return result;
        }
        [HttpPut("update")]
        public async Task<IActionResult> Update(int id, UpdateWorkingFormDto request)
        {
            await _unitOfWork.WorkingForms.Update(id, request);
            return Ok(ApiResult<bool>.Success("Cập nhật hình thức làm việc thành công", true));
        }
    }
}
