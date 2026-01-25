using HRM_BE.Core.ISeedWorks;
using HRM_BE.Core.Models.Common;
using HRM_BE.Core.Models.Identity.User;
using HRM_BE.Core.Models.Tag;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace HRM_BE.Api.Controllers.Task_Work
{
    [Route("api/tag")]
    [ApiController]
    public class TagController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;
        public TagController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        [HttpGet("get-by-id")]
        public async Task<ApiResult<TagDto>> GetById( [FromQuery]int id)
        {
            var result = await _unitOfWork.Tags.GetById(id);
            return ApiResult<TagDto>.Success("Lấy thông tin tag thành côcng", result);
            
        }
        [HttpGet("paging")]
        public async Task<ApiResult<PagingResult<TagDto>>> Paging([FromQuery] GetTagPagingRequest request)
        {
            var result = await _unitOfWork.Tags.Paging(request.KeyWord,request.OrderBy,request.SortBy,request.PageIndex,request.PageSize);
            return ApiResult<PagingResult<TagDto>>.Success("Lấy danh sách thông tin tag thành côcng", result);
        }
        [HttpPost("create")]
        public async Task<ApiResult<TagDto>> create([FromBody] CreateTagRequest request )
        {
            var result = await _unitOfWork.Tags.Create(request);
            return ApiResult<TagDto>.Success("Tạo tag thành côcng", result);
        }
        [HttpPut("update")]
        public async Task<IActionResult> create([FromQuery] int id,[FromBody] UpdateTagRequest request)
        {
             await _unitOfWork.Tags.Update(id,request);
            return Ok(ApiResult<bool>.Success("cập nhật tag thành côcng")) ;
        }
        [HttpPut("delete")]
        public async Task<IActionResult> delete([FromBody] int id)
        {
            await _unitOfWork.Tags.Delete(id);
            return Ok(ApiResult<bool>.Success("xoá tag thành côcng"));
        }
    }
}
