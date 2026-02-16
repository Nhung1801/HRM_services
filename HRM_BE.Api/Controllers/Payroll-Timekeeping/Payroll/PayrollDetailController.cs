using Azure.Core;
using HRM_BE.Core.Data.Payroll_Timekeeping.Payroll;
using HRM_BE.Core.ISeedWorks;
using HRM_BE.Core.Models.Common;
using HRM_BE.Core.Models.Payroll_Timekeeping.Payroll;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace HRM_BE.Api.Controllers.Payroll_Timekeeping.Payroll
{
    [Route("api/payroll-detail")]
    [ApiController]
    public class PayrollDetailController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;
        public PayrollDetailController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        /// <summary>
        /// HRM-là Admin, tôi muốn xem danh sách bảng lương chi tiết
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        [HttpGet("paging")]
        public async Task<PagingResult<PayrollDetailDto>> Paging([FromQuery] PagingPayrollDetailRequest request)
        {
            var result = await _unitOfWork.PayrollDetails.Paging(request.OrganizationId, request.Name, request.PayrollId, request.EmployeeId, request.SortBy, request.OrderBy, request.PageIndex, request.PageSize);
            return result;
        }

        [HttpGet("get-by-id")]
        public async Task<PayrollDetailDto> GetById([FromQuery] EntityIdentityRequest<int> request)
        {
            var result = await _unitOfWork.PayrollDetails.GetById(request.Id);
            return result;
        }

        [HttpPost("calculate-and-save-payroll-details")]
        public async Task<IActionResult> CalculateAndSavePayrollDetails([FromQuery] int payrollId)
        {
            try
            {
                await _unitOfWork.PayrollDetails.CalculateAndSavePayrollDetails(payrollId);
                return Ok(ApiResult<bool>.Success("Tính toán bảng lương chi tiết thành công", true));
            }
            catch (Exception ex)
            {
                return Ok(ApiResult<bool>.Failure(ex.Message, false));
            }
        }

        /// <summary>
        /// HRM - Cập nhật (tính lại) phiếu lương cho 1 bảng lương.
        /// FE đang dùng route: payroll-detail/recalculate-and-save-payroll-details
        /// </summary>
        [HttpPost("recalculate-and-save-payroll-details")]
        public async Task<IActionResult> RecalculateAndSavePayrollDetails([FromQuery] int payrollId)
        {
            try
            {
                await _unitOfWork.PayrollDetails.RecalculateAndSavePayrollDetails(payrollId);
                return Ok(ApiResult<bool>.Success("Cập nhật phiếu lương thành công", true));
            }
            catch (Exception ex)
            {
                return Ok(ApiResult<bool>.Failure(ex.Message, false));
            }
        }

        [HttpPost("fetch-payroll-details")]
        public async Task<List<PayrollDetailDto>> FetchPayrollDetails(int payrollId)
        {
            var result = await _unitOfWork.PayrollDetails.FetchPayrollDetails(payrollId);
            return result;
        }

        /// <summary>
        /// Quản lý gửi bảng lương cho nhân viên xem
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        [HttpPost("send-payroll-detail-confirmation")]
        public async Task<IActionResult> SendPayrollDetailConfirmation([FromBody] UpdateSendPayrollDetailConfirmationRequest request)
        {
            try
            {
                await _unitOfWork.PayrollDetails.SendPayrollDetailConfirmation(request);
                return Ok(ApiResult<bool>.Success("Gửi xác nhận bảng lương thành công", true));
            }
            catch (Exception ex)
            {
                return Ok(ApiResult<bool>.Failure(ex.Message, false));
            }
        }

        /// <summary>
        /// Nhân viên xem và xác nhận bảng lương
        /// </summary>
        /// <param name="payrollDetailId"></param>
        /// <returns></returns>
        [HttpPost("confirm-payroll-detail-by-employee")]
        public async Task<IActionResult> ConfirmPayrollDetailByEmployee([FromQuery] int payrollDetailId)
        {
            try
            {
                await _unitOfWork.PayrollDetails.ConfirmPayrollDetailByEmployee(payrollDetailId);
                return Ok(ApiResult<bool>.Success("Nhân viên xác nhận bảng lương thành công", true));
            }
            catch (Exception ex)
            {
                return Ok(ApiResult<bool>.Failure(ex.Message, false));
            }
        }
    }
}
