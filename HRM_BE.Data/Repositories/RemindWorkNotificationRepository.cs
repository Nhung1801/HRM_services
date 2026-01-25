using AutoMapper;
using HRM_BE.Core.Data.Task;
using HRM_BE.Core.Extension;
using HRM_BE.Core.IRepositories;
using HRM_BE.Core.Models.Common;
using HRM_BE.Core.Models.WorkNotification;
using HRM_BE.Data.SeedWorks;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.WebSockets;
using System.Text;
using System.Threading.Tasks;

namespace HRM_BE.Data.Repositories
{
    public class RemindWorkNotificationRepository: RepositoryBase<RemindWorkNotification, int>, IRemindWorkNotificationRepository
    {
        private readonly IMapper _mapper;
        public RemindWorkNotificationRepository(HrmContext context,IMapper mapper, IHttpContextAccessor httpContextAccessor):base(context, httpContextAccessor)
        {
            _mapper = mapper;
        }

        public async Task<PagingResult<RemindWorkNotificationDto>> Paging(string? keyWord, int? employeeId, int? workId, int? remindWorkId, string? orderBy, string? sortBy, int pageIndex, int pageSize)
        {
            var query = _dbContext.RemindWorkNotifications.AsNoTracking().AsQueryable();
            if(!string.IsNullOrEmpty(keyWord))
            {
                query = query.Where(x => x.Work.Name.Contains(keyWord));
            }
            if (employeeId.HasValue)
            {
                query = query.Where(x => x.Work.ExecutorId == employeeId);
            }
            if (workId.HasValue)
            {
                query = query.Where(x => x.WorkId == workId);
            }
            if (remindWorkId.HasValue)
            {
                query = query.Where(x => x.RemindWorkId == remindWorkId);
            }

            query = query.ApplySorting(orderBy, sortBy);

            query = query.ApplyPaging(pageIndex, pageSize);

            var total = await query.CountAsync();
            var data = await _mapper.ProjectTo<RemindWorkNotificationDto>(query).ToListAsync();
            var result = new PagingResult<RemindWorkNotificationDto>( data,pageIndex,pageSize,total);
            return result;
        }
    }
}
