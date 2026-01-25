using AutoMapper;
using HRM_BE.Core.Data.Company;
using HRM_BE.Core.Data.Payroll_Timekeeping.Shift;
using HRM_BE.Core.Models.ShiftWork;

namespace HRM_BE.Api.Mappers
{
    public class ShiftWorkMapper:Profile
    {
        public ShiftWorkMapper()
        {
            CreateMap<CreateShiftWorkRequest,ShiftWork>();
            CreateMap<UpdateShiftWorkRequest,ShiftWork>();
            CreateMap<ShiftWork,ShiftWorkDto>().ReverseMap();
            CreateMap<Organization, GetOrganizationShiftWorkDto>();
        }
    }
}
