using HRM_BE.Core.ISeedWorks;
using HRM_BE.Core.Models.Common;
using HRM_BE.Core.Models.GroupWorkModel;
using HRM_BE.Data.SeedWorks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace HRM_BE.Api.Controllers.GroupWork
{
    [Route("api/group-work")]
    [ApiController]
    public class GroupWorkController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;
        public GroupWorkController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        [HttpGet("get-all")]
        public async Task<ApiResult<List<GroupWorkDto>>> GetAll()
        {
            var result = await _unitOfWork.GroupWorks.GetAll();
            return ApiResult<List<GroupWorkDto>>.Success("Lấy danh sách nhóm công việc thành công",result);
        }
        [HttpGet("get-by-id")]
        public async Task<ApiResult<GroupWorkDto>> GetById([FromQuery] int id)
        {
            var result = await _unitOfWork.GroupWorks.GetById(id);
            return ApiResult<GroupWorkDto>.Success("Lấy  nhóm công việc thành công",result);
        }
        [HttpGet("paging")]
        public async Task<ApiResult<PagingResult<GroupWorkDto>>> Paging([FromQuery] GetGroupWorkPagingRequest request)
        {
            var result = await _unitOfWork.GroupWorks.Paging(request.KeyWord,request.ProjectId,request.OrderBy,request.SortBy,request.PageIndex,request.PageSize);
            return ApiResult<PagingResult<GroupWorkDto>>.Success("Lấy danh sách nhóm công việc thành công",result);
        }
        [HttpPost("create")]
        public async Task<ApiResult<GroupWorkDto>> Create(CreateGroupWorkRequest request)
        {
            var result = await _unitOfWork.GroupWorks.Create(request);
            return ApiResult<GroupWorkDto>.Success("Tạo nhóm công việc thành công",result);
        }
        [HttpPut("update")]
        public async Task<ApiResult<bool>> Update(int id,UpdateGroupWorkRequest request)
        {
            await _unitOfWork.GroupWorks.Update(id, request);
            return ApiResult<bool>.Success("Cập nhật nhóm công việc thành công");
        }
        
        [HttpPut("delete")]
        public async Task<ApiResult<bool>> Delete(int id)
        {
            await _unitOfWork.GroupWorks.Delete(id);
            return ApiResult<bool>.Success("Xoá nhóm công việc thành công");
        }

    }
}
