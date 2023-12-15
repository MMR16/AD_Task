using Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Data.Configuration
{
    //public class DepartmentConfiguration : IEntityTypeConfiguration<Department>
    //{
    //    public void Configure(EntityTypeBuilder<Department> builder)
    //    {
    //        builder.HasKey(x => x.Id);
    //        builder.Property(e => e.Name).IsRequired().HasMaxLength(100);
    //        builder.Property(e => e.ManagerId).IsRequired(false).HasDefaultValue(null);
    //}
}
