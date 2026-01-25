using HRM_BE.Core.ISeedWorks;
using HRM_BE.Core.Models.Common;
using HRM_BE.Core.Models.Payroll_Timekeeping.Payroll;
using HRM_BE.Core.Models.Payroll_Timekeeping.TimekeepingRegulation;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace HRM_BE.Api.Controllers.Payroll_Timekeeping.Payroll
{
    [Route("api/payroll-inquiry")]
    [ApiController]
    public class PayrollInquiryController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;
        public PayrollInquiryController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        /// <summary>
        /// Nhân viên gửi thắc mắc về bảng lương
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        [HttpPost("create")]
        public async Task<ApiResult<PayrollInquiryDto>> Create(CreatePayrollInquiryRequest request)
        {
            var result = await _unitOfWork.PayrollInquiries.Create(request);
            return ApiResult<PayrollInquiryDto>.Success("Nhân viên gửi thắc mắc về bảng lương thành công", result);
        }

        /// <summary>
        /// Quản lý sẽ xem được những nội dung thắc mắc của nhân viên về bảng lương theo payrollId
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        [HttpGet("paging")]
        public async Task<PagingResult<PayrollInquiryDto>> Paging([FromQuery] PagingPayrollInquiryRequest request)
        {
            var result = await _unitOfWork.PayrollInquiries.Paging(request.PayrollDetailId, request.PayrollId, request.SortBy, request.OrderBy, request.PageIndex, request.PageSize);
            return result;
        }

        [HttpGet("get-by-id")]
        public async Task<PayrollInquiryDto> GetById([FromQuery] EntityIdentityRequest<int> request)
        {
            var result = await _unitOfWork.PayrollInquiries.GetById(request.Id);
            return result;
        }
    }
}
