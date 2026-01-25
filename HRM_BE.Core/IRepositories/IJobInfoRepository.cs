using HRM_BE.Core.Data.ProfileEntity;
using HRM_BE.Core.ISeedWorks;
using HRM_BE.Core.Models.Common;
using HRM_BE.Core.Models.Contract.Allowance;
using HRM_BE.Core.Models.ProfileInfoModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HRM_BE.Core.IRepositories
{
    public interface IJobInfoRepository:IRepositoryBase<JobInfo,int>
    {
        //Task<PagingResult<JobInfo>> Paging(string? keyWord, string? sortBy, string? orderBy, int pageIndex = 1, int pageSize = 10);
        Task<JobInfoDto> Create(CreateJobInfoRequest request);
        Task Update(int id, UpdateJobInfoRequest request);
        Task<JobInfoDto> GetById(int id);
    }
}
