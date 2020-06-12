using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MyWishingWell.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyWishingWell.Data.Mappers
{
    public class WishListItemConfiguration : IEntityTypeConfiguration<WishListItem>
    {
        public void Configure(EntityTypeBuilder<WishListItem> builder)
        {
            builder.HasKey(p => p.WishListItemId);
            builder.Property(p => p.WishListItemId).ValueGeneratedOnAdd();
            builder.Property(r => r.WishListItemName).IsRequired().HasMaxLength(50);
            builder.Property(r => r.Link).IsRequired();
        }
    }
}
