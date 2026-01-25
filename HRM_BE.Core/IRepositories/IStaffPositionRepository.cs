using HRM_BE.Core.Data.Staff;
using HRM_BE.Core.ISeedWorks;
using HRM_BE.Core.Models.Common;
using HRM_BE.Core.Models.Organization;
using HRM_BE.Core.Models.Staff;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HRM_BE.Core.IRepositories
{
    public interface IStaffPositionRepository:IRepositoryBase<StaffPosition,int>
    {
        Task<StaffPositionDto> Create(CreateStaffPositionRequest request);
        Task Update(int id ,UpdateStaffPositionRequest request);
        Task Delete(int id);
        Task<StaffPositionDto> GetById(int id);
        Task<PagingResult<StaffPositionDto>> Paging(string? keyWord,bool? status, string? sortBy, string? orderBy, int pageIndex = 1, int pageSize = 10);
        Task DeleteRange(ListEntityIdentityRequest<int> request);
        Task UpdateStatus(int staffpositionId ,UpdateStaffPositionStatusRequest statusRequest);

    }
}
