using AutoMapper;
using HRM_BE.Core.Data.ProfileEntity;
using HRM_BE.Core.Exceptions;
using HRM_BE.Core.IRepositories;
using HRM_BE.Core.Models.ProfileInfoModel;
using HRM_BE.Data.SeedWorks;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization.DataContracts;
using System.Text;
using System.Threading.Tasks;

namespace HRM_BE.Data.Repositories
{
    public class JobInfoRepository : RepositoryBase<JobInfo, int>, IJobInfoRepository
    {
        private readonly IMapper _mapper;
        public JobInfoRepository(HrmContext context, IMapper mapper, IHttpContextAccessor httpContextAccessor) : base(context, httpContextAccessor) {
            
                _mapper = mapper;
            

        }
        public async Task<JobInfoDto> Create(CreateJobInfoRequest request)
        {
            var entity = _mapper.Map<JobInfo>(request);
            await CreateAsync(entity);
            return _mapper.Map<JobInfoDto>(entity);
        }

        public async Task<JobInfoDto> GetById(int id)
        {
            var entity = await GetJobInfoAndCheckExsit(id);
            return _mapper.Map<JobInfoDto>(entity);
        }

        public async Task Update(int id, UpdateJobInfoRequest request)
        {
            var entity = await _dbContext.InfoJobs.Where( i => i.Id == id && i.EmployeeId == request.EmployeeId).SingleOrDefaultAsync();
            await UpdateAsync(_mapper.Map(request,entity));
        }
        private async Task<JobInfo> GetJobInfoAndCheckExsit(int jobInfoId)
        {
            var jobInfo = await _dbContext.InfoJobs.FindAsync(jobInfoId);
            if (jobInfo is null)
                throw new EntityNotFoundException(nameof(jobInfo), $"Id = {jobInfoId}");
            return jobInfo;
        }
    }
}