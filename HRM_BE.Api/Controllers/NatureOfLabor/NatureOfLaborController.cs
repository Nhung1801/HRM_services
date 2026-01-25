using HRM_BE.Core.ISeedWorks;
using HRM_BE.Core.Models.Common;
using HRM_BE.Core.Models.Contract.NatureOfLabor;
using HRM_BE.Core.Models.Profile.ContractType;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace HRM_BE.Api.Controllers.NatureOfLabor
{
    [Route("api/[controller]")]
    [ApiController]
    public class NatureOfLaborController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;
        public NatureOfLaborController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        /// <summary>
        /// Thêm tính chất lao động
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        [HttpPost("create")]
        public async Task<ApiResult<NatureOfLaborDto>> Create(CreateNatureOfLaborDto request)
        {
            var result = await _unitOfWork.NatureOfLabors.Create(request);
            return ApiResult<NatureOfLaborDto>.Success("Thêm tính chất lao động thành công", result);
        }

        [HttpGet("paging")]
        public async Task<PagingResult<NatureOfLaborDto>> Paging([FromQuery] GetPagingNatureOfLaborRequest request)
        {
            var result = await _unitOfWork.NatureOfLabors.Paging(request.keyWord, request.SortBy, request.OrderBy, request.PageIndex, request.PageSize);
            return result;
        }
        [HttpGet("get-by-id")]
        public async Task<NatureOfLaborDto> GetById([FromQuery] EntityIdentityRequest<int> request)
        {
            var result = await _unitOfWork.NatureOfLabors.GetById(request.Id);
            return result;
        }

        /// <summary>
        /// Cập nhật tính chất lao động
        /// </summary>
        /// <param name="id"></param>
        /// <param name="request"></param>
        /// <returns></returns>
        [HttpPut("update")]
        public async Task<IActionResult> Update(int id, UpdateNatureOfLaborDto request)
        {
            await _unitOfWork.NatureOfLabors.Update(id, request);
            return Ok(ApiResult<bool>.Success("Cập nhật tính chất lao động thành công", true));
        }
    }
}
