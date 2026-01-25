using AutoMapper;
using HRM_BE.Core.Data.ProfileEntity;
using HRM_BE.Core.Models.ProfileInfoModel;

namespace HRM_BE.Api.Mappers
{
    public class JobInfoMapper:Profile
    {
        public JobInfoMapper()
        {
            CreateMap<CreateJobInfoRequest, JobInfo>();
            CreateMap<UpdateJobInfoRequest, JobInfo>();
            CreateMap<JobInfo,JobInfoDto>();
        }
    }
}
