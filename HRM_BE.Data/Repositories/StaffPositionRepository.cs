using AutoMapper;
using HRM_BE.Core.Data.Company;
using HRM_BE.Core.Data.Staff;
using HRM_BE.Core.Exceptions;
using HRM_BE.Core.Extension;
using HRM_BE.Core.IRepositories;
using HRM_BE.Core.ISeedWorks;
using HRM_BE.Core.Models.Common;
using HRM_BE.Core.Models.Company;
using HRM_BE.Core.Models.Organization;
using HRM_BE.Core.Models.Staff;
using HRM_BE.Data.SeedWorks;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Linq.Expressions;
using System.Net.WebSockets;
using System.Text;
using System.Threading.Tasks;

namespace HRM_BE.Data.Repositories
{
    public class StaffPositionRepository:RepositoryBase<StaffPosition,int>, IStaffPositionRepository
    {
        private readonly IMapper _mapper;
        public StaffPositionRepository(HrmContext context,IMapper mapper, IHttpContextAccessor httpContextAccessor):base(context,httpContextAccessor)
        {
            _mapper = mapper;
        }

        public async Task<StaffPositionDto> Create(CreateStaffPositionRequest request)
        {
            await CheckStaffPositionExist(request.PositionCode);
            var enitty = _mapper.Map<StaffPosition>(request);
            var staffPosition =  await CreateAsync(enitty);

            var organizationPositions = new List<OrganizationPosition>();

            foreach (var item in request.OrganizationPositions)
            {
                // Kiểm tra nếu OrganizationPosition đã tồn tại
                var existingOrganizationPosition = await _dbContext.OrganizationPositions
                    .FirstOrDefaultAsync(op => op.StaffPositionId == staffPosition.Id && op.OrganizationId == item.OrganizationId);

                if (existingOrganizationPosition == null)
                {
                    // Nếu chưa tồn tại, thêm vào danh sách
                    organizationPositions.Add(new OrganizationPosition
                    {
                        StaffPositionId = staffPosition.Id,
                        OrganizationId = item.OrganizationId
                    });
                }
            }
            // Nếu có OrganizationPositions cần thêm, thêm tất cả một lần
            if (organizationPositions.Any())
            {
                await _dbContext.OrganizationPositions.AddRangeAsync(organizationPositions);
                await _dbContext.SaveChangesAsync();  // Lưu tất cả một lần
            }

            var entityReturn = _mapper.Map<StaffPositionDto>(enitty);
            return entityReturn;
        }
        private async Task CheckStaffPositionExist(string staffPositionCode)
        {
            var entity = await _dbContext.StaffPositions.Where( s => s.PositionCode == staffPositionCode).FirstOrDefaultAsync();
            if (entity is not null)
                throw new EntityAlreadyExistsException($"Mã {staffPositionCode} đã tồn tại");
        }
        public async Task Delete(int id)
        {
            var entity =  await GetStaffPositionAndCheckExist(id);
            entity.IsDeleted = true;
            await UpdateAsync(entity);
        }

        public async Task DeleteRange(ListEntityIdentityRequest<int> request)
        {
            var entities = await _dbContext.StaffPositions.Where(x => request.Ids.Contains(x.Id)).ToListAsync();

            entities.ForEach(x => x.IsDeleted = true);
            await SaveChangesAsync();
            //foreach (var id in request.Ids )
            //{
            //    var entity =  _dbContext.StaffPositions.Find(id);
            //    entity.IsDeleted = true;
            //    _dbContext.SaveChanges();
            //}
            //return Task.CompletedTask;

        }

        public async Task<StaffPositionDto> GetById(int id)
        {
            var staffPosition = await _dbContext.StaffPositions.Include(x => x.GroupPosition).Include(x=> x.OrganizationPositions)
                .Include( x=> x.StaffTitle).FirstOrDefaultAsync(x => x.Id == id);
            var organizationPositions = await _dbContext.OrganizationPositions.Where(x => x.StaffPositionId == id).ToListAsync();
            staffPosition.OrganizationPositions = organizationPositions;
            
            return _mapper.Map<StaffPositionDto>(staffPosition);
        }
      
        public async Task<OrganizationSelectDto> GetOrganizationByPositionId(int id)
        {
            var organization = await _dbContext.OrganizationPositions.Where( op=> op.StaffPositionId == id).Include( o => o.Organization).FirstOrDefaultAsync();

            return _mapper.Map<OrganizationSelectDto>(organization);
        }

