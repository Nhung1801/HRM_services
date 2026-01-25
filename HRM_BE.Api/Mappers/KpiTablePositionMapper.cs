using AutoMapper;
using HRM_BE.Core.Data.Salary;
using HRM_BE.Core.Data.Staff;
using HRM_BE.Core.Models.Salary.KpiTable;
using HRM_BE.Core.Models.Staff;

namespace HRM_BE.Api.Mappers
{
    public class KpiTablePositionMapper : Profile
    {
        public KpiTablePositionMapper()
        {

            CreateMap<CreateKpiTablePositionRequest, KpiTablePosition>();
            CreateMap<KpiTablePosition, KpiTablePositionDto>()
                .ForMember(dest => dest.PositionName, opt => opt.MapFrom(src => src.StaffPosition.PositionName));

            CreateMap<UpdateKpiTablePositionRequest, KpiTablePosition>();       
        }
    }
}
