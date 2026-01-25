using HRM_BE.Core.ISeedWorks;
using HRM_BE.Core.Models.Common;
using HRM_BE.Core.Models.Contract.NatureOfLabor;
using HRM_BE.Core.Models.Payroll_Timekeeping.LeaveRegulation;
using HRM_BE.Core.Models.Payroll_Timekeeping.TimekeepingRegulation;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace HRM_BE.Api.Controllers.Payroll_Timekeeping.LeaveRegulation
{
    [Route("api/general-leave-regulation")]
    [ApiController]
    public class GeneralLeaveRegulationController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;
        public GeneralLeaveRegulationController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        /// <summary>
        /// HRM-là Admin, tôi muốn xem quy định nghỉ - Chung
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        [HttpGet("paging")]
        public async Task<PagingResult<GeneralLeaveRegulationDto>> Paging([FromQuery] PagingGeneralLeaveRegulationRequest request)
        {
            var result = await _unitOfWork.GeneralLeaveRegulation.Paging(request.OrganizationId, request.SortBy, request.OrderBy, request.PageIndex, request.PageSize);
            return result;
        }

        [HttpGet("get-by-id")]
        public async Task<GeneralLeaveRegulationDto> GetById([FromQuery] EntityIdentityRequest<int> request)
        {
            var result = await _unitOfWork.GeneralLeaveRegulation.GetById(request.Id);
            return result;
        }

        /// <summary>
        /// HRM-là Admin, tôi muốn sửa quy định nghỉ - Chung
        /// </summary>
        /// <param name="id"></param>
        /// <param name="request"></param>
        /// <returns></returns>
        [HttpPut("update")]
        public async Task<IActionResult> Update(int id, UpdateGeneralLeaveRegulationRequest request)
        {
            await _unitOfWork.GeneralLeaveRegulation.Update(id, request);
            return Ok(ApiResult<bool>.Success("Cập nhật quy định nghỉ chung thành công", true));
        }

        /// <summary>
        /// Là Admin, tôi muốn thiết lập quy định nghỉ - Chung
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        [HttpPost("upsert")]
        public async Task<IActionResult> Upsert([FromBody] CreateGeneralLeaveRegulationRequest request)
        {
            // Kiểm tra xem đã tồn tại quy định nghỉ - Chung cho OrganizationId chưa
            var existingRecord = await _unitOfWork.GeneralLeaveRegulation
                                                  .GetByOrganizationId(request.OrganizationId);

            if (existingRecord != null) // Nếu đã tồn tại, thực hiện update
            {
                await _unitOfWork.GeneralLeaveRegulation.UpdateV2(request.OrganizationId, request);
                var updatedResult = await _unitOfWork.GeneralLeaveRegulation.GetByOrganizationId(request.OrganizationId);
                return Ok(ApiResult<GeneralLeaveRegulationDto>.Success("Cập nhật thành công", updatedResult));
            }
            else // Nếu chưa tồn tại, thực hiện create
            {
                var result = await _unitOfWork.GeneralLeaveRegulation.Create(request);
                return Ok(ApiResult<GeneralLeaveRegulationDto>.Success("Thêm mới thành công", result));
            }
        }
    }
}
