using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using RestaurantPOS.Data.Entities;

namespace RestaurantPOS.Data.Configurations
{
    public class FavoriteFoodConfiguration : IEntityTypeConfiguration<FavoriteFood>
    {
        public void Configure(EntityTypeBuilder<FavoriteFood> builder)
        {
            builder.ToTable("FAVORITE_FOOD");
            builder.HasKey(c => c.Id);
            builder.HasOne<User>()
                .WithMany()
                .HasForeignKey("UserId")
                .OnDelete(DeleteBehavior.Cascade)
                .IsRequired();
            builder.HasOne<Food>()
                .WithMany()
                .HasForeignKey("FoodId")
                .OnDelete(DeleteBehavior.Cascade)
                .IsRequired();
        }
    }
}
