using HRM_BE.Core.Data.Identity;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HRM_BE.Data.DataSeeders.Identity
{
    public static class UserSeeder
    {
        public static List<User> Data()
        {
            var hasher = new PasswordHasher<User>();
            var users = new List<User>()
            {
                new User
                {
                    Id = 1,
                    UserName = "adminmaster@gmail.com",
                    NormalizedUserName = "adminmaster@gmail.com",
                    Email = "adminmaster@gmail.com",
                    NormalizedEmail = "adminmaster@gmail.com",
                    EmailConfirmed = true,
                    PasswordHash = hasher.HashPassword(null!, "adminmaster"),
                    SecurityStamp = string.Empty,
                    Name = "Admin-Master",
                    AvatarUrl = "/Image/Avatar/AvatarDefault.png",
                    PhoneNumber="0988888888",
                    Status = true,
                    IsActivated=true,
                    IsLockAccount=false,
                    Sex=1,
                    Address="Tân Lập-Yên Mỹ-Hưng Yên",
                    BirthDay=DateTime.Parse("01-01-2000"),
                    EmployeeId=1,
                },
            };
            return users;

        }

    }
}
