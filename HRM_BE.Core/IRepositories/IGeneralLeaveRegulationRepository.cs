using HRM_BE.Core.Data.Payroll_Timekeeping.LeaveRegulation;
using HRM_BE.Core.ISeedWorks;
using HRM_BE.Core.Models.Common;
using HRM_BE.Core.Models.Contract.NatureOfLabor;
using HRM_BE.Core.Models.Payroll_Timekeeping.LeaveRegulation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HRM_BE.Core.IRepositories
{
    public interface IGeneralLeaveRegulationRepository : IRepositoryBase<GeneralLeaveRegulation, int>
    {
        Task<PagingResult<GeneralLeaveRegulationDto>> Paging(int? organizationId, string? sortBy, string? orderBy, int pageIndex = 1, int pageSize = 10);
        Task<GeneralLeaveRegulationDto> Create(CreateGeneralLeaveRegulationRequest request);
        Task Update(int id, UpdateGeneralLeaveRegulationRequest request);
        Task<GeneralLeaveRegulationDto> GetById(int id);
        Task UpdateV2(int? organizationId, CreateGeneralLeaveRegulationRequest request);
        Task<GeneralLeaveRegulationDto?> GetByOrganizationId(int? organizationId);
    }
}
