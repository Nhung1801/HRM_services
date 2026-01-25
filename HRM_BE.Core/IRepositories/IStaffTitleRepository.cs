using HRM_BE.Core.Data.Staff;
using HRM_BE.Core.ISeedWorks;
using HRM_BE.Core.Models.Staff;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HRM_BE.Core.IRepositories
{
    public interface IStaffTitleRepository:IRepositoryBase<StaffTitle,int>
    {
        Task<StaffTitleDto> GetById(int id);
        Task<List<StaffTitleDto>> GetAll();
        Task<StaffTitleDto> Create(CreateStaffTitleRequest request);
        Task Update(int id, UpdateStaffTitleRequest request);
        Task Delete(int id);
    }

}
