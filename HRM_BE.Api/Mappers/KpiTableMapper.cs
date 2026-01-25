using AutoMapper;
using HRM_BE.Core.Data.Company;
using HRM_BE.Core.Data.Payroll_Timekeeping.Shift;
using HRM_BE.Core.Data.Salary;
using HRM_BE.Core.Models.Salary.KpiTable;

namespace HRM_BE.Api.Mappers
{
    public class KpiTableMapper : Profile
    {
        public KpiTableMapper()
        {
            CreateMap<CreateKpiTableRequest, KpiTable>();
            CreateMap<UpdateKpiTableRequest, KpiTable>();
            //CreateMap<KpiTable, KpiTableDto>().ForMember(dest => dest.OrganizationName, opt => opt.MapFrom(src => src.Organization.OrganizationName));
            CreateMap<KpiTable, KpiTableDto>()
                .ForMember(dest => dest.OrganizationName, opt => opt.MapFrom(src => src.Organization!.OrganizationName))
                .ForMember(dest => dest.KpiTableDetails, opt => opt.MapFrom(src => src.KpiTableDetails));

        }
    }
}
