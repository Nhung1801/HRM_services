using HRM_BE.Core.Data.Payroll_Timekeeping.Shift;
using HRM_BE.Core.ISeedWorks;
using HRM_BE.Core.Models.Common;
using HRM_BE.Core.Models.ShiftWork;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HRM_BE.Core.IRepositories
{
    public interface IShiftWorkRepository:IRepositoryBase<ShiftWork,int>
    {
        Task<ShiftWorkDto> GetById(int id);
        Task<PagingResult<ShiftWorkDto>> Paging(string? name,int? organizationId,string? sortBy,string? orderBy,int pageIndex,int pageSize);
        Task<ShiftWorkDto> Create(CreateShiftWorkRequest request);
        Task Update(int shiftWorkId , UpdateShiftWorkRequest request);
        Task<List<ShiftWorkDto>> GetByEmployee(DateTime adjustedStartDate, DateTime adjustedEndDate, int employeeId);
        Task Delete(int shiftWorkId);
        
        // Method lấy shiftWorkId cho màn chấm công GPS vào ra 
        Task<int?> GetShiftWorkIdForModuleTimekeepingGpsInOutAsync(int organizationId, DateTime currentDateTime);

        //tny
        Task<List<ShiftScheduleDto>> GetShiftsForPeriod(DateTime startDate, DateTime endDate, int employeeId);

    }
}
