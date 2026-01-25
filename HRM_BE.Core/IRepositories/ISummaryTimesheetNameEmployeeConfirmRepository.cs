using HRM_BE.Core.Data.Payroll_Timekeeping.Shift;
using HRM_BE.Core.Models.Common;
using HRM_BE.Core.Models.DetailTimeSheet;
using HRM_BE.Core.Models.Payroll_Timekeeping.TimekeepingRegulation;
using HRM_BE.Core.Models.SumaryTimeSheet;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HRM_BE.Core.IRepositories
{
    public interface ISummaryTimesheetNameEmployeeConfirmRepository
    {

        Task<PagingResult<SummaryTimesheetNameEmployeeConfirmDto>> Paging(GetSummaryTimesheetNameEmployeeConfirmRequest request);

        Task<PagingResult<SummaryTimesheetNameEmployeeConfirmDto>> PagingByEmployee(int? summaryTimesheetNameId, DateTime? startDate, DateTime? endDate, SummaryTimesheetNameEmployeeConfirmStatus? status, string? Note, DateTime? date, string? sortBy, string? orderBy, int employeeId, int pageIndex = 1, int pageSize = 10);

        Task<SummaryTimesheetNameSummaryTimesheetNameEmployeeConfirmDto> GetStatusByEmployee(int summaryTimesheetNameId, int employeeId);

        Task<SummaryTimesheetNameSummaryTimesheetNameEmployeeConfirmDto> CreateOrUpdate(CreateSummaryTimesheetNameEmployeeConfirmRequest request);

        Task<List<SummaryTimesheetNameSummaryTimesheetNameEmployeeConfirmDto>> CreateOrUpdateMultiple(CreateSummaryTimesheetNameEmployeeConfirmMultipleRequest request);

        Task<List<SummaryTimesheetNameEmployeeConfirmTimeSheetDto>> GetDetail(DateTime? startDate, DateTime? endDate, int employeeId);

        Task<List<ConfirmTimeSheetDto>> GetDetailByShiftWork(DateTime? startDate, DateTime? endDate, int employeeId);

        Task<List<PermittedLeaveDto>> GetPermittedLeaves(DateTime? startDate, DateTime? endDate, int employeeId);

        Task<SummaryTimesheetNameEmployeeConfirmDto> CheckExist(GetSummaryTimesheetNameEmployeeConfirmRequest request);

    }
}
