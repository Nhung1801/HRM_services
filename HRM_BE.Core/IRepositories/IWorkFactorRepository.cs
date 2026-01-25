using HRM_BE.Core.Data.Payroll_Timekeeping.LeaveRegulation;
using HRM_BE.Core.ISeedWorks;
using HRM_BE.Core.Models.Payroll_Timekeeping.LeaveRegulation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HRM_BE.Core.IRepositories
{
    public interface IWorkFactorRepository : IRepositoryBase<WorkFactor, int>
    {
        Task<List<WorkFactorDto>> GetByYear(int year);
        Task SaveFactors(int year, List<SaveWorkFactorRequest> requests);
    }
}
