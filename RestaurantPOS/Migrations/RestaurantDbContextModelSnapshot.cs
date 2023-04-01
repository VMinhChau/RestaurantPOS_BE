﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using RestaurantPOS.Data;

#nullable disable

namespace RestaurantPOS.Migrations
{
    [DbContext(typeof(RestaurantDbContext))]
    partial class RestaurantDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.4")
                .HasAnnotation("Proxies:ChangeTracking", false)
                .HasAnnotation("Proxies:CheckEquality", false)
                .HasAnnotation("Proxies:LazyLoading", true)
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("RestaurantPOS.Data.Entities.Category", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("id");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar")
                        .HasColumnName("Name");

                    b.HasKey("Id");

                    b.ToTable("CATEGORY", (string)null);
                });

            modelBuilder.Entity("RestaurantPOS.Data.Entities.Comment", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("id");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Content")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("content");

                    b.Property<int?>("FoodId")
                        .HasColumnType("int")
                        .HasColumnName("foodId");

                    b.Property<float>("Rating")
                        .HasColumnType("real")
                        .HasColumnName("rating");

                    b.Property<int?>("UserId")
                        .HasColumnType("int")
                        .HasColumnName("userId");

                    b.HasKey("Id");

                    b.HasIndex("FoodId");

                    b.HasIndex("UserId");

                    b.ToTable("COMMENT", (string)null);
                });

            modelBuilder.Entity("RestaurantPOS.Data.Entities.FavoriteFood", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("id");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int?>("FoodId")
                        .HasColumnType("int")
                        .HasColumnName("foodId");

                    b.Property<int?>("UserId")
                        .HasColumnType("int")
                        .HasColumnName("userId");

                    b.HasKey("Id");

                    b.HasIndex("FoodId");

                    b.HasIndex("UserId");

                    b.ToTable("FAVORITEFOOD", (string)null);
                });

            modelBuilder.Entity("RestaurantPOS.Data.Entities.Food", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("id");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<float>("AverageRating")
                        .HasColumnType("real")
                        .HasColumnName("averageRating");

                    b.Property<int?>("CategoryId")
                        .HasColumnType("int")
                        .HasColumnName("categoryId");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasMaxLength(2000)
                        .HasColumnType("nvarchar")
                        .HasColumnName("description");

                    b.Property<string>("Image")
                        .IsRequired()
                        .HasMaxLength(200)
                        .HasColumnType("nvarchar")
                        .HasColumnName("image");

                    b.Property<bool>("IsPromote")
                        .HasColumnType("bit")
                        .HasColumnName("isPromote");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar")
                        .HasColumnName("name");

                    b.Property<decimal>("Price")
                        .HasColumnType("decimal")
                        .HasColumnName("price");

                    b.HasKey("Id");

                    b.HasIndex("CategoryId");

                    b.ToTable("FOOD", (string)null);
                });

            modelBuilder.Entity("RestaurantPOS.Data.Entities.Order", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("id");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int?>("AdminId")
                        .HasColumnType("int")
                        .HasColumnName("adminId");

                    b.Property<string>("CreateAt")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("createAt");

                    b.Property<int?>("PurcharseId")
                        .HasColumnType("int")
                        .HasColumnName("purcharseId");

                    b.Property<int>("Status")
                        .HasMaxLength(50)
                        .HasColumnType("int")
                        .HasColumnName("status");

                    b.Property<float>("TotalPrice")
                        .HasColumnType("real")
                        .HasColumnName("totalPrice");

                    b.Property<string>("UpdateAt")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("updateAt");

                    b.Property<int?>("UserId")
                        .IsRequired()
                        .HasColumnType("int")
                        .HasColumnName("userId");

                    b.HasKey("Id");

                    b.HasIndex("AdminId");

                    b.HasIndex("UserId");

                    b.ToTable("ORDER", (string)null);
                });

            modelBuilder.Entity("RestaurantPOS.Data.Entities.OrderItem", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("id");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<float>("CurrrentPrice")
                        .HasColumnType("real")
                        .HasColumnName("currrentPrice");

                    b.Property<int?>("FoodId")
                        .HasColumnType("int")
                        .HasColumnName("foodId");

                    b.Property<int?>("OrderId")
                        .HasColumnType("int")
                        .HasColumnName("orderId");

                    b.Property<int>("Quatity")
                        .HasColumnType("int")
                        .HasColumnName("quatity");

                    b.Property<int>("Status")
                        .HasColumnType("int")
                        .HasColumnName("status");

                    b.HasKey("Id");

                    b.HasIndex("FoodId");

                    b.HasIndex("OrderId");

                    b.ToTable("ORDERITEM", (string)null);
                });

            modelBuilder.Entity("RestaurantPOS.Data.Entities.User", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("id");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Address")
                        .IsRequired()
                        .HasMaxLength(200)
                        .HasColumnType("nvarchar(200)")
                        .HasColumnName("address");

                    b.Property<string>("DateOfBirth")
                        .IsRequired()
                        .HasMaxLength(8)
                        .HasColumnType("nvarchar(8)")
                        .HasColumnName("dateOfBirth");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)")
                        .HasColumnName("email");

                    b.Property<string>("EncryptedPassword")
                        .IsRequired()
                        .HasMaxLength(200)
                        .HasColumnType("nvarchar(200)")
                        .HasColumnName("encryptedPassword");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)")
                        .HasColumnName("firstName");

                    b.Property<int>("Gender")
                        .HasMaxLength(10)
                        .HasColumnType("int")
                        .HasColumnName("gender");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)")
                        .HasColumnName("lastName");

                    b.Property<string>("PhoneNumber")
                        .IsRequired()
                        .HasMaxLength(10)
                        .HasColumnType("nvarchar(10)")
                        .HasColumnName("phoneNumber");

                    b.Property<int>("Points")
                        .HasColumnType("int")
                        .HasColumnName("points");

                    b.Property<int>("Rank")
                        .HasMaxLength(50)
                        .HasColumnType("int")
                        .HasColumnName("rank");

                    b.Property<int>("Role")
                        .HasMaxLength(50)
                        .HasColumnType("int")
                        .HasColumnName("role");

                    b.HasKey("Id");

                    b.ToTable("USER", (string)null);
                });

            modelBuilder.Entity("RestaurantPOS.Data.Entities.Comment", b =>
                {
                    b.HasOne("RestaurantPOS.Data.Entities.Food", "Food")
                        .WithMany("Comments")
                        .HasForeignKey("FoodId")
                        .OnDelete(DeleteBehavior.SetNull);

                    b.HasOne("RestaurantPOS.Data.Entities.User", "User")
                        .WithMany("Comments")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.SetNull);

                    b.Navigation("Food");

                    b.Navigation("User");
                });

            modelBuilder.Entity("RestaurantPOS.Data.Entities.FavoriteFood", b =>
                {
                    b.HasOne("RestaurantPOS.Data.Entities.Food", "Food")
                        .WithMany("FavoriteFoods")
                        .HasForeignKey("FoodId")
                        .OnDelete(DeleteBehavior.SetNull);

                    b.HasOne("RestaurantPOS.Data.Entities.User", "User")
                        .WithMany("FavoriteFoods")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.SetNull);

                    b.Navigation("Food");

                    b.Navigation("User");
                });

            modelBuilder.Entity("RestaurantPOS.Data.Entities.Food", b =>
                {
                    b.HasOne("RestaurantPOS.Data.Entities.Category", "Category")
                        .WithMany("Foods")
                        .HasForeignKey("CategoryId")
                        .OnDelete(DeleteBehavior.SetNull);

                    b.Navigation("Category");
                });

            modelBuilder.Entity("RestaurantPOS.Data.Entities.Order", b =>
                {
                    b.HasOne("RestaurantPOS.Data.Entities.User", "UserAdmin")
                        .WithMany("OrdersSecond")
                        .HasForeignKey("AdminId");

                    b.HasOne("RestaurantPOS.Data.Entities.User", "User")
                        .WithMany("Orders")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("User");

                    b.Navigation("UserAdmin");
                });

            modelBuilder.Entity("RestaurantPOS.Data.Entities.OrderItem", b =>
                {
                    b.HasOne("RestaurantPOS.Data.Entities.Food", "Food")
                        .WithMany("OrderItems")
                        .HasForeignKey("FoodId")
                        .OnDelete(DeleteBehavior.SetNull);

                    b.HasOne("RestaurantPOS.Data.Entities.Order", "Order")
                        .WithMany("OrderItems")
                        .HasForeignKey("OrderId")
                        .OnDelete(DeleteBehavior.SetNull);

                    b.Navigation("Food");

                    b.Navigation("Order");
                });

            modelBuilder.Entity("RestaurantPOS.Data.Entities.Category", b =>
                {
                    b.Navigation("Foods");
                });

            modelBuilder.Entity("RestaurantPOS.Data.Entities.Food", b =>
                {
                    b.Navigation("Comments");

                    b.Navigation("FavoriteFoods");

                    b.Navigation("OrderItems");
                });

            modelBuilder.Entity("RestaurantPOS.Data.Entities.Order", b =>
                {
                    b.Navigation("OrderItems");
                });

            modelBuilder.Entity("RestaurantPOS.Data.Entities.User", b =>
                {
                    b.Navigation("Comments");

                    b.Navigation("FavoriteFoods");

                    b.Navigation("Orders");

                    b.Navigation("OrdersSecond");
                });
#pragma warning restore 612, 618
        }
    }
}
