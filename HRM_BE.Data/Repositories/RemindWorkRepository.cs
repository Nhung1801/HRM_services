using AutoMapper;
using HRM_BE.Core.Data.Task;
using HRM_BE.Core.IRepositories;
using HRM_BE.Data.SeedWorks;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HRM_BE.Data.Repositories
{
    public class RemindWorkRepository:RepositoryBase<RemindWork,int>,IRemindWorkRepository
    {
        private readonly IMapper _mapper;
        public RemindWorkRepository(HrmContext context,IMapper mapper, IHttpContextAccessor httpContextAccessor):base(context,httpContextAccessor)
        {
            
        }
    }
}
