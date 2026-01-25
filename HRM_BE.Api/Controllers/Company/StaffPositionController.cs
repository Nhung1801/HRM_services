using HRM_BE.Core.ISeedWorks;
using HRM_BE.Core.Models.Common;
using HRM_BE.Core.Models.Staff;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace HRM_BE.Api.Controllers.Company
{
    [Route("api/staff-position")]
    [ApiController]
    public class StaffPositionController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;
        public StaffPositionController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        [HttpGet("get-by-id")]

        public async Task<IActionResult> GetById([FromQuery] EntityIdentityRequest<int> request)
        {
            var result = await _unitOfWork.StaffPositions.GetById(request.Id);
            return Ok(ApiResult<StaffPositionDto>.Success("Lấy thông tin vị trí thành công", result));
        }
        [HttpGet("paging")]

        public async Task<IActionResult> Paing([FromQuery] GetPagingStaffPositionRequest request)
        {
            var result = await _unitOfWork.StaffPositions.Paging(request.KeyWord,request.Status,request.SortBy,request.OrderBy,request.PageIndex,request.PageSize);
            return Ok(ApiResult<PagingResult<StaffPositionDto>>.Success("Lấy thông tin vị trí thành công", result));
        }

        [HttpPost("create")]
        public async Task<ApiResult<StaffPositionDto>> Create([FromBody] CreateStaffPositionRequest request)
        {
            var createdEntity = await _unitOfWork.StaffPositions.Create(request);
            return ApiResult<StaffPositionDto>.Success("Thêm vị trí thành công", createdEntity);
        }
        [HttpPut("update")]
        public async Task<IActionResult> update(int id, [FromBody] UpdateStaffPositionRequest request)
        {
            await _unitOfWork.StaffPositions.Update(id, request);
            return Ok(ApiResult<bool>.Success("Cập nhật  vị trí", true));
        }
        [HttpPut("update-status")]
        public async Task<IActionResult> UpdateStatus(int id, [FromBody] UpdateStaffPositionStatusRequest request)
        {
            await _unitOfWork.StaffPositions.UpdateStatus(id, request);
            return Ok(ApiResult<bool>.Success("Cập nhật trạng thái  vị trí thành công", true));
        }
        [HttpPut("delete")]
        public async Task<IActionResult> Delete([FromQuery] EntityIdentityRequest<int> request)
        {
            await _unitOfWork.StaffPositions.Delete(request.Id);
            return Ok(ApiResult<bool>.Success("Xoá nhóm vị trí", true));
        }
        [HttpPut("delete-range")]
        public async Task<IActionResult> DeleteRange([FromBody] ListEntityIdentityRequest<int> request)
        {
            await _unitOfWork.StaffPositions.DeleteRange(request);
            return Ok(ApiResult<bool>.Success("Xoá nhiều nhóm vị trí", true));
        }
    }
}
