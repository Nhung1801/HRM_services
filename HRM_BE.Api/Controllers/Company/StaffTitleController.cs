using HRM_BE.Core.ISeedWorks;
using HRM_BE.Core.Models.Common;
using HRM_BE.Core.Models.Staff;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace HRM_BE.Api.Controllers.Company
{
    [Route("api/staff-title")]
    [ApiController]
    public class StaffTitleController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;
        public StaffTitleController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        [HttpGet("get-by-id")]

        public async Task<IActionResult> GetById([FromQuery] EntityIdentityRequest<int> request)
        {
            var result = await _unitOfWork.StaffTitles.GetById(request.Id);
            return Ok(ApiResult<StaffTitleDto>.Success("Lấy thông tin chức danh thành công", result));
        }
        [HttpGet("get-all")]
        public async Task<IActionResult> GetAll()
        {
            var result = await _unitOfWork.StaffTitles.GetAll();
            return Ok(ApiResult<List<StaffTitleDto>>.Success("Lấy danh sách thông tin chức danh thành công", result));
        }
        [HttpPost("create")]
        public async Task<ApiResult<StaffTitleDto>> Create([FromBody] CreateStaffTitleRequest request)
        {
            var createdEntity = await _unitOfWork.StaffTitles.Create(request);
            return ApiResult<StaffTitleDto>.Success("Thêm chức danh thành công", createdEntity);
        }
        [HttpPut("update")]
        public async Task<IActionResult> update(int id, [FromBody] UpdateStaffTitleRequest request)
        {
            await _unitOfWork.StaffTitles.Update(id, request);
            return Ok(ApiResult<bool>.Success("Cập nhật chức danh thành công", true));
        }

        [HttpPut("delete")]
        public async Task<IActionResult> Delete([FromQuery] EntityIdentityRequest<int> request)
        {
            await _unitOfWork.StaffTitles.Delete(request.Id);
            return Ok(ApiResult<bool>.Success("Xoá chức danh thành công", true));
        }
    }
}
