using HRM_BE.Core.Data.ProfileEntity;
using HRM_BE.Core.ISeedWorks;
using HRM_BE.Core.Models.Common;
using HRM_BE.Core.Models.ProfileInfoModel;
using HRM_BE.Core.Models.Staff;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace HRM_BE.Api.Controllers.Employee
{
    [Route("api/deduction")]
    [ApiController]
    public class DeductionController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;
        public DeductionController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        [HttpGet("get-by-id")]
        public async Task<IActionResult> GetById([FromQuery] EntityIdentityRequest<int> request)
        {
            var result = await _unitOfWork.Deductions.GetById(request.Id);
            return Ok(ApiResult<DeductionDto>.Success("Lấy thông tin khấu trừ", result));
        }
        
        [HttpGet("get-deduction-by-employeeId")]
        public async Task<IActionResult> GetDeductionByEmployeeId([FromQuery] EntityIdentityRequest<int> request)
        {
            var result = await _unitOfWork.Deductions.GetDeductionByEmployeeId(request.Id);
            return Ok(ApiResult<List<DeductionDto>>.Success("Lấy thông tin khấu trừ", result));
        }

        [HttpGet("get-all")]
        public async Task<IActionResult> GetAll()
        {
            var result = await _unitOfWork.Deductions.GetAll();
            return Ok(ApiResult<List<DeductionDto>>.Success("Lấy danh sách thông tin thành công", result));
        }

        [HttpPost("create")]
        public async Task<ApiResult<DeductionDto>> Create([FromBody] CreateDeductionRequest request)
        {
            var createdEntity = await _unitOfWork.Deductions.Create(request);
            return ApiResult<DeductionDto>.Success("Thêm khấu trừ thành công", createdEntity);
        }


        [HttpPut("update")]
        public async Task<IActionResult> update(int id, [FromBody] UpdateDeductionRequest request)
        {
            await _unitOfWork.Deductions.Update(id, request);
            return Ok(ApiResult<bool>.Success("Cập nhật khấu trừ thành công", true));
        }

        [HttpPut("delete")]
        public async Task<IActionResult> Delete([FromQuery] EntityIdentityRequest<int> request)
        {
            await _unitOfWork.Deductions.Delete(request.Id);
            return Ok(ApiResult<bool>.Success("Xoá khấu trừ thành công", true));
        }

    }
}
