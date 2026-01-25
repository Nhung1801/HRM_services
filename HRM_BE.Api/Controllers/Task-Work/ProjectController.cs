using HRM_BE.Core.ISeedWorks;
using HRM_BE.Core.Models.Common;
using HRM_BE.Core.Models.Department;
using HRM_BE.Core.Models.Project;
using HRM_BE.Core.Models.Staff;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace HRM_BE.Api.Controllers.Task_Work
{
    [Route("api/project")]
    [ApiController]
    public class ProjectController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;
        public ProjectController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        [HttpGet]
        [Route("get-roles")]
        public async Task<ApiResult<List<ProjectRoleDto>>> GetRoles()
        {
            var result = await _unitOfWork.Projects.GetRoles();
            return ApiResult<List<ProjectRoleDto>>.Success("Thành công", result);
        }

        [HttpGet]
        [Route("get-by-id")]
        public async Task<ApiResult<ProjectDto>> GetById([FromQuery] EntityIdentityRequest<int> request)
        {
            var result = await _unitOfWork.Projects.GetByIdAsync(request.Id);
            return ApiResult<ProjectDto>.Success("Thành công", result);
        }

        [HttpGet]
        [Route("paging")]
        public async Task<ApiResult<PagingResult<ProjectDto>>> Paging([FromQuery] GetProjectRequest request)
        {
            var result = await _unitOfWork.Projects.GetPagingAsync(request.KeyWord,request.SortBy,request.OrderBy,request.PageIndex,request.PageSize);
            return ApiResult<PagingResult<ProjectDto>>.Success("Thành công", result);
        }

        [HttpGet]
        [Route("get-all")]
        public async Task<ApiResult<List<ProjectDto>>> GetAll([FromQuery] GetAllProjectRequest request)
        {
            var result = await _unitOfWork.Projects.GetAllAsync(request.KeyWord);
            return ApiResult<List<ProjectDto>>.Success("Thành công", result);
        }

        [HttpGet]
        [Route("get-all-by-employee")]
        public async Task<ApiResult<List<ProjectDto>>> GetAllByEmployee([FromQuery] GetAllProjectByEmployeeRequest request)
        {
            var result = await _unitOfWork.Projects.GetAllByEmployeeAsync(request.KeyWord,request.EmployeeId);
            return ApiResult<List<ProjectDto>>.Success("Thành công", result);
        }

        [HttpGet]
        [Route("get-paging-by-employee")]
        public async Task<ApiResult<PagingResult<ProjectDto>>> GetPagingByEmployee([FromQuery] GetPagingProjectByEmployeeRequest request)
        {
            var result = await _unitOfWork.Projects.GetPagingByEmployeeAsync(request.KeyWord, request.EmployeeId, request.SortBy, request.OrderBy, request.PageIndex, request.PageSize);
            return ApiResult<PagingResult<ProjectDto>>.Success("Thành công", result);
        }


        [HttpGet("paging-employee-not-in-project")]
        public async Task<PagingResult<EmployeeDto>> Paging([FromQuery] GetEmployeeNotInProjectPagingRequest request)
        {
            var result = await _unitOfWork.Projects.PagingEmployeeNotInProject(request.keyWord, request.OrganizationId, request.LeaderOrganizationId, request.StaffPositionId, request.WorkingStatus, request.AccountStatus, request.CityId, request.DistrictId, request.WardId, request.StreetId, request.SortBy, request.OrderBy, request.ProjectId, request.PageIndex, request.PageSize);
            return result;
        }

        [HttpPost]
        [Route("create")]
        public async Task<ApiResult<ProjectDto>> Create([FromBody] CreateProjectRequest request)
        {
            var result = await _unitOfWork.Projects.CreateAsync(request);
            return ApiResult<ProjectDto>.Success("Thành công", result);
        }

        [HttpPut]
        [Route("update")]
        public async Task<ApiResult<ProjectDto>> Update([FromBody] UpdateProjectRequest request)
        {
            var result = await _unitOfWork.Projects.UpdateAsync(request);
            return ApiResult<ProjectDto>.Success("Thành công", result);
        }

        [HttpPut]
        [Route("update-info-base")]
        public async Task<ApiResult<bool>> UpdateDepartmentBasicInfo([FromBody] UpdateProjectBasicInfoRequest request)
        {
            await _unitOfWork.Projects.UpdateProjectBasicInfoAsync(request);
            return ApiResult<bool>.Success("Thành công", true);
        }

        [HttpPut]
        [Route("add-employee-in-project")]
        public async Task<ApiResult<bool>> AddEmployeeToProject([FromBody] AddOrRemoveEmployeeFromProject request)
        {
            await _unitOfWork.Projects.AddEmployeeToProjectAsync(request.ProjectId, request.EmployeeId);
            return ApiResult<bool>.Success("Thành công", true);
        }

        [HttpPut]
        [Route("remove-employee-in-project")]
        public async Task<ApiResult<bool>> RemoveEmployeeFromProject([FromBody] AddOrRemoveEmployeeFromProject request)
        {
            await _unitOfWork.Projects.RemoveEmployeeFromProjectAsync(request.ProjectId, request.EmployeeId);
            return ApiResult<bool>.Success("Thành công", true);
        }

        [HttpPut]
        [Route("update-role-employee-in-project")]
        public async Task<ApiResult<bool>> UpdateRoleEmployeeFromProject([FromBody] UpdateEmployeeRoleFromProject request)
        {
            await _unitOfWork.Projects.UpdateEmployeeRoleAsync(request);
            return ApiResult<bool>.Success("Thành công", true);
        }

        [HttpPut]
        [Route("delete-soft")]
        public async Task<ApiResult<ProjectDto>> Delete([FromBody] EntityIdentityRequest<int> request)
        {
            await _unitOfWork.Projects.DeleteSoftAsync(request.Id);
            return ApiResult<ProjectDto>.Success("Thành công", null);
        }
    }
}
