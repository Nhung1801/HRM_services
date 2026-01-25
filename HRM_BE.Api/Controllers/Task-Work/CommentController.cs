using HRM_BE.Core.Data.Task;
using HRM_BE.Core.ISeedWorks;
using HRM_BE.Core.Models.Comment;
using HRM_BE.Core.Models.Common;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace HRM_BE.Api.Controllers.Task_Work
{
    [Route("api/comment")]
    [ApiController]
    public class CommentController : ControllerBase
    {

        private readonly IUnitOfWork _unitOfWork;
        public CommentController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        [HttpGet("get")]
        public async Task<ApiResult<PagingResult<CommentDto>>> Get([FromQuery] GetCommentRequest request)
        {
            var result = await _unitOfWork.Comments.Get(request);

            return new ApiResult<PagingResult<CommentDto>>()
            {
                Status = true,
                Message = "Lấy thông tin comment trò thành công!",
                Data = result
            };
        }


        [HttpPost("create")]
        public async Task<ApiResult<CommentDto>> Create([FromBody] CreateCommentRequest request)
        {
            var result = await _unitOfWork.Comments.Create(request);

            return new ApiResult<CommentDto>()
            {
                Status = true,
                Message = "Thêm comment thành công!",
                Data = result
            };
        }

        [HttpPost("delete-soft")]
        public async Task<ApiResult<CommentDto>> Delete([FromBody] EntityIdentityRequest<int> request)
        {
            var result = await _unitOfWork.Comments.Delete(request.Id);

            return new ApiResult<CommentDto>()
            {
                Status = true,
                Message = "Đã xóa comment!",
                Data = result
            };
        }
    }
}
