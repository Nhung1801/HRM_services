using HRM_BE.Core.Data.Payroll_Timekeeping.TimekeepingRegulation;
using HRM_BE.Core.ISeedWorks;
using HRM_BE.Core.Models.Common;
using HRM_BE.Core.Models.Payroll_Timekeeping.LeaveRegulation;
using HRM_BE.Core.Models.Payroll_Timekeeping.TimekeepingRegulation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HRM_BE.Core.IRepositories
{
    public interface ITimekeepingRegulationRepository : IRepositoryBase<TimekeepingRegulation, int>
    {
        Task<PagingResult<TimekeepingRegulationDto>> Paging(int? organizationId, string? sortBy, string? orderBy, int pageIndex = 1, int pageSize = 10);
        Task Update(int id, UpdateTimekeepingRegulationRequest request);
        Task UpdateV2(int id, CreateTimeKeepingRegulationRequest request);
        Task<TimekeepingRegulationDto> Create(CreateTimeKeepingRegulationRequest request);
        Task<TimekeepingRegulationDto> GetById(int id);
        Task<TimekeepingRegulationDto?> GetByOrganizationId(int organizationId);

    }
}
