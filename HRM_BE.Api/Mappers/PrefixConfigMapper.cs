using AutoMapper;
using HRM_BE.Core.Data;
using HRM_BE.Core.Models.PrefixConfig;

namespace HRM_BE.Api.Mappers
{
    public class PrefixConfigMapper:Profile
    {
        public PrefixConfigMapper()
        {
            CreateMap<PrefixConfig,PrefixConfigDto>();
            CreateMap<CreatePrefixConfigRequest, PrefixConfig>();
            CreateMap<UpdatePrefixConfigRequest, PrefixConfig>();

        }
    }
}
