using HRM_BE.Core.ISeedWorks;
using HRM_BE.Core.Models.Common;
using HRM_BE.Core.Models.Contract.Allowance;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace HRM_BE.Api.Controllers.Allowances
{
    [Route("api/allowance")]
    [ApiController]
    public class AllowanceController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;
        public AllowanceController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        [HttpPost("create")]
        public async Task<ApiResult<AllowanceDto>> Create(CreateAllowanceDto request)
        {
            var result = await _unitOfWork.Allowances.Create(request);
            return ApiResult<AllowanceDto>.Success("Thêm phụ cấp thành công", result);
        }

        [HttpGet("paging")]
        public async Task<PagingResult<AllowanceDto>> Paging([FromQuery] GetPagingAllowanceRequest request)
        {
            var result = await _unitOfWork.Allowances.Paging(request.keyWord, request.SortBy, request.OrderBy, request.PageIndex, request.PageSize);
            return result;
        }
        [HttpGet("get-by-id")]
        public async Task<AllowanceDto> GetById([FromQuery] EntityIdentityRequest<int> request)
        {
            var result = await _unitOfWork.Allowances.GetById(request.Id);
            return result;
        } 
        [HttpGet("get-allowance-by-contractId")]
        public async Task<List<AllowanceDto>> GetAllowanceByContracId([FromQuery] EntityIdentityRequest<int> request)
        {
            var result = await _unitOfWork.Allowances.GetByContractId(request.Id);
            return result;
        }
        [HttpPut("update")]
        public async Task<IActionResult> Update(int id, UpdateAllowanceDto request)
        {
            await _unitOfWork.Allowances.Update(id, request);
            return Ok(ApiResult<bool>.Success("Cập nhật phụ cấp thành công", true));
        }
    }
}
