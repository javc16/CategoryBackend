using CategoryBackend.Category;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CategoryBackend.MyContext
{
    public class CategoryMap : IEntityTypeConfiguration<CategoryModel>
    {
        public void Configure(EntityTypeBuilder<CategoryModel> builder)
        {
            builder.ToTable("Category", "dbo");
            builder.HasKey(x => x.id);
            builder.Property(x => x.id).IsRequired().UseIdentityColumn();
            builder.Property(x => x.name).IsRequired();
            builder.Property(x => x.description).HasColumnType("varchar(max)");
            builder.Property(x => x.role).HasColumnType("varchar(max)");
            builder.Property(x => x.isActive);
        }
    }
}
