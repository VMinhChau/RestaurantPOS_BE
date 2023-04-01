﻿using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using RestaurantPOS.Data.Entities;

namespace RestaurantPOS.Data.Configurations
{
    public class FoodConfiguration : IEntityTypeConfiguration<Food>
    {
        public void Configure(EntityTypeBuilder<Food> builder)
        {
            builder.ToTable("FOOD");
            builder.HasKey(f => f.Id);
            builder.Property(f => f.Name).HasMaxLength(200).IsUnicode().IsRequired();
            builder.Property(f => f.Description).IsUnicode().HasDefaultValue("None.");
            builder.Property(f => f.ImageLink).IsRequired();
        }
    }
}
