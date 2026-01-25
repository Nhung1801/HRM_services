using HRM_BE.Core.ISeedWorks;
using HRM_BE.Core.Models.Common;
using HRM_BE.Core.Models.PrefixConfig;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;

namespace HRM_BE.Api.Controllers.PrefixConfig
{
    [Route("api/prefix-config")]
    [ApiController]
    public class PrefixConfigController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;
        public PrefixConfigController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        [HttpPost("create")]
        public async Task<IActionResult> Create(CreatePrefixConfigRequest request)
        {
           await _unitOfWork.PrefixConfigs.Create(request);

            return Ok("Thêm thành công");
        }
        [HttpGet("get-by-key")]
        public async Task<ApiResult<PrefixConfigDto>> GetByKey([FromQuery] string Key)
        {
            var entity = await _unitOfWork.PrefixConfigs.GetByKey(Key);
            return ApiResult<PrefixConfigDto>.Success("Lấy thông tin thành công", entity);
        }
        
    }
}
