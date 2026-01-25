using AutoMapper;
using HRM_BE.Core.Data.Payroll_Timekeeping.LeaveRegulation;
using HRM_BE.Core.Models.Payroll_Timekeeping.LeaveRegulation;

namespace HRM_BE.Api.Mappers
{
    public class TypeOfLeaveEmployeeMapper:Profile
    {
        public TypeOfLeaveEmployeeMapper()
        {
            CreateMap<TypeOfLeaveEmployee, TypeOfLeaveEmployeeDto>().ReverseMap();
            CreateMap<TypeOfLeaveEmployee, GetTypeOfLeaveEmployeeRequest>().ReverseMap();

        }
    }
}
