using HRM_BE.Core.ISeedWorks;
using HRM_BE.Core.Models.Common;
using HRM_BE.Core.Models.Profile.ContractDuration;
using HRM_BE.Core.Models.Staff;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace HRM_BE.Api.Controllers.ContractDuration
{
    [Route("api/contractduration")]
    [ApiController]
    public class ContractDurationController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;
        public ContractDurationController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        [HttpPost("create")]
        public async Task<ApiResult<ContractDurationDto>> Create(CreateContractDurationDto request)
        {
            var result = await _unitOfWork.ContractDurations.Create(request);
            return ApiResult<ContractDurationDto>.Success("Thêm thời hạn thành công", result);
        }

        [HttpGet("paging")]
        public async Task<PagingResult<ContractDurationDto>> Paging([FromQuery] ContractDurationRequest request)
        {
            var result = await _unitOfWork.ContractDurations.Paging(request.keyWord, request.SortBy, request.OrderBy, request.PageIndex, request.PageSize);
            return result;
        }
        [HttpGet("get-by-id")]
        public async Task<ContractDurationDto> GetById([FromQuery] EntityIdentityRequest<int> request)
        {
            var result = await _unitOfWork.ContractDurations.GetById(request.Id);
            return result;
        }
        [HttpPut("update")]
        public async Task<IActionResult> Update(int id, UpdateContractDurationDto request)
        {
            await _unitOfWork.ContractDurations.Update(id, request);
            return Ok(ApiResult<bool>.Success("Cập nhật thời hạn thành công", true));
        }
    }
}
