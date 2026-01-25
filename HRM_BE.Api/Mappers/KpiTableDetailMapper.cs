using AutoMapper;
using HRM_BE.Core.Data.Salary;
using HRM_BE.Core.Models.Salary.KpiTable;
using HRM_BE.Core.Models.Salary.KpiTableDetail;

namespace HRM_BE.Api.Mappers
{
    public class KpiTableDetailMapper : Profile
    {
        public KpiTableDetailMapper()
        {
            CreateMap<CreateKpiTableDetailRequest, KpiTableDetail>();
            CreateMap<UpdateKpiTableDetailRequest, KpiTableDetail>();
            CreateMap<KpiTableDetail, KpiTableDetailDto>().ReverseMap();
            CreateMap<KpiTableDetail, KpiTableDetailDto>()
              .ForMember(dest => dest.EmployeeCode, opt => opt.MapFrom(src => src.Employee!.EmployeeCode));
        }
    }
}
