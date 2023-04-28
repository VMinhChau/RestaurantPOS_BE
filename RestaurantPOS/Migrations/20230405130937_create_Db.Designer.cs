﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using RestaurantPOS.Data;

#nullable disable

namespace RestaurantPOS.Migrations
{
    [DbContext(typeof(RestaurantDbContext))]
    [Migration("20230405130937_create_Db")]
    partial class create_Db
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.3")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("RestaurantPOS.Data.Entities.Banner", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("ImageLink")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("BANNER", (string)null);
                });

            modelBuilder.Entity("RestaurantPOS.Data.Entities.Category", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("CATEGORY", (string)null);
                });

            modelBuilder.Entity("RestaurantPOS.Data.Entities.Comment", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Content")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("FoodId")
                        .HasColumnType("int");

                    b.Property<int>("Rating")
                        .HasColumnType("int");

                    b.Property<Guid>("UserId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("Id");

                    b.HasIndex("FoodId");

                    b.HasIndex("UserId");

                    b.ToTable("COMMENT", (string)null);
                });

            modelBuilder.Entity("RestaurantPOS.Data.Entities.FavoriteFood", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("FoodId")
                        .HasColumnType("int");

                    b.Property<Guid>("UserId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("Id");

                    b.HasIndex("FoodId");

                    b.HasIndex("UserId");

                    b.ToTable("FAVORITE_FOOD", (string)null);
                });

            modelBuilder.Entity("RestaurantPOS.Data.Entities.Food", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("CategoryId")
                        .HasColumnType("int");

                    b.Property<string>("Description")
                        .IsRequired()
                        .ValueGeneratedOnAdd()
                        .IsUnicode(true)
                        .HasColumnType("nvarchar(max)")
                        .HasDefaultValue("None.");

                    b.Property<string>("ImageLink")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("IsPromotion")
                        .HasColumnType("bit");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(200)
                        .IsUnicode(true)
                        .HasColumnType("nvarchar(200)");

                    b.Property<double>("Price")
                        .HasColumnType("float");

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

                    b.Property<Guid?>("AdminId")
                        .IsRequired()
                        .HasColumnType("uniqueidentifier")
                        .HasColumnName("adminId");

                    b.Property<DateTime>("CreateAt")
                        .HasColumnType("datetime2")
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

                    b.Property<DateTime?>("UpdateAt")
                        .HasColumnType("datetime2")
                        .HasColumnName("updateAt");

                    b.Property<Guid>("UserId")
                        .HasColumnType("uniqueidentifier")
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

                    b.Property<int>("FoodId")
                        .HasColumnType("int")
                        .HasColumnName("foodId");

                    b.Property<int>("OrderId")
                        .HasColumnType("int")
                        .HasColumnName("orderId");

                    b.Property<int>("Quatity")
                        .HasColumnType("int")
                        .HasColumnName("quatity");

                    b.Property<int>("Status")
                        .HasMaxLength(100)
                        .HasColumnType("int")
                        .HasColumnName("status");

                    b.HasKey("Id");

                    b.HasIndex("FoodId");

                    b.HasIndex("OrderId");

                    b.ToTable("ORDERITEM", (string)null);
                });

            modelBuilder.Entity("RestaurantPOS.Data.Entities.User", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("Birthday")
                        .HasColumnType("datetime2");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("Gender")
                        .HasColumnType("bit");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PasswordHash")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PhoneNumber")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<double?>("Points")
                        .HasColumnType("float");

                    b.Property<int?>("Ranking")
                        .HasColumnType("int");

                    b.Property<string>("UserName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("USER", (string)null);
                });

            modelBuilder.Entity("RestaurantPOS.Data.Entities.Comment", b =>
                {
                    b.HasOne("RestaurantPOS.Data.Entities.Food", null)
                        .WithMany("Comments")
                        .HasForeignKey("FoodId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("RestaurantPOS.Data.Entities.User", "User")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("User");
                });

            modelBuilder.Entity("RestaurantPOS.Data.Entities.FavoriteFood", b =>
                {
                    b.HasOne("RestaurantPOS.Data.Entities.Food", null)
                        .WithMany()
                        .HasForeignKey("FoodId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("RestaurantPOS.Data.Entities.User", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("RestaurantPOS.Data.Entities.Food", b =>
                {
                    b.HasOne("RestaurantPOS.Data.Entities.Category", null)
                        .WithMany("Foods")
                        .HasForeignKey("CategoryId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("RestaurantPOS.Data.Entities.Order", b =>
                {
                    b.HasOne("RestaurantPOS.Data.Entities.User", "Admin")
                        .WithMany("OrdersAdmin")
                        .HasForeignKey("AdminId")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.HasOne("RestaurantPOS.Data.Entities.User", "User")
                        .WithMany("OrdersUser")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.Navigation("Admin");

                    b.Navigation("User");
                });

            modelBuilder.Entity("RestaurantPOS.Data.Entities.OrderItem", b =>
                {
                    b.HasOne("RestaurantPOS.Data.Entities.Food", "Food")
                        .WithMany("OrderItems")
                        .HasForeignKey("FoodId")
                        .OnDelete(DeleteBehavior.NoAction);

                    b.HasOne("RestaurantPOS.Data.Entities.Order", "Order")
                        .WithMany("OrderItems")
                        .HasForeignKey("OrderId")
                        .OnDelete(DeleteBehavior.NoAction);

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

                    b.Navigation("OrderItems");
                });

            modelBuilder.Entity("RestaurantPOS.Data.Entities.Order", b =>
                {
                    b.Navigation("OrderItems");
                });

            modelBuilder.Entity("RestaurantPOS.Data.Entities.User", b =>
                {
                    b.Navigation("OrdersAdmin");

                    b.Navigation("OrdersUser");
                });
#pragma warning restore 612, 618
        }
    }
}
