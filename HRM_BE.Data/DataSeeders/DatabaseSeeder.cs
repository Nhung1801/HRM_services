using HRM_BE.Core.Data.Company;
using HRM_BE.Core.Data.Identity;
using HRM_BE.Core.Data.Staff;
using HRM_BE.Data.DataSeeders.Employee;
using HRM_BE.Data.DataSeeders.Identity;
using Microsoft.EntityFrameworkCore;

namespace HRM_BE.Data.DataSeeders
{
    public static class DatabaseSeeder
    {
        public static void Seed(this ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Role>().HasData(RoleSeeder.Data());
            modelBuilder.Entity<User>().HasData(UserSeeder.Data());
            modelBuilder.Entity<UserRole>().HasData(UserRoleSeeder.Data());
            modelBuilder.Entity<HRM_BE.Core.Data.Staff.Employee>().HasData(EmployeeSeeder.Data());
        }
    }
}
