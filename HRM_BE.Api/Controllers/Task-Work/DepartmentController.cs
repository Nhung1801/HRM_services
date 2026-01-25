using HRM_BE.Core.ISeedWorks;
using HRM_BE.Core.Models.Common;
using HRM_BE.Core.Models.Department;
using HRM_BE.Core.Models.Staff;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace HRM_BE.Api.Controllers.Task_Work
{
    [Route("api/department")]
    [ApiController]
    public class DepartmentController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;
        public DepartmentController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        [HttpGet]
        [Route("get-roles")]
        public async Task<ApiResult<List<DepartmentRoleDto>>> GetRoles()
        {
            var result = await _unitOfWork.Departments.GetRoles();
            return ApiResult<List<DepartmentRoleDto>>.Success("Thành công", result);
        }

        [HttpGet]
        [Route("get-by-id")]
        public async Task<ApiResult<DepartmentDto>> GetById([FromQuery] EntityIdentityRequest<int> request)
        {
            var result = await _unitOfWork.Departments.GetByIdAsync(request.Id);
            return ApiResult<DepartmentDto>.Success("Thành công", result);
        }

        [HttpGet]
        [Route("paging")]
        public async Task<ApiResult<PagingResult<DepartmentDto>>> Paging([FromQuery] GetDepartmentRequest request)
        {
            var result = await _unitOfWork.Departments.GetPagingAsync(request.KeyWord,request.OrganizationId,request.SortBy,request.OrderBy,request.PageIndex,request.PageSize);
            return ApiResult<PagingResult<DepartmentDto>>.Success("Thành công", result);
        }

        [HttpGet]
        [Route("get-all")]
        public async Task<ApiResult<List<DepartmentDto>>> GetAll([FromQuery] GetAllDepartmentRequest request)
        {
            var result = await _unitOfWork.Departments.GetAllAsync(request.KeyWord,request.OrganizationId);
            return ApiResult<List<DepartmentDto>>.Success("Thành công", result);
        }

        [HttpGet]
        [Route("get-all-by-employee")]
        public async Task<ApiResult<List<DepartmentDto>>> GetAllByEmployee([FromQuery] GetAllDepartmentByEmployeeRequest request)
        {
            var result = await _unitOfWork.Departments.GetAllByEmployeeAsync(request.KeyWord, request.OrganizationId,request.EmployeeId);
            return ApiResult<List<DepartmentDto>>.Success("Thành công", result);
        }

        [HttpGet("paging-employee-not-in-department")]
        public async Task<PagingResult<EmployeeDto>> Paging([FromQuery] GetEmployeeNotInDepartmentPagingRequest request)
        {
            var result = await _unitOfWork.Departments.PagingEmployeeNotInDepartment(request.keyWord, request.OrganizationId, request.LeaderOrganizationId, request.StaffPositionId, request.WorkingStatus, request.AccountStatus, request.CityId, request.DistrictId, request.WardId, request.StreetId, request.SortBy, request.OrderBy,request.DepartmentId ,request.PageIndex, request.PageSize);
            return result;
        }

        [HttpPost]
        [Route("create")]
        public async Task<ApiResult<DepartmentDto>> Create([FromBody] CreateDepartmentRequest request)
        {
            var result = await _unitOfWork.Departments.CreateAsync(request);
            return ApiResult<DepartmentDto>.Success("Thành công", result);
        }

        [HttpPut]
        [Route("update")]
        public async Task<ApiResult<DepartmentDto>> Update([FromBody] UpdateDepartmentRequest request)
        {
            var result = await _unitOfWork.Departments.UpdateAsync(request);
            return ApiResult<DepartmentDto>.Success("Thành công", result);
        }

        [HttpPut]
        [Route("update-info-base")]
        public async Task<ApiResult<bool>> UpdateDepartmentBasicInfo([FromBody] UpdateDepartmentBasicInfoRequest request)
        {
            await _unitOfWork.Departments.UpdateDepartmentBasicInfoAsync(request);
            return ApiResult<bool>.Success("Thành công", true);
        }

        [HttpPut]
        [Route("add-employee-in-department")]
        public async Task<ApiResult<bool>> AddEmployeeToDepartment([FromBody] AddOrRemoveEmployeeFromDepartment request)
        {
            await _unitOfWork.Departments.AddEmployeeToDepartmentAsync(request.DepartmentId,request.EmployeeId);
            return ApiResult<bool>.Success("Thành công", true);
        }

        [HttpPut]
        [Route("remove-employee-in-department")]
        public async Task<ApiResult<bool>> RemoveEmployeeFromDepartment([FromBody] AddOrRemoveEmployeeFromDepartment request)
        {
            await _unitOfWork.Departments.RemoveEmployeeFromDepartmentAsync(request.DepartmentId, request.EmployeeId);
            return ApiResult<bool>.Success("Thành công", true);
        }

        [HttpPut]
        [Route("update-role-employee-in-department")]
        public async Task<ApiResult<bool>> UpdateRoleEmployeeFromDepartment([FromBody] UpdateEmployeeRoleFromDepartment request)
        {
            await _unitOfWork.Departments.UpdateEmployeeRoleAsync(request);
            return ApiResult<bool>.Success("Thành công", true);
        }

        [HttpPut]
        [Route("delete-soft")]
        public async Task<ApiResult<DepartmentDto>> Delete([FromBody] EntityIdentityRequest<int> request)
        {
            await _unitOfWork.Departments.DeleteSoftAsync(request.Id);
            return ApiResult<DepartmentDto>.Success("Thành công", null);
        }
    }
}
