using HRM_BE.Core.Data.Identity;
using HRM_BE.Core.Models.Identity.Permission;
using HRM_BE.Core.Models.Identity.Role;
using HRM_BE.Core.Models.Identity.User;
using AutoMapper;

namespace HRM_BE.Api.Mappers
{
    public class UserMapper  : Profile
    {
        public UserMapper()
        {

            CreateMap<CreateUserRequest, User>();
            CreateMap<EditUserInfoRequest, User>();
            CreateMap<User, UserDto>();
            CreateMap<UserDto, User>();
       

        }
    }
}
