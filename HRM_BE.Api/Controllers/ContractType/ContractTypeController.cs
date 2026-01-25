using HRM_BE.Core.ISeedWorks;
using HRM_BE.Core.Models.Common;
using HRM_BE.Core.Models.Profile.ContractType;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace HRM_BE.Api.Controllers.ContractType
{
    [Route("api/contracttype")]
    [ApiController]
    public class ContractTypeController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;
        public ContractTypeController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        [HttpPost("create")]
        public async Task<ApiResult<ContractTypeDto>> Create(CreateContractTypeDto request)
        {
            var result = await _unitOfWork.ContractTypes.Create(request);
            return ApiResult<ContractTypeDto>.Success("Thêm loại hợp đồng thành công", result);
        }

        [HttpGet("paging")]
        public async Task<PagingResult<ContractTypeDto>> Paging([FromQuery] GetPagingContractTypeRequest request)
        {
            var result = await _unitOfWork.ContractTypes.Paging(request.keyWord, request.SortBy, request.OrderBy, request.PageIndex, request.PageSize);
            return result;
        }
        [HttpGet("get-by-id")]
        public async Task<ContractTypeDto> GetById([FromQuery] EntityIdentityRequest<int> request)
        {
            var result = await _unitOfWork.ContractTypes.GetById(request.Id);
            return result;
        }
        [HttpPut("update")]
        public async Task<IActionResult> Update(int id, UpdateContractTypeDto request)
        {
            await _unitOfWork.ContractTypes.Update(id, request);
            return Ok(ApiResult<bool>.Success("Cập nhật loại hợp đồng thành công", true));
        }
    }
}
