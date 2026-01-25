using HRM_BE.Core.ISeedWorks;
using HRM_BE.Core.Models.Common;
using HRM_BE.Core.Models.Payroll_Timekeeping.LeaveRegulation;
using HRM_BE.Core.Models.Payroll_Timekeeping.Payroll;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace HRM_BE.Api.Controllers.Payroll_Timekeeping.Payroll
{
    [Route("api/salary-component")]
    [ApiController]
    public class SalaryComponentController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;
        public SalaryComponentController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        /// <summary>
        /// HRM-là Admin, tôi muốn thêm mới thành phần lương
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        [HttpPost("create")]
        public async Task<ApiResult<List<SalaryComponentDto>>> Create(List<CreateSalaryComponentRequest> requests)
        {
            var result = await _unitOfWork.SalaryComponents.Create(requests);
            return ApiResult<List<SalaryComponentDto>>.Success("Thêm thành phần lương thành công", result);
        }

        /// <summary>
        /// HRM-là Admin, tôi muốn xem danh sách thành phần lương
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        [HttpGet("paging")]
        public async Task<PagingResult<SalaryComponentDto>> Paging([FromQuery] PagingSalaryComponentRequest request)
        {
            var result = await _unitOfWork.SalaryComponents.Paging(request.Name, request.Status, request.OrganizationId, request.SortBy, request.OrderBy, request.PageIndex, request.PageSize);
            return result;
        }

        [HttpGet("get-by-id")]
        public async Task<SalaryComponentDto> GetById([FromQuery] EntityIdentityRequest<int> request)
        {
            var result = await _unitOfWork.SalaryComponents.GetById(request.Id);
            return result;
        }

        /// <summary>
        /// HRM-là Admin, tôi muốn sửa thành phần lương
        /// </summary>
        /// <param name="id"></param>
        /// <param name="request"></param>
        /// <returns></returns>
        [HttpPut("update")]
        public async Task<IActionResult> Update(int id, UpdateSalaryComponentRequest request)
        {
            await _unitOfWork.SalaryComponents.Update(id, request);
            return Ok(ApiResult<bool>.Success("Cập nhật thành phần lương thành công", true));
        }

        /// <summary>
        /// HRM-là Admin, tôi muốn xóa thành phần lương
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        [HttpDelete("delete")]
        public async Task<IActionResult> Delete([FromQuery] EntityIdentityRequest<int> request)
        {
            var isFixedCharacteristic = await _unitOfWork.SalaryComponents.IsFixedCharacteristic(request.Id);

            if (isFixedCharacteristic)
            {
                return BadRequest(ApiResult<bool>.Failure("Không thể xóa thành phần lương có thuộc tính cố định", false));
            }

            await _unitOfWork.SalaryComponents.Delete(request.Id);
            return Ok(ApiResult<bool>.Success("Xoá thành phần lương thành công", true));
        }

        /// <summary>
        /// Xem danh sách mặc định các thành phần lương chưa được thêm vào database
        /// </summary>
        /// <returns></returns>
        [HttpGet("get-default-salary-components")]
        public async Task<List<SalaryComponentDto>> GetDefaultSalaryComponents()
        {
            var result = await _unitOfWork.SalaryComponents.GetDefaultSalaryComponents();
            return result;
        }

        /// <summary>
        /// Lấy danh sách gợi ý cho công thức giá trị của thành phần lương
        /// </summary>
        /// <param name="organizationId"></param>
        /// <param name="formulaPart"></param>
        /// <returns></returns>
        [HttpGet("get-formula-suggestions")]
        public async Task<ApiResult<object>> GetFormulaSuggestions([FromQuery] int organizationId)
        {
            // Lấy danh sách toán tử
            var formulaOperators = new List<string> { "+", "-", "*", "/", "(", ")" };

            // Lấy danh sách ComponentCode và ComponentName của các thành phần lương theo OrganizationId
            var salaryComponents = await _unitOfWork.SalaryComponents.GetByOrganizationId(organizationId);

            // Lấy danh sách gợi ý cho công thức giá trị
            var suggestions = salaryComponents.Select(s => new FormularSuggestionDto
            {
                ComponentCode = s.ComponentCode,
                ComponentName = s.ComponentName
            }).ToList();

            return ApiResult<object>.Success("Danh sách toán tử và tham số", new { formulaOperators, suggestions });
        }

    }

    public class FormularSuggestionDto
    {
        public string ComponentCode { get; set; }
        public string ComponentName { get; set; }
    }
}
