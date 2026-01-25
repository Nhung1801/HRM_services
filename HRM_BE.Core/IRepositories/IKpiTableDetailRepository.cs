using HRM_BE.Core.Data.Salary;
using HRM_BE.Core.ISeedWorks;
using HRM_BE.Core.Models.Common;
using HRM_BE.Core.Models.Salary.KpiTableDetail;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HRM_BE.Core.IRepositories
{
    public interface IKpiTableDetailRepository : IRepositoryBase<KpiTableDetail, int>
    {
        Task<KpiTableDetailDto> GetById(int KpiTableDetailId);
        Task<PagingResult<KpiTableDetailDto>> Paging(GetKpiTableDetailRequest request ,string? sortBy, string? orderBy, int pageIndex = 1, int pageSize = 10);
        Task<KpiTableDetailDto> Create(CreateKpiTableDetailRequest request);
        Task Update(int KpiTableDetailId, UpdateKpiTableDetailRequest request);
        Task Delete(int KpiTableDetailId);
        Task<KpiTableDetailDto> GetByShiftWorkId(int shiftWorkId);
    }
}
