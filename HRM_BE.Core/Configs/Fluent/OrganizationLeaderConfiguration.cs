using HRM_BE.Core.Data.Company;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HRM_BE.Core.Configs.Fluent
{
    public class OrganizationLeaderConfiguration:IEntityTypeConfiguration<OrganizationLeader>
    {
        public void Configure(EntityTypeBuilder<OrganizationLeader> builder)
        {
            builder.HasOne( o => o.Organization)
                .WithMany( o => o.OrganizationLeaders)
                .HasForeignKey( o => o.OrganizationId )
                .OnDelete(DeleteBehavior.SetNull);

            builder.HasOne( oe => oe.Employee)
                .WithMany( oe => oe.OrganizationLeaders)
                .HasForeignKey( oe => oe.EmployeeId )
                .OnDelete(DeleteBehavior.SetNull);
        }
    }
}
