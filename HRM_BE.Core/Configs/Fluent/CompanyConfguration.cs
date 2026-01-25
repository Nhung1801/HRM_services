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
    public class CompanyConfguration:IEntityTypeConfiguration<Company>
    {
        public void Configure(EntityTypeBuilder<Company> builder)
        {
            builder.HasQueryFilter( o => o.IsDeleted == false);

            builder.HasMany( c => c.Organizations)
                .WithOne( o => o.Company)
                .HasForeignKey( o => o.CompanyId )
                .OnDelete(DeleteBehavior.SetNull);
        }
    }
}
