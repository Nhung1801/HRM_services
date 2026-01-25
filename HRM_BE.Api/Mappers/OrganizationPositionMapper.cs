using AutoMapper;
using HRM_BE.Core.Data.Staff;
using HRM_BE.Core.Models.Staff;

namespace HRM_BE.Api.Mappers
{
    public class OrganizationPositionMapper:Profile
    {
        public OrganizationPositionMapper()
        {

            CreateMap<CreateOrganizationPositionRequest, OrganizationPosition>();
            CreateMap<OrganizationPosition,GetOranizationPositionDto>();
            CreateMap<UpdateOrganizationPositionRequest, OrganizationPosition>();
        }
    }
}
