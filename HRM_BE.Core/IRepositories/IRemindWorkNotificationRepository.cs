using HRM_BE.Core.Data.Task;
using HRM_BE.Core.ISeedWorks;
using HRM_BE.Core.Models.Common;
using HRM_BE.Core.Models.WorkNotification;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HRM_BE.Core.IRepositories
{
    public interface IRemindWorkNotificationRepository:IRepositoryBase<RemindWorkNotification,int>
    {
        Task<PagingResult<RemindWorkNotificationDto>> Paging(string? keyWord, int? employeeId, int? workId, int? remindWorkId, string? orderBy, string? sortBy, int pageIndex, int pageSize);
    }
}
