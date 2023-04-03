using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using RestaurantPOS.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RestaurantPOS.Data.Configurations
{
    public class OrderConfiguration : IEntityTypeConfiguration<Order>
    {
        public void Configure(EntityTypeBuilder<Order> builder)
        {
            builder.ToTable("ORDER");
            builder.HasOne(o => o.User)
                .WithMany(u => u.OrdersUser)
                .HasForeignKey(O => O.UserId)
                .OnDelete(DeleteBehavior.NoAction);
            builder.HasOne(o => o.Admin)
                .WithMany(u => u.OrdersAdmin)
                .HasForeignKey(o => o.AdminId)
                .OnDelete(DeleteBehavior.NoAction);
        }
    }
}
