using AutoMapper;
using HRM_BE.Core.Data;
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
    public class UserConnectionRepository:RepositoryBase<UserConnection,int>, IUserConnectionRepository
    {
        private readonly IMapper _mapper;
        public UserConnectionRepository(HrmContext context, IMapper mapper, IHttpContextAccessor httpContextAccessor):base(context, httpContextAccessor)
        {
            _mapper = mapper;
        }
    }
}