        public async Task<PagingResult<StaffPositionDto>> Paging(string? keyWord, bool? status, string? sortBy, string? orderBy, int pageIndex = 1, int pageSize = 10)
        {
            var query = _dbContext.StaffPositions.Where(o=> o.IsDeleted == false).AsQueryable();
            if(!string.IsNullOrEmpty(keyWord) ) 
            {
                query = query.Where( k=> k.PositionName.Contains(keyWord) || k.PositionCode.Contains(keyWord) );
            }
            if(status.HasValue)
            {
                query = query.Where( s=> s.StaffPositionStatus ==  status.Value );
            }
            // Áp dụng sắp xếp
            query = query.ApplySorting(sortBy, orderBy);
            // Tính tổng số bản ghi
            int total = await query.CountAsync();
            // Áp dụng phân trang
            query = query.ApplyPaging(pageIndex, pageSize);

            var data = await _mapper.ProjectTo<StaffPositionDto>(query).ToListAsync();

            var result = new PagingResult<StaffPositionDto>(data, pageIndex, pageSize, sortBy, orderBy, total);

            return result;
        }

        public async Task Update(int id,UpdateStaffPositionRequest request)
        {
            var entity = await GetStaffPositionAndCheckExist(id);

            // Lấy tất cả các OrganizationPosition hiện tại của StaffPosition
            var currentOrganizationPositions = await _dbContext.OrganizationPositions
                .Where(x => x.StaffPositionId == entity.Id)
                .ToListAsync();


            // Tạo danh sách các OrganizationPositions mới từ yêu cầu
            var newOrganizationPositions = request.OrganizationPositions;

            // Tạo một danh sách các OrganizationPositions cần xóa (các vị trí đã bị xóa trong request)
            var positionsToRemove = currentOrganizationPositions
                .Where(existing => !newOrganizationPositions.Any(item => item.OrganizationId == existing.OrganizationId))
                .ToList();

            // Tạo một danh sách các OrganizationPositions cần thêm (các vị trí mới trong request)
            var positionsToAdd = newOrganizationPositions
                .Where(newItem => !currentOrganizationPositions.Any(existing => existing.OrganizationId == newItem.OrganizationId))
                .ToList();

            // Cập nhật các OrganizationPosition đã tồn tại (các vị trí không thay đổi, chỉ cần đảm bảo StaffPositionId đúng)
            foreach (var existingPosition in currentOrganizationPositions)
            {
                var newPosition = newOrganizationPositions.FirstOrDefault(item => item.OrganizationId == existingPosition.OrganizationId);
                if (newPosition != null)
                {
                    // Cập nhật các thuộc tính nếu cần, ví dụ: thay đổi OrganizationId hoặc các thuộc tính khác
                    existingPosition.StaffPositionId = entity.Id;  // Cập nhật lại StaffPositionId nếu cần
                                                                   // (Ví dụ: Cập nhật các thuộc tính khác nếu có)
                }
            }

            // Xóa các OrganizationPosition không còn trong request
            _dbContext.OrganizationPositions.RemoveRange(positionsToRemove);

            // Thêm các OrganizationPosition mới
            foreach (var item in positionsToAdd)
            {
                var newOrganizationPosition = new OrganizationPosition
                {
                    StaffPositionId = entity.Id,
                    OrganizationId = item.OrganizationId
                };

                await _dbContext.OrganizationPositions.AddAsync(newOrganizationPosition);
            }
            // Cập nhật StaffPosition
            _mapper.Map(request, entity);

            // Lưu các thay đổi vào cơ sở dữ liệu
            await _dbContext.SaveChangesAsync();

        }

        public async Task UpdateStatus(int staffpositionId ,UpdateStaffPositionStatusRequest statusRequest)
        {
            var staffPosition = await GetStaffPositionAndCheckExist(staffpositionId);
            staffPosition.StaffPositionStatus = statusRequest.StaffPositionStatus;
            await UpdateAsync(staffPosition);
        }

        private async Task<StaffPosition> GetStaffPositionAndCheckExist(int id)
        {
            var entity = await _dbContext.StaffPositions.FindAsync(id);
            if (entity is null)
                throw new EntityNotFoundException(nameof(StaffPosition), $"Id = {id}");
            return entity;
        }
        
    }
}
