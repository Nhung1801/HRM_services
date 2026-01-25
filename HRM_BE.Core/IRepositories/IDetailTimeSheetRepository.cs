using HRM_BE.Core.Data.Payroll_Timekeeping.Shift;
using HRM_BE.Core.ISeedWorks;
using HRM_BE.Core.Models.Common;
using HRM_BE.Core.Models.DetailTimeSheet;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HRM_BE.Core.IRepositories
{
    public interface IDetailTimeSheetRepository:IRepositoryBase<DetailTimesheetName,int>
    {
        Task<DetailTimeSheetDto> GetById(int id);
        Task<PagingResult<DetailTimeSheetDto>> Paging(string? name, int? month, int? year, int? organizationId, string? staffPositionIds, string? sortBy,string? orderBy,int pageIndex = 1,int pageSize = 10);      
        Task<PagingResult<DetailTimeSheetDto>> GetSelect(string? name, int? month, int? year, int? organizationId, string? staffPositionIds, string? sortBy,string? orderBy,int pageIndex = 1,int pageSize = 10);
        Task<DetailTimeSheetDto> Create(CreateDetailTimeSheetRequest request);
        Task Update (int id, UpdateDetailTimeSheetRequest request);
        Task Delete (int id);
        Task LockDetailTimeSheet(int id, bool isLock);
        Task<PagingResult<GetDetailTimesheetWithEmployeeDto>> DetailTimeSheetWithEmployeePaging(int detailTimeSheetId ,string? keyWord, int? organizationId, string? sortBy, string? orderBy, int pageIndex = 1, int pageSize = 10);
        Task<StatiscTimeSheetDto> StatiscTimeSheetDto(int detailTimeSheetId);

    }
}
