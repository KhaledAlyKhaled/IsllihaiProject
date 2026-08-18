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
    public class ReviewConfigration : IEntityTypeConfiguration<Review>
    {
        public void Configure(EntityTypeBuilder<Review> builder)
        {

            builder.ToTable(x =>
             x.HasCheckConstraint("RangeConstraint", "Rating Between 1 and 5"));

            builder.Property(x => x.Comment)
                .HasMaxLength(500);

        }
    }
}
