using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using RestaurantPOS.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RestaurantPOS.Data.Configurations
{
    public class FavoriteFoodConfiguration : IEntityTypeConfiguration<FavoriteFood>
    {
        public void Configure(EntityTypeBuilder<FavoriteFood> builder)
        {
            builder.ToTable("FAVORITEFOOD");
            builder.HasOne(f => f.User)
                .WithMany(u => u.FavoriteFoods)
                .HasForeignKey(f => f.UserId)
                .IsRequired(false)
                .OnDelete(DeleteBehavior.SetNull);
            builder.HasOne(f => f.Food)
                .WithMany(f => f.FavoriteFoods)
                .HasForeignKey(f => f.FoodId)
                .IsRequired(false)
                .OnDelete(DeleteBehavior.SetNull);
        }
    }
}
