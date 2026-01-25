using HRM_BE.Core.Data.ProfileEntity;
using HRM_BE.Core.ISeedWorks;
using HRM_BE.Core.Models.Common;
using HRM_BE.Core.Models.ProfileInfoModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HRM_BE.Core.IRepositories
{
    public  interface IDeductionRepository:IRepositoryBase<Deduction,int>
    {
        Task<DeductionDto> GetById(int id);
        Task<List<DeductionDto>> GetDeductionByEmployeeId(int employeeId);
        Task<DeductionDto> Create(CreateDeductionRequest request);
        Task Update(int id ,UpdateDeductionRequest request);
        Task Delete(int id);
        Task<List<DeductionDto>> GetAll();
    }
}
