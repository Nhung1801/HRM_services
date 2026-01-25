using AutoMapper;
using HRM_BE.Core.Data.Payroll_Timekeeping.LeaveRegulation;
using HRM_BE.Core.IRepositories;
using HRM_BE.Core.Models.Payroll_Timekeeping.LeaveRegulation;
using HRM_BE.Data.SeedWorks;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HRM_BE.Data.Repositories
{
    public class WorkFactorRepository : RepositoryBase<WorkFactor, int>, IWorkFactorRepository
    {
        private readonly IMapper _mapper;

        public WorkFactorRepository(HrmContext context, IMapper mapper, IHttpContextAccessor httpContextAccessor) : base(context, httpContextAccessor)
        {
            _mapper = mapper;
        }
        public async Task<List<WorkFactorDto>> GetByYear(int year)
        {
            var factors = await _dbContext.WorkFactors
                .Include(wf => wf.Holiday)
                .Where(wf => wf.Year == year)
                .ToListAsync();

            return _mapper.Map<List<WorkFactorDto>>(factors);
        }

        public async Task SaveFactors(int year, List<SaveWorkFactorRequest> requests)
        {
            foreach (var request in requests)
            {
                var entity = await _dbContext.WorkFactors
                    .FirstOrDefaultAsync(wf => wf.HolidayId == request.HolidayId && wf.Year == year);

                if (entity == null)
                {
                    entity = _mapper.Map<WorkFactor>(request);
                    entity.Year = year;
                    await _dbContext.WorkFactors.AddAsync(entity);
                }

                else
                {
                    entity.Factor = request.Factor;
                    entity.IsFixed = request.IsFixed;
                }
            }

            await _dbContext.SaveChangesAsync();

        }
    }
}
