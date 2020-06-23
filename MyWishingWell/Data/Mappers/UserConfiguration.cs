using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MyWishingWell.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyWishingWell.Data.Mappers
{
    public class UserConfiguration : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.HasKey(c => c.UserId);
            builder.Property(c => c.UserId).ValueGeneratedOnAdd();
            builder
                .HasMany(u => u.WishList)
                .WithOne()
                .IsRequired()
                .HasForeignKey("UserId"); //Shadow property
            builder.Property(c => c.UserName).IsRequired().HasMaxLength(50);
            builder.Property(c => c.Email).IsRequired().HasMaxLength(100);
        }
    }
}
