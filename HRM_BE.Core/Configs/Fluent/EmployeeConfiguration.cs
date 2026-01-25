using HRM_BE.Core.Data.Staff;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HRM_BE.Core.Configs.Fluent
{
    public class EmployeeConfiguration : IEntityTypeConfiguration<Employee>
    {
        public void Configure(EntityTypeBuilder<Employee> builder)
        {
            builder.HasQueryFilter(x => x.IsDeleted == false);
            builder
                .HasOne(e => e.ManagerDirect)
                .WithOne()
                .HasForeignKey<Employee>(e => e.ManagerDirectId)
                .OnDelete(DeleteBehavior.SetNull);
            // Cấu hình quan hệ tự tham chiếu cho ManagerIndirect
            builder
                .HasOne(e => e.ManagerIndirect)
                .WithMany()
                .HasForeignKey(e => e.ManagerIndirectId)
                .OnDelete(DeleteBehavior.SetNull);

            // Cấu hình quan hệ tự tham chiếu cho EmployeeApprove
            builder
                .HasOne(e => e.EmployeeApprove)
                .WithMany()
                .HasForeignKey(e => e.EmployeeApproveId)
                .OnDelete(DeleteBehavior.SetNull);

            builder.
                HasOne(e => e.Company)
                .WithMany()
                .HasForeignKey(e => e.CompanyId)
                .OnDelete(DeleteBehavior.SetNull);

        }
    }
}
