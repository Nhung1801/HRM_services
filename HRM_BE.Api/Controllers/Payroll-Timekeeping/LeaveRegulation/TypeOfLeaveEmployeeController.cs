using HRM_BE.Core.ISeedWorks;
using HRM_BE.Core.Models.Common;
using HRM_BE.Core.Models.Payroll_Timekeeping.LeaveRegulation;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace HRM_BE.Api.Controllers.Payroll_Timekeeping.LeaveRegulation
{
    [Route("api/type-of-leave-employee")]
    [ApiController]
    public class TypeOfLeaveEmployeeController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;

        public TypeOfLeaveEmployeeController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        [HttpGet]
        [Route("get-or-create")]
        public async Task<ApiResult<TypeOfLeaveEmployeeDto>> GetOrCreate([FromQuery] GetTypeOfLeaveEmployeeRequest request)
        {
            var typeOfLeaveEmployee = await _unitOfWork.TypeOfLeaveEmployee.GetOrCreate(request.EmployeeId, request.TypeOfLeaveId, request.Year);
            return new ApiResult<TypeOfLeaveEmployeeDto>("Thành công", typeOfLeaveEmployee);
        }

        [HttpGet]
        [Route("check-days-remaining")]
        public async Task<ApiResult<bool>> CheckDaysRemaining([FromQuery] UpdateDaysRemainingTypeOfLeaveEmployeeRequest request)
        {
            var status = await _unitOfWork.TypeOfLeaveEmployee.CheckDaysRemaining(request.DaysRemaining, request.EmployeeId, request.TypeOfLeaveId, request.Year);
            return new ApiResult<bool>("Thành công", status);
        }

        [HttpPut]
        [Route("update-days-remaining")]
        public async Task<ApiResult<bool>> UpdateDaysRemaining([FromBody] UpdateDaysRemainingTypeOfLeaveEmployeeRequest request)
        {
            var status = await _unitOfWork.TypeOfLeaveEmployee.UpdateDaysRemaining(request.DaysRemaining,request.EmployeeId, request.TypeOfLeaveId, request.Year);
            return new ApiResult<bool>("Thành công", status);
        }

    }
}
