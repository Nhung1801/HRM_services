using AutoMapper;
using Azure.Core;
using HRM_BE.Core.Data.Company;
using HRM_BE.Core.Exceptions;
using HRM_BE.Core.Extension;
using HRM_BE.Core.IRepositories;
using HRM_BE.Core.Models.Common;
using HRM_BE.Core.Models.Company;
using HRM_BE.Core.Models.Organization;
using HRM_BE.Data.SeedWorks;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Linq;
using System.Net.WebSockets;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace HRM_BE.Data.Repositories
{
    public class OrganizationRepository : RepositoryBase<Organization, int>, IOrganizationRepository
    {
        private readonly IMapper _mapper;
        public OrganizationRepository(HrmContext context, IMapper mapper, IHttpContextAccessor httpContextAccessor) : base(context, httpContextAccessor)
        {
            _mapper = mapper;
        }
        public async Task<OrganizationDto> Create(CreateOrganizationRequest request)
        {
            var entity = _mapper.Map<Organization>(request);
            var organizationCreated = await CreateAsync(entity);
            var orgnizationId = organizationCreated.Id;
            foreach (var item in request.OrganizationLeaders)
            {
                var orginiazationLeaderEnity = new OrganizationLeader
                {
                    OrganizationLeaderType = OrganizationLeaderType.Leader,
                    EmployeeId = item.EmployeeId,
                    OrganizationId = orgnizationId
                };
                await _dbContext.OrganizationLeaders.AddAsync(orginiazationLeaderEnity);
                await SaveChangesAsync();
            }

            return _mapper.Map<OrganizationDto>(entity);
        }

        public async Task Delete(int id)
        {
            var entity = await GetOrganizationAndCheckExist(id);
            entity.IsDeleted = true;
            await UpdateAsync(entity);
        }
        public async Task<OrganizationDto> GetById(int id)
        {
            var entity = await GetOrganizationAndCheckExist(id);

            var entity2 = await _dbContext.Organizations.AsNoTracking()
               .Include( o => o.OrganizationChildren).ThenInclude( o => o.OrganizationChildren)
               .Include(o => o.OrganizationType)    
               .Include(o => o.OrganizationLeaders)
               .ThenInclude(ol => ol.Employee)
               .FirstOrDefaultAsync(o => o.Id == id);
            var entityReturn = _mapper.Map<OrganizationDto>(entity2);

            //var childrend = await this.GetAllChildrenAsync(id);
            //entityReturn.OrganizationChildren =_mapper.Map<List<OrganizationDto>>(childrend);
            return entityReturn;
        }

        // 
        // Hàm lấy tất cả các tổ chức con
        //private async Task<List<TDto>> GetAllChildrenAsync<TDto>(int organizationId) where TDto : class
        //{

        //    var organization = await _dbContext.Organizations.AsNoTracking()
        //        .FirstOrDefaultAsync(o => o.Id == organizationId);
        //    var organizationDto = _mapper.Map<Getgo>
        //    if (organization != null)
        //    {
        //        // Gọi đệ quy để lấy các tổ chức con, bắt đầu từ tổ chức gốc
        //        await GetAllChildrenRecursiveAsync(organization.Id, organization);
        //    }
        //    var result = _mapper.Map<List<TDto>>(organization.OrganizationChildren);
        //    //// Cập nhật số lượng nhân viên cho từng tổ chức con và tất cả các cấp độ
        //    //foreach (var orgDto in result)
        //    //{
        //    //    // Dùng reflection để kiểm tra và gán giá trị cho thuộc tính TotalEmployees
        //    //    var totalEmployeesProperty = typeof(TDto).GetProperty("TotalEmployees");

        //    //    if (totalEmployeesProperty != null && totalEmployeesProperty.CanWrite)
        //    //    {
        //    //        // Đếm số lượng nhân viên trong tổ chức và tất cả các tổ chức con
        //    //        int totalEmployees = await CountEmployeesIncludingChildren(organizationId);

        //    //        // Gán số lượng nhân viên vào thuộc tính TotalEmployees của DTO
        //    //        totalEmployeesProperty.SetValue(orgDto, totalEmployees);
        //    //    }
        //    //}
        //    return result;
        //} 
        private async Task<List<GetOrganizationDto>> GetAllChildrenAsync(int organizationId) 
        {

            var organization = await _dbContext.Organizations.AsNoTracking()
                .FirstOrDefaultAsync(o => o.Id == organizationId);
            var organizationDto = _mapper.Map<GetOrganizationDto>(organization);

            if (organization != null)
            {
                // Gọi đệ quy để lấy các tổ chức con, bắt đầu từ tổ chức gốc
                await GetAllChildrenRecursiveAsync(organization.Id, organizationDto);
            }
            var result = _mapper.Map<List<GetOrganizationDto>>(organizationDto.OrganizationChildren);



            return result;
        }


        // Hàm đệ quy để đếm số lượng nhân viên cho tổ chức và tất cả các tổ chức con
        private async Task<int> CountEmployeesIncludingChildren(List<int> allMeAndDescendantIds)
        {
            // Đếm số lượng nhân viên trong tổ chức hiện tại và tất cả các tổ chức con
            var totalEmployees = await _dbContext.OrganizationLeaders
                .Where(ol => allMeAndDescendantIds.Contains(ol.OrganizationId))
                .CountAsync();

            return totalEmployees;
        }

        private async Task<List<int>> GetAllOrganizationIds(int organizationId)
        {
            var allIds = new List<int> { organizationId };

            // Lấy tất cả các tổ chức con trực tiếp của tổ chức hiện tại
            var children = await _dbContext.Organizations
                .Where(o => o.OrganizatioParentId == organizationId)
                .Select(o => o.Id)
                .ToListAsync();

            foreach (var childId in children)
            {
                // Đệ quy lấy tất cả ID của tổ chức con
                var childIds = await GetAllOrganizationIds(childId);
                allIds.AddRange(childIds);
            }

            return allIds;
        }

        private async Task AssignTotalEmployeesToOrganizationDtos(List<GetOrganizationDto> organizationDtos)
        {
            foreach (var orgDto in organizationDtos)
            {
                // Lấy tất cả các ID của tổ chức hiện tại và tổ chức con của nó
                var allOrganizationIds = await GetAllOrganizationIds(orgDto.Id);

                // Đếm số lượng nhân viên trong tổ chức và tất cả các tổ chức con
                var totalEmployees = await CountEmployeesIncludingChildren(allOrganizationIds);

                // Gán số lượng nhân viên vào thuộc tính TotalEmployees của DTO
                orgDto.TotalEmployees = totalEmployees;

                // Lặp qua các tổ chức con của tổ chức hiện tại và đệ quy gán số lượng nhân viên cho tổ chức con
                if (orgDto.OrganizationChildren != null && orgDto.OrganizationChildren.Any())
                {
                    await AssignTotalEmployeesToOrganizationDtos(orgDto.OrganizationChildren);
                }
            }
        }


        // Hàm đệ quy lấy tất cả các tổ chức con của một tổ chức cha
        private async Task GetAllChildrenRecursiveAsync(int parentId, GetOrganizationDto parentOrganization)
        {
            // Lấy các tổ chức con trực tiếp của tổ chức có parentId
            var children = await _dbContext.Organizations.AsNoTracking()
                                           .Where(o => o.OrganizatioParentId == parentId)
                                           .Include(o => o.Employees)
                                           .Include(o => o.OrganizationLeaders)
                                           .ThenInclude(ol => ol.Employee)
                                           .Include(o=> o.OrganizationType)
                                           .OrderBy(o => o.Rank)
                                           .OrderByDescending(o => o.Rank)
                                           .ToListAsync();
            var childrenDto = _mapper.Map<List<GetOrganizationDto>>(children);
            //var oranization = await _dbContext.Organizations.FirstOrDefaultAsync(o => o.Id == parentId);
            // Nếu có tổ chức con, thêm vào danh sách OrganizationChildrens

            if (childrenDto.Any())
            {
                parentOrganization.OrganizationChildren = childrenDto;
                // Đệ quy vào từng tổ chức con để lấy các tổ chức con sâu hơn
                foreach (var child in childrenDto)
                {
                    if (child.Id == parentId) throw new BadHttpRequestException("Lỗi Id = ParentId");
                    await GetAllChildrenRecursiveAsync(child.Id, child);
                }
            }

        }

        //private Task<int> 

        public async Task Update(int id, UpdateOrganizationRequest request)
        {
            var organization = await _dbContext.Organizations
                   .Include(o => o.OrganizationLeaders)  // Bao gồm OrganizationLeaders để dễ dàng cập nhật
                   .FirstOrDefaultAsync(o => o.Id == id);

            await UpdateAsync(_mapper.Map(request, organization));
           
            if (organization == null)
            {
                throw new EntityNotFoundException(nameof(Organization), $"Id = {id}");
            }

            // Xử lý OrganizationLeaders (thêm, xóa hoặc cập nhật)
            // Xóa các OrganizationLeaders cũ nếu cần (tùy vào yêu cầu của bạn)
            var currentOrganizationLeaders = organization.OrganizationLeaders;

            // Tạo danh sách OrganizationLeaders mới từ yêu cầu
            var newOrganizationLeaders = request.OrganizationLeaders;

            // Tạo một danh sách các OrganizationLeaders cần xóa (các leaders đã bị xóa trong request)
            var leadersToRemove = currentOrganizationLeaders
                .Where(existing => !newOrganizationLeaders.Any(item => item.EmployeeId == existing.EmployeeId))
                .ToList();

            // Tạo một danh sách các OrganizationLeaders cần thêm (các leaders mới trong request)
            var leadersToAdd = newOrganizationLeaders
                .Where(newItem => !currentOrganizationLeaders.Any(existing => existing.EmployeeId == newItem.EmployeeId))
                .ToList();

            // Xóa các OrganizationLeaders không còn trong request
            _dbContext.OrganizationLeaders.RemoveRange(leadersToRemove);

            // Thêm các OrganizationLeaders mới
            foreach (var item in leadersToAdd)
            {
                var newOrganizationLeader = new OrganizationLeader
                {
                    OrganizationLeaderType = OrganizationLeaderType.Leader,
                    EmployeeId = item.EmployeeId,
                    OrganizationId = organization.Id
                };
                await _dbContext.OrganizationLeaders.AddAsync(newOrganizationLeader);
            }

            // Lưu các thay đổi vào cơ sở dữ liệu
            await _dbContext.SaveChangesAsync();

        }
        private async Task<Organization> GetOrganizationAndCheckExist(int organizationId)
        {
            var organization = await _dbContext.Organizations.FindAsync(organizationId);
            if (organization is null)
                throw new EntityNotFoundException(nameof(Organization), $"Id = {organizationId}");
            return organization;
        }

        public async Task<OrganizationSelectDto> GetSelect(int organizationId)
        {

            //var organizationTEst = await _dbContext.Organizations
            //.Include(o => o.OrganizationType)
            //.Include(o => o.OrganizatioParent) // Lọc trong Include
            //.Where(o => o.CompanyId == companyId)
            //.OrderByDescending(o => o.Rank)
            //.FirstOrDefaultAsync();
            var organization = await _dbContext.Organizations.AsNoTracking()
               .Include(o => o.OrganizationType)
                .Where(o => o.Id == organizationId)
                .OrderByDescending(o => o.Rank)
               .FirstOrDefaultAsync();

            if (organization is null)
                throw new EntityNotFoundException(nameof(Organization), $"organizationId = {organizationId}");

            var entityReturn = _mapper.Map<OrganizationSelectDto>(organization);

            var chilDto = await this.GetAllChildrenAsync(organization.Id);
            var organizationChildDto = _mapper.Map<List<OrganizationSelectDto>>(chilDto);


            entityReturn.OrganizationChildren = organizationChildDto;
            return entityReturn;
        }
        //public async Task<OrganizationSelectDto> GetSelectV2(int companyId)
        //{
        //    //var organization = await _dbContext.Organizations
        //    //   .Include(o => o.OrganizationType)
        //    //   .Include(o=> o.OrganizatioParent)
        //    //    .Where(o => o.CompanyId == companyId)
        //    //    .OrderByDescending(o => o.Rank)
        //    //   .FirstOrDefaultAsync();
        //    var organization = await _dbContext.Organizations
        //    .Include(o => o.OrganizationType)
        //    .Include(o => o.OrganizatioParent) // Lọc trong Include
        //    .Where(o => o.CompanyId == companyId)
        //    .OrderByDescending(o => o.Rank)
        //    .FirstOrDefaultAsync();


        //    if (organization is null)
        //        throw new EntityNotFoundException(nameof(Organization), $"CompanyId = {companyId}");

        //    var entityReturn = _mapper.Map<OrganizationSelectDto>(organization);
        //    var organizationChildDto = await this.GetAllChildrenAsync<OrganizationSelectDto>(organization.Id);

        //    entityReturn.OrganizationChildren = organizationChildDto;
        //    return entityReturn;
        //}

        public async Task<PagingResult<GetOrganizationDto>> GetAll(string? keyWord, string? sortBy, string? orderBy, int pageIndex = 1, int pageSize = 10)
        {

            var query  =  _dbContext.Organizations
                .Where(o=> o.OrganizatioParentId == null)
                .Include( o => o.Employees)
               .Include(o => o.OrganizationType)
               .Include(o => o.OrganizationLeaders.Where(ol=> ol.OrganizationId == o.Id))
               .ThenInclude(ol => ol.Employee).AsQueryable();
            if( !string.IsNullOrWhiteSpace(keyWord) )
            {
                query = query.Where( o=> o.OrganizationName.Contains(keyWord) || o.OrganizationCode.Contains(keyWord) || o.Abbreviation.Contains(keyWord));
            }
            // Áp dụng sắp xếp
            query = query.ApplySorting(sortBy, orderBy);
            // Tính tổng số bản ghi
            int total = await query.CountAsync();
            // Áp dụng phân trang
            query = query.ApplyPaging(pageIndex, pageSize);

            var organizationDtos = await _mapper.ProjectTo<GetOrganizationDto>(query).ToListAsync();

            // Lấy tất cả các tổ chức con cho mỗi tổ chức và số lượng con :))))))))))))

            foreach (var orgDto in organizationDtos) 
            {
                orgDto.OrganizationChildren = await GetAllChildrenAsync(orgDto.Id);
                //orgDto.TotalEmployees = await CountEmployeesIncludingChildren();
            }
            //xử lý đếm số nhân viên từng tổ chức 

            await AssignTotalEmployeesToOrganizationDtos(organizationDtos);

            var result = new PagingResult<GetOrganizationDto>(organizationDtos, pageIndex, pageSize, sortBy, orderBy, total);
            return result;
        }

        public async Task<PagingResult<GetOrganizationDto>> Paging(string? keyWord, string? sortBy, string? orderBy, int pageIndex = 1, int pageSize = 10) {
            try {
                var baseQuery = _dbContext.Organizations
                    .AsNoTracking()
                    .Where(o => o.OrganizatioParentId == null);

                // Áp dụng tìm kiếm theo keyword
                if (!string.IsNullOrWhiteSpace(keyWord))
                {
                    baseQuery = baseQuery.Where(o =>
                        o.OrganizationName.Contains(keyWord) ||
                        o.OrganizationCode.Contains(keyWord) ||
                        o.Abbreviation.Contains(keyWord));
                }

                // Áp dụng sắp xếp
                baseQuery = baseQuery.ApplySorting(sortBy, orderBy);

                // Tính tổng số bản ghi
                int total = await baseQuery.CountAsync();

                // Áp dụng phân trang
                var pageQuery = baseQuery.ApplyPaging(pageIndex, pageSize);

                // Lấy danh sách root organization IDs trong page
                var rootOrgIds = await pageQuery.Select(o => o.Id).ToListAsync();

                if (!rootOrgIds.Any())
                {
                    return new PagingResult<GetOrganizationDto>(
                        new List<GetOrganizationDto>(), 
                        pageIndex, pageSize, sortBy, orderBy, total);
                }

                // Sử dụng CTE để lấy tất cả children và tính tổng nhân viên đệ quy
                var orgIdsParam = string.Join(",", rootOrgIds);
                var sql = $@"
                    WITH OrgHierarchy AS (
                        -- Anchor: Lấy root organizations trong page
                        SELECT 
                            o.Id,
                            o.OrganizationCode,
                            o.OrganizationName,
                            o.Abbreviation,
                            o.CompanyId,
                            o.Rank,
                            o.OrganizationTypeId,
                            o.OrganizatioParentId,
                            o.OrganizationStatus,
                            o.Id as RootId,
                            0 as Level
                        FROM Organizations o
                        WHERE o.Id IN ({orgIdsParam})
                        
                        UNION ALL
                        
                        -- Recursive: Lấy tất cả children đệ quy
                        SELECT 
                            o.Id,
                            o.OrganizationCode,
                            o.OrganizationName,
                            o.Abbreviation,
                            o.CompanyId,
                            o.Rank,
                            o.OrganizationTypeId,
                            o.OrganizatioParentId,
                            o.OrganizationStatus,
                            oh.RootId,
                            oh.Level + 1
                        FROM Organizations o
                        INNER JOIN OrgHierarchy oh ON o.OrganizatioParentId = oh.Id
                    ),
                    OrgWithEmployeeCount AS (
                        -- Tính số nhân viên trực tiếp cho từng organization
                        SELECT 
                            oh.Id,
                            oh.OrganizationCode,
                            oh.OrganizationName,
                            oh.Abbreviation,
                            oh.CompanyId,
                            oh.Rank,
                            oh.OrganizationTypeId,
                            oh.OrganizatioParentId,
                            oh.OrganizationStatus,
                            ot.Id as OrgTypeId,
                            ot.CompanyId as OrgTypeCompanyId,
                            ot.OrganizationTypeName,
                            oh.RootId,
                            oh.Level,
                            COUNT(DISTINCT e.Id) as DirectEmployeeCount
                        FROM OrgHierarchy oh
                        LEFT JOIN OrganizationTypes ot ON oh.OrganizationTypeId = ot.Id
                        LEFT JOIN Employees e ON e.OrganizationId = oh.Id
                        GROUP BY oh.Id, oh.OrganizationCode, oh.OrganizationName, oh.Abbreviation, 
                                 oh.CompanyId, oh.Rank, oh.OrganizationTypeId, oh.OrganizatioParentId, 
                                 oh.OrganizationStatus, ot.Id, ot.CompanyId, 
                                 ot.OrganizationTypeName, oh.RootId, oh.Level
                    ),
                    OrgDescendants AS (
                        -- CTE đệ quy để tìm tất cả descendants của mỗi org (bao gồm chính nó)
                        SELECT 
                            o.Id as OrgId,
                            o.Id as DescendantId,
                            o.RootId
                        FROM OrgWithEmployeeCount o
                        WHERE o.RootId IN ({orgIdsParam})
                        
                        UNION ALL
                        
                        SELECT 
                            od.OrgId,
                            oh.Id as DescendantId,
                            od.RootId
                        FROM OrgDescendants od
                        INNER JOIN OrgHierarchy oh ON oh.OrganizatioParentId = od.DescendantId
                        WHERE oh.RootId = od.RootId
                    ),
                    OrgWithTotalEmployees AS (
                        -- Tính tổng nhân viên đệ quy: tổng của org + tất cả descendants
                        SELECT 
                            o.Id,
                            o.RootId,
                            o.Level,
                            ISNULL(SUM(oe.DirectEmployeeCount), 0) as TotalEmployees
                        FROM OrgWithEmployeeCount o
                        LEFT JOIN OrgDescendants od ON od.OrgId = o.Id
                        LEFT JOIN OrgWithEmployeeCount oe ON oe.Id = od.DescendantId
                        WHERE o.RootId IN ({orgIdsParam})
                        GROUP BY o.Id, o.RootId, o.Level
                    )
                    SELECT 
                        o.Id,
                        o.OrganizationCode,
                        o.OrganizationName,
                        o.Abbreviation,
                        o.CompanyId,
                        o.Rank,
                        o.OrganizationTypeId,
                        o.OrganizatioParentId,
                        o.OrganizationStatus,
                        o.OrgTypeId as OrganizationType_Id,
                        o.OrgTypeCompanyId as OrganizationType_CompanyId,
                        o.OrganizationTypeName as OrganizationType_OrganizationTypeName,
                        o.RootId,
                        o.Level,
                        ISNULL(te.TotalEmployees, o.DirectEmployeeCount) as TotalEmployees
                    FROM OrgWithEmployeeCount o
                    LEFT JOIN OrgWithTotalEmployees te ON o.Id = te.Id
                    WHERE o.RootId IN ({orgIdsParam})
                    ORDER BY o.RootId, o.Level";

                // Execute CTE query và map vào DTO
                var orgData = new List<OrgHierarchyResult>();
                using (var command = _dbContext.Database.GetDbConnection().CreateCommand())
                {
                    command.CommandText = sql;
                    command.CommandType = CommandType.Text;
                    await _dbContext.Database.OpenConnectionAsync();
                    using (var reader = await command.ExecuteReaderAsync())
                    {
                        while (await reader.ReadAsync())
                        {
                            orgData.Add(new OrgHierarchyResult
                            {
                                Id = reader.GetInt32("Id"),
                                OrganizationCode = reader.GetString("OrganizationCode"),
                                OrganizationName = reader.GetString("OrganizationName"),
                                Abbreviation = reader.IsDBNull("Abbreviation") ? null : reader.GetString("Abbreviation"),
                                CompanyId = reader.IsDBNull("CompanyId") ? null : reader.GetInt32("CompanyId"),
                                Rank = reader.IsDBNull("Rank") ? null : reader.GetInt32("Rank"),
                                OrganizationTypeId = reader.IsDBNull("OrganizationTypeId") ? null : reader.GetInt32("OrganizationTypeId"),
                                OrganizatioParentId = reader.IsDBNull("OrganizatioParentId") ? null : reader.GetInt32("OrganizatioParentId"),
                                OrganizationStatus = reader.IsDBNull("OrganizationStatus") ? null : reader.GetBoolean("OrganizationStatus"),
                                OrganizationType_Id = reader.IsDBNull("OrganizationType_Id") ? null : reader.GetInt32("OrganizationType_Id"),
                                OrganizationType_CompanyId = reader.IsDBNull("OrganizationType_CompanyId") ? null : reader.GetInt32("OrganizationType_CompanyId"),
                                OrganizationType_OrganizationTypeName = reader.IsDBNull("OrganizationType_OrganizationTypeName") ? null : reader.GetString("OrganizationType_OrganizationTypeName"),
                                RootId = reader.GetInt32("RootId"),
                                Level = reader.GetInt32("Level"),
                                TotalEmployees = reader.GetInt32("TotalEmployees")
                            });
                        }
                    }
                    await _dbContext.Database.CloseConnectionAsync();
                }

                // Lấy leaders cho tất cả organizations (bao gồm cả children)
                var allOrgIds = orgData.Select(x => x.Id).Distinct().ToList();
                var leaderRows = await _dbContext.OrganizationLeaders
                    .AsNoTracking()
                    .Where(ol =>
                        allOrgIds.Contains(ol.OrganizationId) &&
                        ol.OrganizationLeaderType == OrganizationLeaderType.Leader)
                    .Select(ol => new
                    {
                        ol.OrganizationId,
                        Leader = new OrganizationLeaderDto
                        {
                            OrganizationLeaderType = ol.OrganizationLeaderType,
                            Employee = new GetOrganizationLeaderDto
                            {
                                Id = ol.Employee.Id,
                                LastName = ol.Employee.LastName,
                                FirstName = ol.Employee.FirstName
                            }
                        }
                    })
                    .ToListAsync();

                var leaderMap = leaderRows
                    .GroupBy(x => x.OrganizationId)
                    .ToDictionary(g => g.Key, g => g.Select(x => x.Leader).ToList());

                // Xây dựng cây tổ chức từ kết quả CTE
                var orgMap = orgData
                    .GroupBy(x => x.RootId)
                    .ToDictionary(g => g.Key, g => g.ToList());

                var items = new List<GetOrganizationDto>();

                foreach (var rootId in rootOrgIds)
                {
                    if (!orgMap.ContainsKey(rootId)) continue;

                    var rootData = orgMap[rootId].FirstOrDefault(x => x.Level == 0);
                    if (rootData == null) continue;

                    var rootDto = MapToGetOrganizationDto(rootData, leaderMap);
                    rootDto.OrganizationChildren = BuildOrganizationChildren(
                        rootId, 
                        orgMap[rootId], 
                        leaderMap, 
                        0);

                    items.Add(rootDto);
                }

                var result = new PagingResult<GetOrganizationDto>(items, pageIndex, pageSize, sortBy, orderBy, total);
                return result;
            }
            catch (Exception ex) {
                throw new Exception(ex.Message);
            }
        }

        // Helper class để map kết quả từ CTE
        private class OrgHierarchyResult
        {
            public int Id { get; set; }
            public string OrganizationCode { get; set; }
            public string OrganizationName { get; set; }
            public string? Abbreviation { get; set; }
            public int? CompanyId { get; set; }
            public int? Rank { get; set; }
            public int? OrganizationTypeId { get; set; }
            public int? OrganizatioParentId { get; set; }
            public bool? OrganizationStatus { get; set; }
            public int? OrganizationType_Id { get; set; }
            public int? OrganizationType_CompanyId { get; set; }
            public string? OrganizationType_OrganizationTypeName { get; set; }
            public int RootId { get; set; }
            public int Level { get; set; }
            public int TotalEmployees { get; set; }
        }

        // Helper method để map OrgHierarchyResult sang GetOrganizationDto
        private GetOrganizationDto MapToGetOrganizationDto(
            OrgHierarchyResult data, 
            Dictionary<int, List<OrganizationLeaderDto>> leaderMap)
        {
            return new GetOrganizationDto
            {
                Id = data.Id,
                OrganizationCode = data.OrganizationCode,
                OrganizationName = data.OrganizationName,
                Abbreviation = data.Abbreviation,
                CompanyId = data.CompanyId,
                Rank = data.Rank,
                OrganizationTypeId = data.OrganizationTypeId ?? 0,
                OrganizatioParentId = data.OrganizatioParentId,
                OrganizationStatus = data.OrganizationStatus,
                TotalEmployees = data.TotalEmployees,
                OrganizationType = data.OrganizationType_Id.HasValue ? new OrganizationTypeDto
                {
                    Id = data.OrganizationType_Id.Value,
                    CompanyId = data.OrganizationType_CompanyId ?? 0,
                    OrganizationTypeName = data.OrganizationType_OrganizationTypeName ?? string.Empty
                } : null!,
                OrganizationLeaders = leaderMap.TryGetValue(data.Id, out var leaders) 
                    ? leaders 
                    : new List<OrganizationLeaderDto>(),
                Employees = new List<GetOrganizationEmployeeDto>(),
                OrganizationChildren = new List<GetOrganizationDto>()
            };
        }

        // Helper method để xây dựng cây OrganizationChildren đệ quy
        private List<GetOrganizationDto> BuildOrganizationChildren(
            int parentId,
            List<OrgHierarchyResult> allOrgs,
            Dictionary<int, List<OrganizationLeaderDto>> leaderMap,
            int parentLevel)
        {
            var children = allOrgs
                .Where(x => x.OrganizatioParentId == parentId && x.Level == parentLevel + 1)
                .OrderBy(x => x.Rank)
                .ToList();

            if (!children.Any()) return new List<GetOrganizationDto>();

            var result = new List<GetOrganizationDto>();
            foreach (var child in children)
            {
                var childDto = MapToGetOrganizationDto(child, leaderMap);
                childDto.OrganizationChildren = BuildOrganizationChildren(
                    child.Id, 
                    allOrgs, 
                    leaderMap, 
                    child.Level);
                result.Add(childDto);
            }

            return result;
        }

        //public async Task<OrganizationDto> CreateV2(CreateOrganizationRequest request)
        //{
        //    var parentOrganization = await _dbContext.OrganizationV2s.FirstOrDefaultAsync(o => o.OrganizationName == "Công ty SMO");

        //    //var newOrganization = new OrganizationV2
        //    //{
        //    //    OrganizationCode = "SMO002",
        //    //    OrganizationName = "Công ty Con 1",
        //    //    Patch = parentOrganization.Path.GetDescendant(0, 0),  // Tạo con trực tiếp của tổ chức cha
        //    ////    ParentOrganizationId = parentOrganization.Id
        //    ////};

        //    //_dbContext.Organizations.Add(newOrganization);
        //    //await _dbContext.SaveChangesAsync();
        //    return _mapper.Map<OrganizationDto>(parentOrganization);
        //}
        public int GetRootOrganizationId(int childOrganizationId)
        {
            int? currentId = childOrganizationId;
            var organizations = _dbContext.Organizations.ToList();

            while (true)
            {
                // Tìm tổ chức hiện tại
                var currentOrg = organizations.FirstOrDefault(o => o.Id == currentId);

                if (currentOrg == null)
                    throw new EntityNotFoundException("Invalid organization ID");

                // Nếu không có OrganizatioParentId, đây là tổ chức gốc
                if (currentOrg.OrganizatioParentId == null)
                    return currentOrg.Id;

                // Chuyển sang ParentOrganizationId
                currentId = currentOrg.OrganizatioParentId;
            }
        }

    }
}
