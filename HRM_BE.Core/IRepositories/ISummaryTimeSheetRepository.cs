using HRM_BE.Core.Data.Payroll_Timekeeping.Shift;
using HRM_BE.Core.ISeedWorks;
using HRM_BE.Core.Models.Common;
using HRM_BE.Core.Models.SumaryTimeSheet;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HRM_BE.Core.IRepositories
{
    public interface ISummaryTimeSheetRepository:IRepositoryBase<SummaryTimesheetName,int>
    {
        Task<SummaryTimeSheetDto> GetById (int id);
        Task<PagingResult<SummaryTimeSheetDto>> Paging(int? summaryTimesheetId, string? name, int? month,int? year,int? organizationId,string? sortBy,string? orderBy,int pageIndex,int pageSize);
        Task<SummaryTimeSheetDto> Create(CreateSummaryTimesheetRequest request);
        Task Update (int id , UpdateSummaryTimeSheetRequest request);
        Task Delete (int id);
        Task<PagingResult<GetSummaryTimeSheetWithEmployeeDto>> GetSummaryTimeSheetPaging(int summaryTimeSheetId,int organizationId, string? keyWord, int? staffPositionId, string? sortBy, string? orderBy, int pageIndex, int pageSize);
        Task<List<GetSummaryTimeSheetWithEmployeeDto>> GetSummaryTimeSheetWithEmployeeList(int summaryTimeSheetId, int organizationId, string? keyWord, int? staffPositionId, string? sortBy, string? orderBy);
        Task<List<GetSelectSummaryTimeSheetDto>> GetSelectSummaryTimeSheet();
        Task<List<GetSelectSummaryTimeSheetDto>> GetSelectSummaryTimeSheetForPayroll(int? organizationId, string? staffPositionIds);
    }
}
