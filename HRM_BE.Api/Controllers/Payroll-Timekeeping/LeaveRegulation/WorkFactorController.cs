using HRM_BE.Core.ISeedWorks;
using HRM_BE.Core.Models.Common;
using HRM_BE.Core.Models.Payroll_Timekeeping.LeaveRegulation;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace HRM_BE.Api.Controllers.Payroll_Timekeeping.LeaveRegulation
{
    [Route("api/work-factor")]
    [ApiController]
    public class WorkFactorController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;
        public WorkFactorController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }


        /// <summary>
        /// Lấy danh sách các hệ số công theo từng năm bên FE khi tích hợp thì mặc định truyền vào năm hiện tại
        /// </summary>
        /// <param name="year"></param>
        /// <returns></returns>
        [HttpGet("get-by-year")]
        public async Task<List<WorkFactorDto>> GetByYear([FromQuery] int year)
        {
            var result = await _unitOfWork.WorkFactor.GetByYear(year);
            return result;
        }

        /// <summary>
        /// Lưu hoặc cập nhật danh sách hệ số công cho một năm.
        /// </summary>
        /// <param name="year"></param>
        /// <param name="requests"></param>
        /// <returns></returns>
        [HttpPost("save-work-factors")]
        public async Task<IActionResult> SaveFactors(int year, [FromBody] List<SaveWorkFactorRequest> requests)
        {
            await _unitOfWork.WorkFactor.SaveFactors(year, requests);
            return Ok(ApiResult<bool>.Success("Thiết lập hệ số công thành công", true));
        }
    }
}
