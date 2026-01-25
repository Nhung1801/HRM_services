using HRM_BE.Core.Data.Task;
using HRM_BE.Core.ISeedWorks;
using HRM_BE.Core.Models.Common;
using HRM_BE.Core.Models.Work;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HRM_BE.Core.IRepositories
{
    public interface IApprovalEmployeeRepository:IRepositoryBase<ApprovalEmployee,int>
    {
        public Task<ApprovalEmployeeDto> GetById(int id);
        Task<PagingResult<ApprovalEmployeeDto>> Paging(string? keyWord, int? approvalId, int? employeeId,string? orderBy, string? sortBy, int pageIndex, int pageSizee);
        public Task Update(int id, UpdateApprovalEmployeeRequest request);
    }
}
