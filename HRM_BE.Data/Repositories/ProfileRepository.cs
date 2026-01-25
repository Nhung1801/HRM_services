using AutoMapper;
using HRM_BE.Core.Data.Company;
using HRM_BE.Core.Data.Staff;
using HRM_BE.Core.Extension;
using HRM_BE.Core.IRepositories;
using HRM_BE.Core.Models.Common;
using HRM_BE.Core.Models.Profile;
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
    public class ProfileRepository : RepositoryBase<Employee, int>, IProfileRepository
    {
        public IMapper _mapper;

        public ProfileRepository(HrmContext context, IMapper mapper, IHttpContextAccessor httpContextAccessor) : base(context, httpContextAccessor)
        {
            _mapper = mapper;
        }

        public async Task<PagingResult<EmployeeDto>> Paging(WorkingStatus? workingStatus, int? employeeId, int? organizationId, string? sortBy, string? orderBy, int pageIndex = 1, int pageSize = 10)
        {
            var query = _dbContext.Employees.AsQueryable();

            // Lọc theo trạng thái lao động
            if (workingStatus.HasValue)
            {
                query = query.Where(e => e.WorkingStatus == workingStatus.Value);
            }

            // Tìm kiếm theo tên nhân viên
            //if (!string.IsNullOrEmpty(nameEmployee))
            //{
            //    string normalizedSearchTerm = nameEmployee.ToLower().Trim();
            //    query = query.Where(e => EF.Functions.Like(
            //        (e.LastName + " " + e.FirstName).ToLower().Trim(),
            //        "%" + normalizedSearchTerm + "%"
            //    ));
            //}

            // Lọc theo employeeId
            if (employeeId.HasValue)
            {
                query = query.Where(e => e.Id == employeeId.Value);
            }    

            // Lọc theo đơn vị
            if (organizationId.HasValue)
            {
                query = query.Where(e => e.OrganizationLeaders.Where(or => or.OrganizationId == organizationId).Any());
            }

            // Áp dụng sắp xếp
            query = query.ApplySorting(sortBy, orderBy);

            // Tính tổng số bản ghi
            int totalRecords = await query.CountAsync();

            // Áp dụng phân trang
            query = query.ApplyPaging(pageIndex, pageSize);

            // Lấy dữ liệu và chuyển sang DTO
            var data = await query.Select(p => new EmployeeDto
            {
                Id = p.Id,
                EmployeeCode = p.EmployeeCode,
                FirstName = p.FirstName,
                LastName = p.LastName,
                Sex = p.Sex,
                DateOfBirth = p.DateOfBirth,
                PhoneNumber = p.PhoneNumber,
                CompanyEmail = p.CompanyEmail,
                WorkingStatus = p.WorkingStatus,
                AvatarUrl = p.AvatarUrl,
                StaffTitle = p.StaffTitle != null
            ? new StaffTitleDto { StaffTitleName = p.StaffTitle.StaffTitleName }
            : null,
                StaffPosition = p.StaffPosition != null
            ? new StaffPositionDto { PositionName = p.StaffPosition.PositionName }
            : null, 
                CompanyId = p.CompanyId,
                //CompanyFullName = p.Company != null ? p.Company.FullName : null,
                OrganizationLeaders = p.OrganizationLeaders
        .Select(o => new GetEmployeeOrganizationDto
        {
            OrganizationId = o.OrganizationId,
            OrganizationName = o.Organization.OrganizationName 
        }).ToList()

            }).ToListAsync();   


            // Kết quả phân trang
            var result = new PagingResult<EmployeeDto>(data, pageIndex, pageSize, sortBy, orderBy, totalRecords);

            return result;
        }

        public async Task<List<EmployeeDto>> GetAll(WorkingStatus? workingStatus, int? employeeId, int? companyId, string? sortBy, string? orderBy)
        {
            try
            {
                var query = _dbContext.Employees.AsQueryable();

                // Lọc theo trạng thái lao động
                if (workingStatus.HasValue)
                {
                    query = query.Where(e => e.WorkingStatus == workingStatus.Value);
                }

                // Lọc theo employeeId
                if (employeeId.HasValue)
                {
                    query = query.Where(e => e.Id == employeeId.Value);
                }

                // Lọc theo companyId
                if (companyId.HasValue)
                {
                    query = query.Where(e => e.CompanyId == companyId.Value);
                }

                // Áp dụng sắp xếp
                query = query.ApplySorting(sortBy, orderBy);

                // Lấy dữ liệu và chuyển sang DTO
                var data = await query.Select(p => new EmployeeDto
                {
                    Id = p.Id,
                    EmployeeCode = p.EmployeeCode,
                    FirstName = p.FirstName,
                    LastName = p.LastName,
                    Sex = p.Sex,
                    DateOfBirth = p.DateOfBirth,
                    PhoneNumber = p.PhoneNumber,
                    CompanyEmail = p.CompanyEmail,
                    WorkingStatus = p.WorkingStatus,
                    AvatarUrl = p.AvatarUrl,
                    StaffTitle = p.StaffTitle != null
                        ? new StaffTitleDto { StaffTitleName = p.StaffTitle.StaffTitleName }
                        : null,
                    StaffPosition = p.StaffPosition != null
                        ? new StaffPositionDto { PositionName = p.StaffPosition.PositionName }
                        : null,
                    CompanyId = p.CompanyId,
                    //CompanyFullName = p.Company != null ? p.Company.FullName : null,
                    Organization = p.Organization != null
                        ? new GetOrganizationForEmployeeDto
                        {
                            Id = p.Organization.Id,
                            OrganizationName = p.Organization.OrganizationName
                        }
                        : null,
                    OrganizationLeaders = p.OrganizationLeaders
                        .Select(o => new GetEmployeeOrganizationDto
                        {
                            OrganizationId = o.OrganizationId,
                            OrganizationName = o.Organization.OrganizationName
                        }).ToList()

                }).ToListAsync();

                return data;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
