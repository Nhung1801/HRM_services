using HRM_BE.Core.Data.Identity;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HRM_BE.Data.DataSeeders.Employee
{
    public static class EmployeeSeeder
    {
        public static List<HRM_BE.Core.Data.Staff.Employee> Data()
        {
            var employees = new List<HRM_BE.Core.Data.Staff.Employee>()
            {
                new HRM_BE.Core.Data.Staff.Employee
                {
                    Id = 1,
                    EmployeeCode="SMO0001",
                    LastName="Master",
                    FirstName="Admin",
                    AccountStatus=Core.Data.Staff.AccountStatus.Active,
                    WorkingStatus=Core.Data.Staff.WorkingStatus.Active,
                    AccountEmail="adminmaster@gmail.com",
                    AvatarUrl = "/Image/Avatar/AvatarDefault.png",
                    IsDeleted=false,
                    
                },
            };
            return employees;

        }

    }
}
