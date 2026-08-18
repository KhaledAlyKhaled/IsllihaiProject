using IsllihaiProjectDAL.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IsllihaiProjectDAL.Data.Configrations
{
    public class UserConfigration : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.Property(x => x.name)
                .IsRequired()
                .HasColumnType("varchar")
                .HasMaxLength(100);

            builder.Property(x => x.email)
                .IsRequired()
                .HasMaxLength(150);

            builder.ToTable(x =>
            x.HasCheckConstraint("EmailCheackConstraint", "email like '_%@_%._%'"));

            builder.HasIndex(x => x.email).IsUnique();

            builder.Property(x=>x.Phone)
                .IsRequired();

            builder.HasIndex(x=>x.Phone).IsUnique();

            builder.Property(x => x.Role)
                .IsRequired();

            
        }
    }
}
