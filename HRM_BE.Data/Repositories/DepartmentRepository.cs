using AutoMapper;
using HRM_BE.Core.Constants.System;
using HRM_BE.Core.Data.Company;
using HRM_BE.Core.Data.Content;
using HRM_BE.Core.Data.Staff;
using HRM_BE.Core.Data.Task;
using HRM_BE.Core.Extension;
using HRM_BE.Core.IRepositories;
using HRM_BE.Core.Models.Common;
using HRM_BE.Core.Models.Content.Banner;
using HRM_BE.Core.Models.Department;
using HRM_BE.Core.Models.Staff;
using HRM_BE.Data.SeedWorks;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HRM_BE.Data.Repositories
{
    public class DepartmentRepository : RepositoryBase<Department, int>, IDepartmentRepository
    {
        private readonly IMapper _mapper;
        public DepartmentRepository(HrmContext context, IMapper mapper, IHttpContextAccessor httpContextAccessor) : base(context, httpContextAccessor)
        {
            _mapper = mapper;
        }


        public async Task<List<DepartmentRoleDto>> GetRoles()
        {
            var query= _dbContext.DepartmentRoles.AsQueryable();
            var data = await _mapper.ProjectTo<DepartmentRoleDto>(query).ToListAsync();
            return data;
        }

        public async Task<DepartmentDto> GetByIdAsync(int id)
        {
            var department = await _dbContext.Departments
                .Include(d => d.DepartmentEmployees)
                    .ThenInclude(pe => pe.Employee)
                .FirstOrDefaultAsync(d => d.Id == id && d.IsDeleted != true);

            if (department == null)
            {
                throw new KeyNotFoundException($"Department with ID {id} not found.");
            }

            return _mapper.Map<DepartmentDto>(department);
        }

        public async Task<List<DepartmentDto>> GetAllAsync(string? KeyWord, int? organizationId)
        {

            var query = _dbContext.Departments
                           .Include(d => d.DepartmentEmployees).Where(d => d.IsDeleted != true)
                           .Include(d=>d.Projects)
                           .AsQueryable();

            if (!string.IsNullOrEmpty(KeyWord))
            {
                string search = KeyWord.ToLower();
                query = query.Where(b => b.Name.ToLower().Contains(KeyWord.ToLower()) || b.Description.ToLower().Contains(KeyWord.ToLower()));
            }
            if (organizationId.HasValue)
            {
                query = query.Where(b => b.OrganizationId == organizationId.Value);
            }

            return _mapper.Map<List<DepartmentDto>>(query);

        }

        public async Task<PagingResult<DepartmentDto>> GetPagingAsync(string? KeyWord, int? organizationId, string? sortBy, string? orderBy, int pageIndex = 1, int pageSize = 10)
        {

            var query = _dbContext.Departments
                                       .Include(d => d.DepartmentEmployees).Where(d => d.IsDeleted != true)
                                       .AsQueryable();
            if (!string.IsNullOrEmpty(KeyWord))
            {
                string search = KeyWord.ToLower();
                query = query.Where(b => b.Name.ToLower().Contains(KeyWord.ToLower()) || b.Description.ToLower().Contains(KeyWord.ToLower()));
            }

            if (organizationId.HasValue)
            {
                query = query.Where(b => b.OrganizationId == organizationId.Value);
            }
            int total = await query.CountAsync();

            if (pageIndex == null) pageIndex = 1;
            if (pageSize == null) pageSize = total;


            if (string.IsNullOrEmpty(orderBy) && string.IsNullOrEmpty(sortBy))
            {
                query = query.OrderByDescending(b => b.Id);
            }
            else if (string.IsNullOrEmpty(orderBy))
            {
                if (sortBy == SortByConstant.Asc)
                {
                    query = query.OrderBy(b => b.Id);
                }
                else
                {
                    query = query.OrderByDescending(b => b.Id);
                }
            }
            else if (string.IsNullOrEmpty(sortBy))
            {
                query = query.OrderByDescending(b => b.Id);
            }
            else
            {
                if (orderBy == OrderByConstant.Id && sortBy == SortByConstant.Asc)
                {
                    query = query.OrderBy(b => b.Id);
                }
                else if (orderBy == OrderByConstant.Id && sortBy == SortByConstant.Desc)
                {
                    query = query.OrderByDescending(b => b.Id);
                }
            }

            query = query
            .Skip((pageIndex - 1) * pageSize)
            .Take(pageSize);


            var data = await _mapper.ProjectTo<DepartmentDto>(query).ToListAsync();




            var result = new PagingResult<DepartmentDto>(data, pageIndex, pageSize, sortBy, orderBy, total);

            return result;

        }

        public async Task<List<DepartmentDto>> GetAllByEmployeeAsync(string? KeyWord, int? organizationId,int employeeId)
        {

            var query = _dbContext.Departments
                           .Include(d => d.DepartmentEmployees).Where(d => d.IsDeleted != true && d.DepartmentEmployees.Any(de=>de.EmployeeId==employeeId))
                           .Include(d => d.Projects.Where(p=>p.ProjectEmployees.Any(pe => pe.EmployeeId == employeeId)))
                           .AsQueryable();

            if (!string.IsNullOrEmpty(KeyWord))
            {
                string search = KeyWord.ToLower();
                query = query.Where(b => b.Name.ToLower().Contains(KeyWord.ToLower()) || b.Description.ToLower().Contains(KeyWord.ToLower()));
            }
            if (organizationId.HasValue)
            {
                query = query.Where(b => b.OrganizationId == organizationId.Value);
            }

            return _mapper.Map<List<DepartmentDto>>(query);

        }

        public async Task<PagingResult<EmployeeDto>> PagingEmployeeNotInDepartment(string? keyWord, int? organizationId, int? leaderOrganizationId, int? positionId, WorkingStatus? workingStatus, AccountStatus? accountStatus, int? cityId, int? districtId, int? wardId, int? streetId, string? sortBy, string? orderBy,int departmentId, int pageIndex = 1, int pageSize = 10)
        {
            var employeeIds = await _dbContext.Departments
                .Where(d => d.Id == departmentId)
                .SelectMany(d => d.DepartmentEmployees)
                .Select(de => de.EmployeeId)
                .ToListAsync();


            var query = _dbContext.Employees.Where(e => e.IsDeleted == false && !employeeIds.Contains(e.Id))            
                .AsNoTracking();

            if (!string.IsNullOrEmpty(keyWord))
            {

                keyWord = keyWord.Trim(); 
                query = query.Where(c => (c.LastName.Trim() + " " + c.FirstName.Trim()).Contains(keyWord) ||
                                         (c.FirstName.Trim() + " " + c.LastName.Trim()).Contains(keyWord) ||
                                         c.PhoneNumber.Contains(keyWord));
            }


            if (organizationId.HasValue)
            {
                var organizationDescendantIds = await GetAllChildOrganizationIds(organizationId.Value);
                organizationDescendantIds.Add(organizationId.Value);
                query = query.Where(e => organizationDescendantIds.Contains(e.OrganizationId.Value));
            }
            if (accountStatus.HasValue)
            {
                query = query.Where(e => e.AccountStatus == accountStatus.Value);
            }
            if (leaderOrganizationId.HasValue)
            {
                query = query.Where(e => e.OrganizationLeaders.Where(or => or.OrganizationId == leaderOrganizationId).Any());
            }
            if (positionId.HasValue)
            {
                query = query.Where(e => e.StaffPositionId == positionId);
            }
            if (workingStatus.HasValue)
            {
                query = query.Where(e => e.WorkingStatus == workingStatus);
            }
            if (cityId.HasValue)
            {
                query = query.Where(e => e.CityId == cityId);
            }
            if (districtId.HasValue)
            {
                query = query.Where(e => e.DistrictId == districtId);
            }
            if (wardId.HasValue)
            {
                query = query.Where(e => e.WardId == wardId);
            }
            if (streetId.HasValue)
            {
                query = query.Where(e => e.StreetId == streetId);
            }
            query = query.ApplySorting(sortBy, orderBy);

            int total = await query.CountAsync();

            query = query.ApplyPaging(pageIndex, pageSize);

            var test = await query.ToListAsync();

            var data = await _mapper.ProjectTo<EmployeeDto>(query).ToListAsync();


            var result = new PagingResult<EmployeeDto>(data, pageIndex, pageSize, sortBy, orderBy, total);

            return result;
        }


        public async Task<DepartmentDto> CreateAsync(CreateDepartmentRequest request)
        {
            var department = _mapper.Map<Department>(request);

            department.DepartmentEmployees = request.EmployeeRoleMappings.Select(erm => new DepartmentEmployee
            {
                EmployeeId = erm.EmployeeId,
                DepartmentRoleId = erm.DepartmentRoleId
            }).ToList();

            var data = await base.CreateAsync(department);
            return _mapper.Map<DepartmentDto>(data);
        }


        public async Task<DepartmentDto> UpdateAsync(UpdateDepartmentRequest request)
        {
            var department = await _dbContext.Departments
                .Include(d => d.DepartmentEmployees)
                .FirstOrDefaultAsync(d => d.Id == request.Id);

            if (department == null)
            {
                throw new KeyNotFoundException($"Department with ID {request.Id} not found.");
            }

            _mapper.Map(request, department);

            department.DepartmentEmployees.Clear(); 
            department.DepartmentEmployees = request.EmployeeRoleMappings.Select(erm => new DepartmentEmployee
            {
                EmployeeId = erm.EmployeeId,
                DepartmentId = department.Id, 
                DepartmentRoleId = erm.DepartmentRoleId 
            }).ToList();

            await base.UpdateAsync(department); 
            return _mapper.Map<DepartmentDto>(department);
        }

        public async Task AddEmployeeToDepartmentAsync(int departmentId, int employeeId)
        {
            var department = await _dbContext.Departments
                .Include(d => d.DepartmentEmployees)
                .FirstOrDefaultAsync(d => d.Id == departmentId);

            if (department == null)
            {
                throw new KeyNotFoundException($"Department with ID {departmentId} not found.");
            }

            if (department.DepartmentEmployees.Any(de => de.EmployeeId == employeeId))
            {
                throw new InvalidOperationException($"Employee with ID {employeeId} is already in the department.");
            }

            department.DepartmentEmployees.Add(new DepartmentEmployee
            {
                EmployeeId = employeeId,
                DepartmentId = departmentId
            });

            await UpdateAsync(department);
        }

        public async Task RemoveEmployeeFromDepartmentAsync(int departmentId, int employeeId)
        {
            var department = await _dbContext.Departments
                .Include(d => d.DepartmentEmployees)
                .FirstOrDefaultAsync(d => d.Id == departmentId);

            if (department == null)
            {
                throw new KeyNotFoundException($"Department with ID {departmentId} not found.");
            }

            var departmentEmployee = department.DepartmentEmployees.FirstOrDefault(de => de.EmployeeId == employeeId);
            if (departmentEmployee == null)
            {
                throw new KeyNotFoundException($"Employee with ID {employeeId} is not in the department.");
            }

            department.DepartmentEmployees.Remove(departmentEmployee);
            await UpdateAsync(department);
        }

        public async Task UpdateDepartmentBasicInfoAsync(UpdateDepartmentBasicInfoRequest request)
        {
            var department = await _dbContext.Departments.FindAsync(request.Id);
            if (department == null)
            {
                throw new KeyNotFoundException($"Department with ID {request.Id} not found.");
            }

            department.Name = request.Name;
            department.Description = request.Description;

            await UpdateAsync(department);
        }


        public async Task UpdateEmployeeRoleAsync(UpdateEmployeeRoleFromDepartment request)
        {
            var departmentEmployee = await _dbContext.DepartmentEmployees
                .FirstOrDefaultAsync(de => de.EmployeeId == request.EmployeeId && de.DepartmentId == request.DepartmentId);

            if (departmentEmployee == null)
            {
                throw new KeyNotFoundException($"Employee with ID {request.EmployeeId} is not in the department with ID {request.DepartmentId}.");
            }

            departmentEmployee.DepartmentRoleId = request.DepartmentRoleId;
            _dbContext.DepartmentEmployees.Update(departmentEmployee);
            await _dbContext.SaveChangesAsync();
        }






        public async Task DeleteSoftAsync(int id)
        {
            var department = await _dbContext.Departments.FindAsync(id);
            if (department == null)
            {
                throw new KeyNotFoundException($"Department with ID {id} not found.");
            }
            department.IsDeleted = true;
            await base.UpdateAsync(department);

        }



        public async Task<List<int>> GetAllChildOrganizationIds(int parentId)
        {
            var allOrganizations = await _dbContext.Organizations.AsNoTracking().ToListAsync();

            var result = new List<int>();
            GetChildIdsRecursive(parentId, allOrganizations, result);
            return result;
        }

        private void GetChildIdsRecursive(int parentId, List<Organization> allOrganizations, List<int> result)
        {
            var children = allOrganizations.Where(o => o.OrganizatioParentId == parentId).ToList();

            foreach (var child in children)
            {
                result.Add(child.Id); 
                GetChildIdsRecursive(child.Id, allOrganizations, result); 
            }
        }
    }
}
