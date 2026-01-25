using AutoMapper;
using HRM_BE.Core.Constants.System;
using HRM_BE.Core.Data.Company;
using HRM_BE.Core.Data.Staff;
using HRM_BE.Core.Data.Task;
using HRM_BE.Core.Extension;
using HRM_BE.Core.IRepositories;
using HRM_BE.Core.Models.Common;
using HRM_BE.Core.Models.Department;
using HRM_BE.Core.Models.Project;
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
    public class ProjectRepository : RepositoryBase<Project, int>, IProjectRepository
    {
        private readonly IMapper _mapper;
        public ProjectRepository(HrmContext context, IMapper mapper, IHttpContextAccessor httpContextAccessor) : base(context, httpContextAccessor)
        {
            _mapper = mapper;
        }


        public async Task<List<ProjectRoleDto>> GetRoles()
        {
            var query = _dbContext.ProjectRoles.AsQueryable();
            var data = await _mapper.ProjectTo<ProjectRoleDto>(query).ToListAsync();
            return data;
        }

        //public async Task<ProjectDto> GetByIdAsync(int id)
        //{
        //    var Project = await _dbContext.Projects
        //        .Include(d => d.ProjectEmployees)
        //        .FirstOrDefaultAsync(d => d.Id == id && d.IsDeleted != true);

        //    if (Project == null)
        //    {
        //        throw new KeyNotFoundException($"Project with ID {id} not found.");
        //    }

        //    return _mapper.Map<ProjectDto>(Project);
        //}

        public async Task<ProjectDto> GetByIdAsync(int id)
        {
            var project =  await _dbContext.Projects
                .Include(p => p.ProjectEmployees)
                    .ThenInclude(pe => pe.Employee)
                .Include(p => p.Department)
                .FirstOrDefaultAsync(p => p.Id == id && p.IsDeleted != true);

            if (project == null)
            {
                throw new KeyNotFoundException($"Project with ID {id} not found.");
            }

            var response = _mapper.Map<ProjectDto>(project);
            response.Department = project.Department != null
                ? _mapper.Map<DepartmentDto>(project.Department)
                : null;

            response.Employees = project.ProjectEmployees
                .Select(pe => _mapper.Map<EmployeeDto>(pe.Employee))
                .ToList();

            return response;
        }

        public async Task<List<ProjectDto>> GetAllAsync(string? KeyWord)
        {

            var query = _dbContext.Projects
                           .Include(d => d.ProjectEmployees).Where(d => d.IsDeleted != true)
                           .AsQueryable();

            if (!string.IsNullOrEmpty(KeyWord))
            {
                string search = KeyWord.ToLower();
                query = query.Where(b => b.Name.ToLower().Contains(KeyWord.ToLower()) || b.Description.ToLower().Contains(KeyWord.ToLower()));
            }


            return _mapper.Map<List<ProjectDto>>(query);

        }

        public async Task<PagingResult<ProjectDto>> GetPagingAsync(string? KeyWord, string? sortBy, string? orderBy, int pageIndex = 1, int pageSize = 10)
        {

            var query = _dbContext.Projects
                                       .Include(d => d.ProjectEmployees).Where(d => d.IsDeleted != true)
                                       .AsQueryable();
            if (!string.IsNullOrEmpty(KeyWord))
            {
                string search = KeyWord.ToLower();
                query = query.Where(b => b.Name.ToLower().Contains(KeyWord.ToLower()) || b.Description.ToLower().Contains(KeyWord.ToLower()));
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


            var data = await _mapper.ProjectTo<ProjectDto>(query).ToListAsync();




            var result = new PagingResult<ProjectDto>(data, pageIndex, pageSize, sortBy, orderBy, total);

            return result;

        }

        public async Task<List<ProjectDto>> GetAllByEmployeeAsync(string? KeyWord,int employeeId)
        {

            var query = _dbContext.Projects
                           .Include(d => d.ProjectEmployees).Where(d => d.IsDeleted != true && d.ProjectEmployees.Any(pe=>pe.EmployeeId==employeeId))
                           .AsQueryable();

            if (!string.IsNullOrEmpty(KeyWord))
            {
                string search = KeyWord.ToLower();
                query = query.Where(b => b.Name.ToLower().Contains(KeyWord.ToLower()) || b.Description.ToLower().Contains(KeyWord.ToLower()));
            }


            return _mapper.Map<List<ProjectDto>>(query);

        }
        public async  Task<PagingResult<ProjectDto>> GetPagingByEmployeeAsync(string? KeyWord, int employeeId, string? sortBy, string? orderBy, int pageIndex = 1, int pageSize = 10)
        {
            var query = _dbContext.Projects
                          .Include(d => d.ProjectEmployees).Where(d => d.IsDeleted != true && d.ProjectEmployees.Any(pe => pe.EmployeeId == employeeId))
                          .AsQueryable();

            if (!string.IsNullOrEmpty(KeyWord))
            {
                string search = KeyWord.ToLower();
                query = query.Where(b => b.Name.ToLower().Contains(KeyWord.ToLower()) || b.Description.ToLower().Contains(KeyWord.ToLower()));
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


            var data = await _mapper.ProjectTo<ProjectDto>(query).ToListAsync();




            var result = new PagingResult<ProjectDto>(data, pageIndex, pageSize, sortBy, orderBy, total);

            return result;
        }


        public async Task<PagingResult<EmployeeDto>> PagingEmployeeNotInProject(string? keyWord, int? organizationId, int? leaderOrganizationId, int? positionId, WorkingStatus? workingStatus, AccountStatus? accountStatus, int? cityId, int? districtId, int? wardId, int? streetId, string? sortBy, string? orderBy, int projectId, int pageIndex = 1, int pageSize = 10)
        {
            var employeeIds = await _dbContext.Projects
                .Where(d => d.Id == projectId)
                .SelectMany(d => d.ProjectEmployees)
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



        public async Task<ProjectDto> CreateAsync(CreateProjectRequest request)
        {
            var project = _mapper.Map<Project>(request);

            project.ProjectEmployees = request.ProjectEmployeeRoleMappings.Select(erm => new ProjectEmployee
            {
                EmployeeId = erm.EmployeeId,
                ProjectRoleId = erm.ProjectRoleId
            }).ToList();
            if (project.DepartmentId == null)
            {
                project.ProjectType = ProjectType.Out;
            }
            else {
                project.ProjectType = ProjectType.In;
            }
            var data = await base.CreateAsync(project);
            return _mapper.Map<ProjectDto>(data);
        }


        public async Task<ProjectDto> UpdateAsync(UpdateProjectRequest request)
        {
            var project = await _dbContext.Projects
                .Include(p => p.ProjectEmployees)
                .FirstOrDefaultAsync(p => p.Id == request.Id);

            if (project == null)
            {
                throw new KeyNotFoundException($"Project with ID {request.Id} not found.");
            }

            _mapper.Map(request, project);

            if (project.DepartmentId == null)
            {
                project.ProjectType = ProjectType.Out;
            }
            else
            {
                project.ProjectType = ProjectType.In;
            }
            project.ProjectEmployees.Clear(); 
            project.ProjectEmployees = request.ProjectEmployeeRoleMappings.Select(erm => new ProjectEmployee
            {
                EmployeeId = erm.EmployeeId,
                ProjectId = project.Id,
                ProjectRoleId = erm.ProjectRoleId  
            }).ToList();

            await base.UpdateAsync(project);
            return _mapper.Map<ProjectDto>(project);
        }


        public async Task AddEmployeeToProjectAsync(int projectId, int employeeId)
        {
            var project = await _dbContext.Projects
                .Include(p => p.ProjectEmployees)
                .FirstOrDefaultAsync(p => p.Id == projectId);

            if (project == null)
            {
                throw new KeyNotFoundException($"Project with ID {projectId} not found.");
            }

            if (project.ProjectEmployees.Any(pe => pe.EmployeeId == employeeId))
            {
                throw new InvalidOperationException($"Employee with ID {employeeId} is already in the project.");
            }

            project.ProjectEmployees.Add(new ProjectEmployee
            {
                EmployeeId = employeeId,
                ProjectId = projectId
            });

            await UpdateAsync(project);
        }

        public async Task RemoveEmployeeFromProjectAsync(int projectId, int employeeId)
        {
            var project = await _dbContext.Projects
                .Include(p => p.ProjectEmployees)
                .FirstOrDefaultAsync(p => p.Id == projectId);

            if (project == null)
            {
                throw new KeyNotFoundException($"Project with ID {projectId} not found.");
            }

            var projectEmployee = project.ProjectEmployees.FirstOrDefault(pe => pe.EmployeeId == employeeId);
            if (projectEmployee == null)
            {
                throw new KeyNotFoundException($"Employee with ID {employeeId} is not in the project.");
            }

            project.ProjectEmployees.Remove(projectEmployee);
            await UpdateAsync(project);
        }

        public async Task UpdateProjectBasicInfoAsync(UpdateProjectBasicInfoRequest request)
        {
            var project = await _dbContext.Projects.FindAsync(request.Id);
            if (project == null)
            {
                throw new KeyNotFoundException($"Project with ID {request.Id} not found.");
            }

            project.Name = request.Name;
            project.Description = request.Description;
            project.StartDate = request.StartDate;
            project.EndDate = request.EndDate;

            await UpdateAsync(project);

        }

        public async Task UpdateEmployeeRoleAsync(UpdateEmployeeRoleFromProject request)
        {
            var departmentEmployee = await _dbContext.ProjectEmployees
                .FirstOrDefaultAsync(de => de.EmployeeId == request.EmployeeId && de.ProjectId == request.ProjectId);

            if (departmentEmployee == null)
            {
                throw new KeyNotFoundException($"Employee with ID {request.EmployeeId} is not in the department with ID {request.ProjectId}.");
            }

            departmentEmployee.ProjectRoleId = request.ProjectRoleId;
            _dbContext.ProjectEmployees.Update(departmentEmployee);
            await _dbContext.SaveChangesAsync();
        }




        public async Task DeleteSoftAsync(int id)
        {
            var Project = await _dbContext.Projects.FindAsync(id);
            if (Project == null)
            {
                throw new KeyNotFoundException($"Project with ID {id} not found.");
            }
            Project.IsDeleted = true;
            await base.UpdateAsync(Project);

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
