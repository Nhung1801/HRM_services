using HRM_BE.Core.Constants;
using HRM_BE.Core.ISeedWorks;
using HRM_BE.Core.Models.Common;
using HRM_BE.Core.Models.Company;
using HRM_BE.Core.Models.Staff;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace HRM_BE.Api.Controllers.Company
{
    [Route("api/group-position")]
    [ApiController]
    public class GroupPositionController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;
        public GroupPositionController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        [HttpGet("get-by-id")]

        public async Task<IActionResult> GetById([FromQuery] EntityIdentityRequest<int> request)
        {
            var result = await _unitOfWork.GroupPositions.GetById(request.Id);
            return Ok(ApiResult<GroupPositionDto>.Success("Lấy thông tin nhóm vị trí thành công", result));
        }
        [HttpGet("get-all")]
        public async Task<IActionResult> GetAll()
        {
            var result = await _unitOfWork.GroupPositions.GetAll();
            return Ok(ApiResult<List<GroupPositionDto>>.Success("Lấy danh sách thông tin nhóm vị trí thành công", result));
        }
        [HttpPost("create")]
        public async Task<ApiResult<GroupPositionDto>> Create([FromBody] CreateGroupPositionRequest request)
        {
            var createdEntity = await _unitOfWork.GroupPositions.Create(request);
            return ApiResult<GroupPositionDto>.Success("Thêm nhóm vị trí thành công", createdEntity);
        }
        [HttpPut("update")]
        public async Task<IActionResult> update(int id, [FromBody] UpdateGrouptPositonRequest request)
        {
            await _unitOfWork.GroupPositions.Update(id, request);
            return Ok(ApiResult<bool>.Success("Cập nhật nhóm vị trí", true));
        }

        [HttpPut("delete")]
        public async Task<IActionResult> Delete([FromQuery] EntityIdentityRequest<int> request)
        {
            await _unitOfWork.GroupPositions.Delete(request.Id);
            return Ok(ApiResult<bool>.Success("Xoá nhóm vị trí", true));
        }
    }
}
