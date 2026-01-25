using HRM_BE.Core.Data.Payroll_Timekeeping.LeaveRegulation;
using HRM_BE.Core.Models.Payroll_Timekeeping.LeaveRegulation;

namespace HRM_BE.Api.Mappers
{
    public class TypeOfLeaveMapper : AutoMapper.Profile
    {
        public TypeOfLeaveMapper()
        {
            CreateMap<CreateTypeOfLeaveRequest, TypeOfLeave>();
            CreateMap<UpdateTypeOfLeaveRequest, TypeOfLeave>();
            CreateMap<TypeOfLeave, TypeOfLeaveDto>().ReverseMap();
            CreateMap<TypeOfLeave, PagingTypeOfLeaveRequest>().ReverseMap();
        }
    }
}
