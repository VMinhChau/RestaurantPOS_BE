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
                .WithMany(u => u.Orders)
                .HasForeignKey(O => O.UserId);
            builder.HasOne(o => o.UserAdmin)
                .WithMany(u => u.OrdersSecond)
                .HasForeignKey(o => o.AdminId);
        }
    }
}
