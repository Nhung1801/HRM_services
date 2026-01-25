using HRM_BE.Core.Data.Task;
using HRM_BE.Core.ISeedWorks;
using HRM_BE.Core.Models.Delegation;
using HRM_BE.Core.Models.Project;
using HRM_BE.Core.Models.Staff;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HRM_BE.Core.IRepositories
{
    public interface IDelegationRepository:IRepositoryBase<Delegation, int>
    {
        Task<DelegationDto> CreateAsync(CreateDelegationRequest request);

        Task<DelegationDto> UpdateAsync(UpdateDelegationRequest request);

        Task DeleteSoftAsync(int id);

        Task<DelegationDto> GetByIdAsync(int id);

        Task<List<DelegationDto>> GetAllAsync();

        Task<List<DelegationDto>> GetAllByEmployeeDelegationAsync(int employeeDelegationId);



    }
}
