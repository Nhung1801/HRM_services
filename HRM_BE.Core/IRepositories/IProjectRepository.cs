using HRM_BE.Core.Data.Staff;
using HRM_BE.Core.Data.Task;
using HRM_BE.Core.ISeedWorks;
using HRM_BE.Core.Models.Common;
using HRM_BE.Core.Models.Project;
using HRM_BE.Core.Models.Staff;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HRM_BE.Core.IRepositories
{
    public interface IProjectRepository : IRepositoryBase<Project, int>
    {
        Task<List<ProjectRoleDto>> GetRoles();

        Task<ProjectDto> GetByIdAsync(int id);

        Task<List<ProjectDto>> GetAllAsync(string? KeyWord);

        Task<PagingResult<ProjectDto>> GetPagingAsync(string? KeyWord, string? sortBy, string? orderBy, int pageIndex = 1, int pageSize = 10);

        Task<List<ProjectDto>> GetAllByEmployeeAsync(string? KeyWord,int employeeId);

        Task<PagingResult<ProjectDto>> GetPagingByEmployeeAsync(string? KeyWord, int employeeId , string? sortBy, string? orderBy, int pageIndex = 1, int pageSize = 10);

        Task<PagingResult<EmployeeDto>> PagingEmployeeNotInProject(string? keyWord, int? organizationId, int? leaderOrganizationId, int? positionId, WorkingStatus? workingStatus, AccountStatus? accountStatus, int? cityId, int? districtId, int? wardId, int? streetId, string? sortBy, string? orderBy, int projectId, int pageIndex = 1, int pageSize = 10);

        Task<ProjectDto> CreateAsync(CreateProjectRequest request);

        Task<ProjectDto> UpdateAsync(UpdateProjectRequest request);

        Task AddEmployeeToProjectAsync(int projectId, int employeeId);

        Task RemoveEmployeeFromProjectAsync(int projectId, int employeeId);

        Task UpdateProjectBasicInfoAsync(UpdateProjectBasicInfoRequest request);


        Task UpdateEmployeeRoleAsync(UpdateEmployeeRoleFromProject request);

        Task DeleteSoftAsync(int id);
    }
}
