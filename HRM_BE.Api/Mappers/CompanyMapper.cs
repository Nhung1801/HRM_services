using AutoMapper;
using HRM_BE.Core.Data.Company;
using HRM_BE.Core.Models.Company;
using HRM_BE.Core.Models.Identity.User;

namespace HRM_BE.Api.Mappers
{
    public class CompanyMapper:Profile
    {
        public CompanyMapper()
        {
            CreateMap<CreateCompanyRequest,Company>().ReverseMap();
            CreateMap<UpdateCompanyRequest,Company>().ReverseMap();
            CreateMap<Company, CompanyDto>();
            CreateMap<Company, UserCompanyDto>().ReverseMap();

        }
    }
}
