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

        public async Task<PagingResult<EmployeeDto>> Paging(WorkingStatus? workingStatus, int? employeeId, int? organizationId, string? keyWord, string? sortBy, string? orderBy, int pageIndex = 1, int pageSize = 10)
        {
            var query = _dbContext.Employees.Where(e => e.IsDeleted == false).AsQueryable();

            // Lọc theo trạng thái lao động
            if (workingStatus.HasValue)
            {
                query = query.Where(e => e.WorkingStatus == workingStatus.Value);
            }

            // Tìm kiếm theo keyword (tên, số điện thoại, mã nhân viên)
            if (!string.IsNullOrEmpty(keyWord))
            {
                keyWord = keyWord.Trim();
                
                // Tách từ khóa thành các từ riêng biệt và loại bỏ khoảng trắng thừa
                var searchTerms = keyWord.Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)
                    .Select(term => term.Trim())
                    .Where(term => !string.IsNullOrEmpty(term))
                    .ToList();

                if (searchTerms.Any())
                {
                    // Tạo điều kiện tìm kiếm: (tên chứa tất cả các từ) OR (số điện thoại chứa toàn bộ từ khóa) OR (mã nhân viên chứa toàn bộ từ khóa)
                    var firstTerm = searchTerms[0];
                    query = query.Where(e =>
                        ((e.LastName ?? "").Trim() + " " + (e.FirstName ?? "").Trim()).Contains(firstTerm) ||
                        ((e.FirstName ?? "").Trim() + " " + (e.LastName ?? "").Trim()).Contains(firstTerm) ||
                        (!string.IsNullOrEmpty(e.PhoneNumber) && e.PhoneNumber.Contains(keyWord)) ||
                        (!string.IsNullOrEmpty(e.EmployeeCode) && e.EmployeeCode.Contains(keyWord)));
                    
                    // Áp dụng điều kiện cho các từ còn lại (chỉ kiểm tra tên)
                    for (int i = 1; i < searchTerms.Count; i++)
                    {
                        var term = searchTerms[i];
                        query = query.Where(e =>
                            ((e.LastName ?? "").Trim() + " " + (e.FirstName ?? "").Trim()).Contains(term) ||
                            ((e.FirstName ?? "").Trim() + " " + (e.LastName ?? "").Trim()).Contains(term) ||
                            (!string.IsNullOrEmpty(e.PhoneNumber) && e.PhoneNumber.Contains(keyWord)) ||
                            (!string.IsNullOrEmpty(e.EmployeeCode) && e.EmployeeCode.Contains(keyWord)));
                    }
                }
            }

            // Lọc theo employeeId
            if (employeeId.HasValue)
            {
                query = query.Where(e => e.Id == employeeId.Value);
            }    

            // Lọc theo đơn vị (bao gồm cả các đơn vị con)
            if (organizationId.HasValue)
            {
                var organizationDescendantIds = await GetAllChildOrganizationIds(organizationId.Value);
                organizationDescendantIds.Add(organizationId.Value);
                query = query.Where(e => e.OrganizationLeaders.Where(or => organizationDescendantIds.Contains(or.OrganizationId)).Any());
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

        public async Task<List<EmployeeDto>> GetAll(WorkingStatus? workingStatus, int? employeeId, int? organizationId, string? sortBy, string? orderBy)
        {
            try
            {
                var query = _dbContext.Employees.Where(e => e.IsDeleted == false).AsQueryable();

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

                // Lọc theo đơn vị (bao gồm cả các đơn vị con)
                if (organizationId.HasValue)
                {
                    var organizationDescendantIds = await GetAllChildOrganizationIds(organizationId.Value);
                    organizationDescendantIds.Add(organizationId.Value);
                    query = query.Where(e => e.OrganizationLeaders.Where(or => organizationDescendantIds.Contains(or.OrganizationId)).Any());
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

        public async Task<List<int>> GetAllChildOrganizationIds(int parentId)
        {
            // Lấy tất cả các tổ chức
            var allOrganizations = await _dbContext.Organizations.AsNoTracking().ToListAsync();

            // Gọi hàm đệ quy để tìm tất cả các Id con
            var result = new List<int>();
            GetChildIdsRecursive(parentId, allOrganizations, result);
            return result;
        }

        private void GetChildIdsRecursive(int parentId, List<Organization> allOrganizations, List<int> result)
        {
            // Lấy tất cả các con trực tiếp của parentId
            var children = allOrganizations.Where(o => o.OrganizatioParentId == parentId).ToList();

            foreach (var child in children)
            {
                result.Add(child.Id); // Thêm Id của con vào danh sách kết quả
                GetChildIdsRecursive(child.Id, allOrganizations, result); // Gọi đệ quy cho các con
            }
        }
    }
}
