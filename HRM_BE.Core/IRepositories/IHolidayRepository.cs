using HRM_BE.Core.Data.Payroll_Timekeeping.LeaveRegulation;
using HRM_BE.Core.ISeedWorks;
using HRM_BE.Core.Models.Common;
using HRM_BE.Core.Models.Payroll_Timekeeping.LeaveRegulation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HRM_BE.Core.IRepositories
{
    public interface IHolidayRepository : IRepositoryBase<Holiday, int>
    {
        Task<PagingResult<HolidayDto>> Paging(int? organizationId, string? name, string? sortBy, string? orderBy, int pageIndex = 1, int pageSize = 10);
        Task<HolidayDto> Create(CreateHolidayRequest request);
        Task Update(int id, UpdateHolidayRequest request);
        Task<HolidayDto> GetById(int id);
        Task Delete(int id);
        Task<double> GetNumberHoliday(DateTime startDate, DateTime endDate, int organizationId);
        Task<List<DateTime>> GetDayHoliday(DateTime startDate, DateTime endDate,int employeeId);


    }
}
