using HRM_BE.Core.Constants.System;
using HRM_BE.Core.Data.Staff;
using HRM_BE.Core.Data.Task;
using HRM_BE.Core.ISeedWorks;
using HRM_BE.Core.Models.Common;
using HRM_BE.Core.Models.Content.Banner;
using HRM_BE.Core.Models.Department;
using HRM_BE.Core.Models.Staff;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HRM_BE.Core.IRepositories
{
    public interface IDepartmentRepository : IRepositoryBase<Department, int>
    {
        Task<List<DepartmentRoleDto>> GetRoles();

        Task<DepartmentDto> GetByIdAsync(int id);

        Task<List<DepartmentDto>> GetAllAsync(string? KeyWord, int? organizationId);

        Task<PagingResult<DepartmentDto>> GetPagingAsync(string? KeyWord, int? organizationId, string? sortBy, string? orderBy, int pageIndex = 1, int pageSize = 10);

        Task<List<DepartmentDto>> GetAllByEmployeeAsync(string? KeyWord, int? organizationId, int employeeId);

        Task<PagingResult<EmployeeDto>> PagingEmployeeNotInDepartment(string? keyWord, int? organizationId, int? leaderOrganizationId, int? positionId, WorkingStatus? workingStatus, AccountStatus? accountStatus, int? cityId, int? districtId, int? wardId, int? streetId, string? sortBy, string? orderBy, int departmentId, int pageIndex = 1, int pageSize = 10);

        Task<DepartmentDto> CreateAsync(CreateDepartmentRequest request);

        Task<DepartmentDto> UpdateAsync(UpdateDepartmentRequest request);

        Task AddEmployeeToDepartmentAsync(int departmentId, int employeeId);

        Task RemoveEmployeeFromDepartmentAsync(int departmentId, int employeeId);

        Task UpdateDepartmentBasicInfoAsync(UpdateDepartmentBasicInfoRequest request);

        Task UpdateEmployeeRoleAsync(UpdateEmployeeRoleFromDepartment request);


        Task DeleteSoftAsync(int id);
    }
}
