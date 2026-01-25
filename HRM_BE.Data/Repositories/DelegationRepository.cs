using AutoMapper;
using HRM_BE.Core.Data.Content;
using HRM_BE.Core.Data.Task;
using HRM_BE.Core.IRepositories;
using HRM_BE.Core.Models.Delegation;
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
    public class DelegationRepository : RepositoryBase<Delegation, int>, IDelegationRepository
    {
        private readonly IMapper _mapper;
        public DelegationRepository(HrmContext context, IMapper mapper, IHttpContextAccessor httpContextAccessor) : base(context, httpContextAccessor)
        {
            _mapper = mapper;
        }



        public async Task<DelegationDto> CreateAsync(CreateDelegationRequest request)
        {
            var delegation = _mapper.Map<Delegation>(request);

            // Gắn danh sách nhân viên nhận ủy quyền
            delegation.DelegationEmployees = request.EmployeeIds.Select(eId => new DelegationEmployee
            {
                EmployeeId = eId,
                DelegationId = delegation.Id
            }).ToList();

            // Gắn danh sách dự án ủy quyền
            delegation.DelegationProjects = request.ProjectIds.Select(pId => new DelegationProject
            {
                ProjectId = pId,
                DelegationId = delegation.Id
            }).ToList();

            await base.CreateAsync(delegation);

            return _mapper.Map<DelegationDto>(delegation);
        }

        public async Task<DelegationDto> UpdateAsync(UpdateDelegationRequest request)
        {
            var delegation = await _dbContext.Delegations
                .Include(d => d.DelegationEmployees)
                .Include(d => d.DelegationProjects)
                .FirstOrDefaultAsync(d => d.Id == request.Id);

            if (delegation == null)
            {
                throw new KeyNotFoundException($"Delegation with ID {request.Id} not found.");
            }

            _mapper.Map(request, delegation);

            // Cập nhật danh sách nhân viên nhận ủy quyền
            delegation.DelegationEmployees.Clear();
            delegation.DelegationEmployees = request.EmployeeIds.Select(eId => new DelegationEmployee
            {
                EmployeeId = eId,
                DelegationId = delegation.Id
            }).ToList();

            // Cập nhật danh sách dự án ủy quyền
            delegation.DelegationProjects.Clear();
            delegation.DelegationProjects = request.ProjectIds.Select(pId => new DelegationProject
            {
                ProjectId = pId,
                DelegationId = delegation.Id
            }).ToList();

            await base.UpdateAsync(delegation);
            return _mapper.Map<DelegationDto>(delegation);
        }

        public async Task DeleteSoftAsync(int id)
        {
            var delegation = await _dbContext.Delegations.FindAsync(id);
            if (delegation == null)
            {
                throw new KeyNotFoundException($"Delegation with ID {id} not found.");
            }
            delegation.IsDeleted = true;
            await base.UpdateAsync(delegation);

        }

        public async Task<DelegationDto> GetByIdAsync(int id)
        {
            var delegation = await _dbContext.Delegations
                .Include(d => d.EmployeeDelegation)
                .Include(d => d.DelegationEmployees)
                    .ThenInclude(de => de.Employee)
                .Include(d => d.DelegationProjects)
                    .ThenInclude(dp => dp.Project)
                .FirstOrDefaultAsync(d => d.Id == id);

            if (delegation == null)
            {
                throw new KeyNotFoundException($"Delegation with ID {id} not found.");
            }

            var response = _mapper.Map<DelegationDto>(delegation);
            response.EmployeeDelegation = delegation.EmployeeDelegation != null
                ? _mapper.Map<EmployeeDelegationDto>(delegation.EmployeeDelegation)
                : null;

            response.Employees = delegation.DelegationEmployees
                .Select(de => _mapper.Map<EmployeeDelegationDto>(de.Employee))
                .ToList();

            response.Projects = delegation.DelegationProjects
                .Select(dp => _mapper.Map<ProjectDto>(dp.Project))
                .ToList();

            return response;
        }

        public async Task<List<DelegationDto>> GetAllAsync()
        {
            var delegations = await _dbContext.Delegations
                .Include(d => d.EmployeeDelegation)
                .Include(d => d.DelegationEmployees)
                .Include(d => d.DelegationProjects)
                .ToListAsync();

            return _mapper.Map<List<DelegationDto>>(delegations);
        }

        public async Task<List<DelegationDto>> GetAllByEmployeeDelegationAsync(int employeeDelegationId)
        {
            var delegations = await _dbContext.Delegations
                .Include(d => d.EmployeeDelegation)
                .Include(d => d.DelegationEmployees)
                            .ThenInclude(de => de.Employee)
                .Include(d => d.DelegationProjects)
                            .ThenInclude(dp => dp.Project)
                .Where(d => d.EmployeeDelegationId == employeeDelegationId)
                .ToListAsync();

            return _mapper.Map<List<DelegationDto>>(delegations);
        }

    }
}
