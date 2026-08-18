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
    public class TechnicanConfigration : IEntityTypeConfiguration<Technican>
    {
        public void Configure(EntityTypeBuilder<Technican> builder)
        {
            builder.Property(x => x.YearsOfExperience)
                .IsRequired()
                ;
            builder.ToTable(x =>
             x.HasCheckConstraint("RangeConstraint", "YearsOfExperience Between 0 and 20"));

            builder.HasOne(x => x.User)
     .WithOne(x => x.Technican)
     .HasForeignKey<Technican>(x => x.UserId)
     .OnDelete(DeleteBehavior.Cascade);

            builder.Property(x => x.UserId)
                .IsRequired();

            builder.HasIndex(x => x.UserId).IsUnique();
            builder.Property(x => x.CategoryId)
                .IsRequired();

            builder.HasOne(t => t.Category)
                .WithMany(c => c.Technicans) 
                .HasForeignKey(t => t.CategoryId)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
