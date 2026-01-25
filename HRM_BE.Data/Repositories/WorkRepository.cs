using AutoMapper;
using Hangfire.Server;
using HRM_BE.Core.Data.Task;
using HRM_BE.Core.Exceptions;
using HRM_BE.Core.Extension;
using HRM_BE.Core.IRepositories;
using HRM_BE.Core.Models.Common;
using HRM_BE.Core.Models.WorkModel;
using HRM_BE.Core.Models.WorkModelModel;
using HRM_BE.Data.SeedWorks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.SignalR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HRM_BE.Data.Repositories
{
    public class WorkRepository : RepositoryBase<Work, int>, IWorkRepository
    {
        private readonly IMapper _mapper;
        public WorkRepository(HrmContext context, IMapper mapper, IHttpContextAccessor httpContextAccessor) : base(context, httpContextAccessor)
        {
            _mapper = mapper;
        }
        public async Task<WorkDto> Create(CreateWorkRequest request)
        {
            var workEntity = _mapper.Map<Work>(request);

            var entityCreated = await CreateAsync(workEntity);

            if (request.Approvals != null && request.Approvals.Any())
            {
                var approvalEntityList = new List<Approval>();
                //var approvalEmployeeEntityList = new List<ApprovalEmployee>();
                foreach (var approval in request.Approvals)
                {
                    var approvalEnttiy = new Approval
                    {
                        WorkId = entityCreated.Id,
                        ApproveDate = approval.ApproveDate,
                        Description = approval.Description,
                        FileUrl = approval.FileUrl,
                        ApprovalEmployees = new List<ApprovalEmployee>() // Khởi tạo danh sách ApprovalEmployee

                    };
                    foreach (var item in approval.CreateApprovalEmployeeRequests)
                    {
                        var approvalEmployeeEntity = new ApprovalEmployee
                        {
                            EmployeeId = item.EmployeeId,
                            Description = approval.Description,
                        };

                        approvalEnttiy.ApprovalEmployees.Add(approvalEmployeeEntity);
                    }
                    approvalEntityList.Add(approvalEnttiy);

                }
                // Thêm tất cả vào DbContext
                await _dbContext.Approvals.AddRangeAsync(approvalEntityList);
                await _dbContext.SaveChangesAsync();
            }

            return _mapper.Map<WorkDto>(entityCreated);
        }

        public async Task Delete(int id)
        {
            var entity = await GetAndCheckExsit(id);
            entity.IsDeleted = true;
            await UpdateAsync(entity);
        }

        public async Task<WorkDto> GetById(int id)
        {
            var result = await GetAndCheckExsit(id);
            return _mapper.Map<WorkDto>(result);
        }

        public async Task<PagingResult<WorkDto>> Paging(string? keyWork, string? orderBy, string? sortBy, int pageIndex = 1, int pageSize = 10)
        {
            var query = _dbContext.Works.AsQueryable().AsNoTracking();
            if (!string.IsNullOrEmpty(keyWork))
            {
                query = query.Where(x => x.Name.Contains(keyWork));
            }
            var totalCount = await query.CountAsync();
            query.ApplySorting(orderBy, sortBy);
            query.ApplyPaging(pageIndex, pageSize);

            var data = await _mapper.ProjectTo<WorkDto>(query).ToListAsync();

            var result = new PagingResult<WorkDto>(data, pageIndex, pageSize, totalCount);
            return result;
        }

        public async Task<WorkDto> Update(int workId, UpdateWorkRequest request)
        {
            var work = await GetAndCheckExsit(workId);
            work.Approvals.Clear();
            work.CheckLists.Clear();
            work.TagWorks.Clear();
            work.SubWorks.Clear();
            work.Approvals.Clear();
            
            if (work.RemindWork != null && request.RemindWork == null)
            {
                _dbContext.RemindWorks.Remove(work.RemindWork);
            }

            if (request.Approvals != null && request.Approvals.Any())
            {
                var approvalEntityList = new List<Approval>();
                //var approvalEmployeeEntityList = new List<ApprovalEmployee>();
                foreach (var approval in request.Approvals)
                {
                    var approvalEnttiy = new Approval
                    {
                        WorkId = work.Id,
                        ApproveDate = approval.ApproveDate,
                        Description = approval.Description,
                        FileUrl = approval.FileUrl,
                        ApprovalEmployees = new List<ApprovalEmployee>() // Khởi tạo danh sách ApprovalEmployee

                    };
                    foreach (var item in approval.CreateApprovalEmployeeRequests)
                    {
                        var approvalEmployeeEntity = new ApprovalEmployee
                        {
                            EmployeeId = item.EmployeeId,
                            Description = approval.Description,
                        };

                        approvalEnttiy.ApprovalEmployees.Add(approvalEmployeeEntity);
                    }
                    approvalEntityList.Add(approvalEnttiy);

                }
                // Thêm tất cả vào DbContext
                await _dbContext.Approvals.AddRangeAsync(approvalEntityList);
                await _dbContext.SaveChangesAsync();
            }

            _mapper.Map(request, work);
            await UpdateAsync(work);
            return _mapper.Map<WorkDto>(work);
        }

        private async Task<Work> GetAndCheckExsit(int workId)
        {
            var work = await _dbContext.Works
                 .Include(w => w.Approvals).ThenInclude( a => a.ApprovalEmployees)
                .Include(w => w.CheckLists)
                .Include(w => w.TagWorks)
                .Include(w => w.SubWorks)
                .Include(w => w.RemindWork)
                .Include(w => w.Reporter)
                .Include(w => w.WorkAssignments)
                .Include(w => w.Executor)
                
                 .FirstOrDefaultAsync(s => s.Id == workId);
            if (work is null)
            {
                throw new EntityNotFoundException(nameof(work), $"workId = {workId}");
            }
            return work;
        }
    }
}
