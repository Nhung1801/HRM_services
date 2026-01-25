using AutoMapper;
using HRM_BE.Core.Data.ProfileEntity;
using HRM_BE.Core.Models.ProfileInfoModel;

namespace HRM_BE.Api.Mappers
{
    public class DeductionMapper:Profile
    {
        public DeductionMapper()
        {
            CreateMap<CreateDeductionRequest, Deduction>();
            CreateMap<UpdateDeductionRequest, Deduction>();
            CreateMap<Deduction, DeductionDto>();
        }
    }
}
