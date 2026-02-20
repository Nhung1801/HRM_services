using HRM_BE.Api.Services.Interfaces;
using HRM_BE.Core.Constants;
using HRM_BE.Core.Constants.System;
using HRM_BE.Core.Data.Identity;
using HRM_BE.Core.Exceptions;
using HRM_BE.Core.Models.Common;
using HRM_BE.Core.Models.Identity.Permission;
using HRM_BE.Data;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using System.Net;

namespace HRM_BE.Api.Services
{
    public class PermissionService: IPermissionService
    {
        private readonly HrmContext _dbContext;
        private readonly IMapper _mapper;


        public PermissionService(HrmContext dbContext, IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }

        private List<PermissionDto> GetChildren(int parentId)
        {
            var children = _dbContext.Permissions
                .Where(p => p.ParentPermissionId == parentId)
                .ToList();

            var childDtos = new List<PermissionDto>();

            foreach (var childPermission in children)
            {
                var childDto = _mapper.Map<PermissionDto>(childPermission);
                childDto.Childrens = GetChildren(childPermission.Id);
                childDtos.Add(childDto);
            }

            return childDtos;
        }


        public async Task<PagingResult<PermissionDto>> GetPaging(GetPermissionRequest request)
        {
            try
            {
                var permissions = await GetRecursive(null);

                if (!string.IsNullOrWhiteSpace(request.Name) ||
                    !string.IsNullOrWhiteSpace(request.DisplayName) ||
                    !string.IsNullOrWhiteSpace(request.Description) ||
                    request.Section.HasValue)
                {
                    var nameFilter = request.Name?.Trim();
                    var displayNameFilter = request.DisplayName?.Trim();
                    var descriptionFilter = request.Description?.Trim();
                    var sectionFilter = request.Section;

                    bool Match(PermissionDto p)
                    {
                        if (p == null) return false;

                        if (!string.IsNullOrEmpty(nameFilter) &&
                            (string.IsNullOrEmpty(p.Name) ||
                             !p.Name.Contains(nameFilter, StringComparison.OrdinalIgnoreCase)))
                            return false;

                        if (!string.IsNullOrEmpty(displayNameFilter) &&
                            (string.IsNullOrEmpty(p.DisplayName) ||
                             !p.DisplayName.Contains(displayNameFilter, StringComparison.OrdinalIgnoreCase)))
                            return false;

                        if (!string.IsNullOrEmpty(descriptionFilter) &&
                            (string.IsNullOrEmpty(p.Description) ||
                             !p.Description.Contains(descriptionFilter, StringComparison.OrdinalIgnoreCase)))
                            return false;

                        if (sectionFilter.HasValue && p.Section != sectionFilter)
                            return false;

                        return true;
                    }

                    List<PermissionDto> FilterTree(IEnumerable<PermissionDto> nodes)
                    {
                        var result = new List<PermissionDto>();
                        foreach (var node in nodes ?? Enumerable.Empty<PermissionDto>())
                        {
                            var filteredChildren = FilterTree(node.Childrens);
                            var isMatch = Match(node) || filteredChildren.Count > 0;
                            if (!isMatch) continue;

                            node.Childrens = filteredChildren;
                            result.Add(node);
                        }
                        return result;
                    }

                    permissions = FilterTree(permissions);
                }

                var total = permissions.Count;

                if (request.PageIndex == null) request.PageIndex = 1;
                if (request.PageSize == null) request.PageSize = total;

                int totalPages = (int)Math.Ceiling((double)total / request.PageSize);

                if (string.IsNullOrEmpty(request.SortBy) || request.SortBy == SortByConstant.Desc)
                {
                    permissions = request.OrderBy switch
                    {
                        OrderByConstant.Id or _ => permissions.OrderByDescending(p => p.Id).ToList(),
                    };
                }
                else if (request.SortBy == SortByConstant.Asc)
                {
                    permissions = request.OrderBy switch
                    {
                        OrderByConstant.Id or _ => permissions.OrderBy(p => p.Id).ToList(),
                    };
                }

                var items = permissions
                    .Skip((request.PageIndex - 1) * request.PageSize)
                    .Take(request.PageSize)
                    .ToList();

                var result = new PagingResult<PermissionDto>(items, request.PageIndex, request.PageSize, request.SortBy, request.OrderBy, total);

                return result;
            }
            catch (Exception ex)
            {
                throw new ApiException(ex.Message, HttpStatusCodeConstant.InternalServerError, ex);
            }
        }

        private async Task<List<PermissionDto>> GetRecursive(int? parentPermissionId)
        {
            var children = _dbContext.Permissions
                 .Where(p => p.ParentPermissionId == parentPermissionId)
                 .ToList();

            var childDtos = new List<PermissionDto>();

            foreach (var childPermission in children)
            {
                var childDto = _mapper.Map<PermissionDto>(childPermission);
                childDto.Childrens = GetChildren(childPermission.Id);
                childDtos.Add(childDto);
            }

            return childDtos;
        }


        public async Task<List<PermissionDto>> GetByRoleId(int roleId)
        {
            try
            {
                var rolePermissions = await _dbContext.RolePermissions
                    .Where(rp => rp.RoleId == roleId)
                    .Include(rp => rp.Permission)
                    .ToListAsync();

                var permissions = rolePermissions.Select(rp => rp.Permission);

                var result = await GetRecursive(null, permissions);

                return result;
            }
            catch (Exception ex)
            {
                throw new ApiException(ex.Message, HttpStatusCodeConstant.InternalServerError, ex);
            }
        }

        private async Task<List<PermissionDto>> GetRecursive(int? parentPermissionId, IEnumerable<Permission> allPermissions)
        {
            var children = allPermissions
                .Where(p => p.ParentPermissionId == parentPermissionId)
                .ToList();

            var childDtos = new List<PermissionDto>();

            foreach (var childPermission in children)
            {
                var childDto = _mapper.Map<PermissionDto>(childPermission);
                childDto.Childrens = await GetRecursive(childPermission.Id, allPermissions);
                childDtos.Add(childDto);
            }

            return childDtos;
        }


        public async Task<PermissionDto> Create(CreatePermissionRequest request)
        {
            var permission = _mapper.Map<Permission>(request);
            permission.CreatedAt = DateTime.Now;

            await _dbContext.Permissions.AddAsync(permission);
            await _dbContext.SaveChangesAsync();

            var permissionDto = _mapper.Map<PermissionDto>(permission);

            return permissionDto;

        }


    }
}
