using AutoMapper;
using HRM_BE.Core.Data.Company;
using HRM_BE.Core.Data.Payroll_Timekeeping.Shift;
using HRM_BE.Core.Models.ShiftCatalog;

namespace HRM_BE.Api.Mappers
{
    public class ShiftCatalogMapper:Profile
    {
        public ShiftCatalogMapper()
        {
            CreateMap<CreateShiftCatalogRequest, ShiftCatalog>();
            CreateMap<UpdateShiftCatalogRequest, ShiftCatalog>();
            CreateMap<Organization, GetOrganizationShiftCatalogDto>().ReverseMap();
            CreateMap<ShiftCatalog,ShiftCatalogDto>().ReverseMap();
            CreateMap<ShiftWork, ShiftCatalogDto>().ReverseMap();
        }
    }
}
