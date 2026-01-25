using HRM_BE.Core.ISeedWorks;
using HRM_BE.Core.Models.Common;
using HRM_BE.Core.Models.Delegation;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace HRM_BE.Api.Controllers.Task_Work
{
    [Route("api/delegation")]
    [ApiController]
    public class DelegationController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;
        public DelegationController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        [HttpGet]
        [Route("get-by-id")]
        public async Task<ApiResult<DelegationDto>> GetById([FromQuery] EntityIdentityRequest<int> request)
        {
            var result = await _unitOfWork.Delegations.GetByIdAsync(request.Id);
            return ApiResult<DelegationDto>.Success("Thành công", result);
        }

        //[HttpGet]
        //[Route("paging")]
        //public async Task<ApiResult<PagingResult<DelegationDto>>> Paging([FromQuery] GetDelegationRequest request)
        //{
        //    var result = await _unitOfWork.Delegations.GetPagingAsync(request.KeyWord, request.SortBy, request.OrderBy, request.PageIndex, request.PageSize);
        //    return ApiResult<PagingResult<DelegationDto>>.Success("Thành công", result);
        //}

        [HttpGet]
        [Route("get-all")]
        public async Task<ApiResult<List<DelegationDto>>> GetAll([FromQuery] GetAllDelegationRequest request)
        {
            var result = await _unitOfWork.Delegations.GetAllAsync();
            return ApiResult<List<DelegationDto>>.Success("Thành công", result);
        }

        [HttpGet]
        [Route("get-all-by-employee-delegation")]
        public async Task<ApiResult<List<DelegationDto>>> GetAllByEmployeeDelegation([FromQuery] GetAllDelegationByEmployeeDelegationRequest request)
        {
            var result = await _unitOfWork.Delegations.GetAllByEmployeeDelegationAsync(request.EmployeeDelegationId);
            return ApiResult<List<DelegationDto>>.Success("Thành công", result);
        }

        [HttpPost]
        [Route("create")]
        public async Task<ApiResult<DelegationDto>> Create([FromBody] CreateDelegationRequest request)
        {
            var result = await _unitOfWork.Delegations.CreateAsync(request);
            return ApiResult<DelegationDto>.Success("Thành công", result);
        }

        [HttpPut]
        [Route("update")]
        public async Task<ApiResult<DelegationDto>> Update([FromBody] UpdateDelegationRequest request)
        {
            var result = await _unitOfWork.Delegations.UpdateAsync(request);
            return ApiResult<DelegationDto>.Success("Thành công", result);
        }

        [HttpPut]
        [Route("delete-soft")]
        public async Task<ApiResult<DelegationDto>> Delete([FromBody] EntityIdentityRequest<int> request)
        {
            await _unitOfWork.Delegations.DeleteSoftAsync(request.Id);
            return ApiResult<DelegationDto>.Success("Thành công", null);
        }
    }
}
