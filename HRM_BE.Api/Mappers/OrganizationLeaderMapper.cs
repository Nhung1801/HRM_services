using AutoMapper;
using HRM_BE.Core.Data.Company;
using HRM_BE.Core.Models.Organization;

namespace HRM_BE.Api.Mappers
{
    public class OrganizationLeaderMapper:Profile
    {
        public OrganizationLeaderMapper()
        {
            CreateMap<CreateOrganizationLeaderRequest, OrganizationLeader>();
            CreateMap<OrganizationLeaderDto, OrganizationLeader>().ReverseMap();
        }
    }
}
