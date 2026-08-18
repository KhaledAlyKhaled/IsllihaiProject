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
    public class BookingConfigration : IEntityTypeConfiguration<Booking>
    {
        public void Configure(EntityTypeBuilder<Booking> builder)
        {
            builder.Property(x => x.Description)
                .IsRequired()
                .HasMaxLength(500);

            builder.Property(x => x.Address)
                .IsRequired()
                .HasMaxLength(250);

            builder.Property(x => x.OrderedAt)
                .IsRequired();

            builder.Property(x => x.Status)
                .HasConversion<string>();

            builder.HasOne(b => b.User)
                .WithMany(u => u.Bookings)
                .HasForeignKey(b => b.UserId)
                .OnDelete(DeleteBehavior.Restrict);

            builder.HasOne(b => b.Technican)
                   .WithMany(t => t.Bookings)
                   .HasForeignKey(b => b.TechnicanId)
                   .OnDelete(DeleteBehavior.SetNull);   

            builder.HasOne(b => b.Category)
                   .WithMany(c => c.Bookings)
                   .HasForeignKey(b => b.CategoryId)
                   .OnDelete(DeleteBehavior.Restrict);

            builder.HasOne(b => b.Review)
                   .WithOne(r => r.Booking)           
                   .HasForeignKey<Review>(r => r.BookingId);

        }
    }
}
