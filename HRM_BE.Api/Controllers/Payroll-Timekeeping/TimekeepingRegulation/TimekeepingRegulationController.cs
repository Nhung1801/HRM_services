using HRM_BE.Core.ISeedWorks;
using HRM_BE.Core.Models.Common;
using HRM_BE.Core.Models.Payroll_Timekeeping.LeaveRegulation;
using HRM_BE.Core.Models.Payroll_Timekeeping.TimekeepingRegulation;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace HRM_BE.Api.Controllers.Payroll_Timekeeping.TimekeepingRegulation
{
    [Route("api/timekeeping-regulation")]
    [ApiController]
    public class TimekeepingRegulationController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;
        public TimekeepingRegulationController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        /// <summary>
        /// Lấy thông tin quy định chấm công theo OrganizationId
        /// </summary>
        /// <param name="organizationId"></param>
        /// <returns></returns>
        [HttpGet("get-by-organization")]
        public async Task<IActionResult> GetByOrganization([FromQuery] int organizationId)
        {
            var result = await _unitOfWork.TimekeepingRegulation
                                          .GetByOrganizationId(organizationId);


            if (result == null)
                return NotFound(ApiResult<string>.Failure("Không tìm thấy quy định chấm công cho tổ chức này"));

            return Ok(ApiResult<TimekeepingRegulationDto>.Success("Lấy thông tin quy định chấm công thành công", result));
        }


        /// <summary>
        /// Tôi muốn thiết lập quy định chấm công
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        [HttpPost("upsert")]
        public async Task<IActionResult> Upsert([FromBody] CreateTimeKeepingRegulationRequest request)
        {
            // Kiểm tra xem đã tồn tại quy định chấm công cho OrganizationId chưa
            var existingRecord = await _unitOfWork.TimekeepingRegulation
                                                  .GetByOrganizationId(request.OrganizationId);

            if (existingRecord != null) // Nếu đã tồn tại, thực hiện update
            {
                await _unitOfWork.TimekeepingRegulation.UpdateV2(request.OrganizationId, request);
                var updatedResult = await _unitOfWork.TimekeepingRegulation.GetByOrganizationId(request.OrganizationId);
                return Ok(ApiResult<TimekeepingRegulationDto>.Success("Cập nhật thành công", updatedResult));
            }
            else // Nếu chưa tồn tại, thực hiện create
            {
                var result = await _unitOfWork.TimekeepingRegulation.Create(request);
                return Ok(ApiResult<TimekeepingRegulationDto>.Success("Thêm mới thành công", result));
            }
        }

        [HttpPost("create")]
        public async Task<ApiResult<TimekeepingRegulationDto>> Create(CreateTimeKeepingRegulationRequest request)
        {
            var result = await _unitOfWork.TimekeepingRegulation.Create(request);
            return ApiResult<TimekeepingRegulationDto>.Success("Thêm quy định chấm công thành công", result);
        }

        [HttpGet("paging")]
        public async Task<PagingResult<TimekeepingRegulationDto>> Paging([FromQuery] PagingTimekeepingRegulationRequest request)
        {
            var result = await _unitOfWork.TimekeepingRegulation.Paging(request.OrganizationId, request.SortBy, request.OrderBy, request.PageIndex, request.PageSize);
            return result;
        }

        [HttpGet("get-by-id")]
        public async Task<TimekeepingRegulationDto> GetById([FromQuery] EntityIdentityRequest<int> request)
        {
            var result = await _unitOfWork.TimekeepingRegulation.GetById(request.Id);
            return result;
        }

        [HttpPut("update")]
        public async Task<IActionResult> Update(int id, UpdateTimekeepingRegulationRequest request)
        {
            await _unitOfWork.TimekeepingRegulation.Update(id, request);
            return Ok(ApiResult<bool>.Success("Cập nhật quy định chấm công thành công", true));
        }

    }
}
