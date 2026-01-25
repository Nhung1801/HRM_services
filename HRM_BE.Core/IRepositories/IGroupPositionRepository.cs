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
    public interface IGroupPositionRepository:IRepositoryBase<GroupPosition,int>
    {
        Task<GroupPositionDto> GetById(int id);
        Task<List<GroupPositionDto>> GetAll();
        Task<GroupPositionDto> Create(CreateGroupPositionRequest request);
        Task Update(int id , UpdateGrouptPositonRequest request);
        Task Delete(int id);
    }
}
