using HRM_BE.Core.Data;
using HRM_BE.Core.ISeedWorks;
using HRM_BE.Core.Models.PrefixConfig;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HRM_BE.Core.IRepositories
{
    public interface IPrefixConfigRepository:IRepositoryBase<PrefixConfig,int>
    {
        Task Create(CreatePrefixConfigRequest request);
        Task Update(int id, UpdatePrefixConfigRequest request);
        Task<string> GetAndUpdatePrefix(string key, string prefixFormat = "SMO");
        Task<PrefixConfigDto> GetByKey(string key);
    }
}
