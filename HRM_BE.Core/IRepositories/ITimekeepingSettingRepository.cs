using HRM_BE.Core.Data.Payroll_Timekeeping.TimekeepingRegulation;
using HRM_BE.Core.ISeedWorks;
using HRM_BE.Core.Models.Common;
using HRM_BE.Core.Models.Payroll_Timekeeping.TimekeepingRegulation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HRM_BE.Core.IRepositories
{
    public interface ITimekeepingSettingRepository : IRepositoryBase<TimekeepingSetting, int>
    {
        Task<PagingResult<TimekeepingSettingDto>> Paging(int? organizationId, string? sortBy, string? orderBy, int pageIndex = 1, int pageSize = 10);
        Task<TimekeepingSettingDto> Create(CreateTimekeepingSettingRequest request);
        Task<TimekeepingSettingDto> GetById(int id);
    }
}
