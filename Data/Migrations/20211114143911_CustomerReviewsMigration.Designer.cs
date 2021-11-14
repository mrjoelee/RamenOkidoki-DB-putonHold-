﻿// <auto-generated />
using System;
using Data.DbContext;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace Data.Migrations
{
    [DbContext(typeof(RestaurantDbContext))]
    [Migration("20211114143911_CustomerReviewsMigration")]
    partial class CustomerReviewsMigration
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.0")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("Data.Models.CustomerReview", b =>
                {
                    b.Property<int>("ReviewId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ReviewId"), 1L, 1);

                    b.Property<int>("Rating")
                        .HasColumnType("int");

                    b.Property<string>("ReviewDate")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ReviewString")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ReviewerName")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("ReviewId");

                    b.ToTable("CustomerReviews");
                });

            modelBuilder.Entity("Data.Models.DashboardData.AddOnCharges", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<decimal>("DeliveryCharge")
                        .HasColumnType("decimal(18,2)");

                    b.Property<decimal>("SalesTaxRate")
                        .HasColumnType("decimal(18,2)");

                    b.HasKey("Id");

                    b.ToTable("AddOns");
                });

            modelBuilder.Entity("Data.Models.DashboardData.BusinessLocation", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("BusinessName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("City")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Email")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PhoneNumber")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("SocialId")
                        .HasColumnType("int");

                    b.Property<string>("State")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("StreetAddress")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Zipcode")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("SocialId");

                    b.ToTable("BusinessLocations");
                });

            modelBuilder.Entity("Data.Models.DashboardData.HoursOfOperation", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("FridayClose")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("FridayOpen")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("MondayClose")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("MondayOpen")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("SaturdayClose")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("SaturdayOpen")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("SundayClose")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("SundayOpen")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ThursdayClose")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ThursdayOpen")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("TuesdayClose")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("TuesdayOpen")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("WednesdayClose")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("WednesdayOpen")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("BusinessHours");
                });

            modelBuilder.Entity("Data.Models.DashboardData.SocialPlatforms", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("FacebookUrl")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("InstagramUrl")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("TwitterUrl")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("YelpUrl")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("SocialPlatforms");
                });

            modelBuilder.Entity("Data.Models.FoodMenus.FoodCategory", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("Category")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("FoodCategories");
                });

            modelBuilder.Entity("Data.Models.FoodMenus.FoodItem", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("Discriminator")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("dishName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("foodCategory")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("foodCategoryId")
                        .HasColumnType("int");

                    b.Property<string>("price")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("FoodItems");

                    b.HasDiscriminator<string>("Discriminator").HasValue("FoodItem");
                });

            modelBuilder.Entity("Data.Models.TakeOuts.Customer", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("Address")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("City")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PhoneNumber")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("State")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ZipCode")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Customers");
                });

            modelBuilder.Entity("Data.Models.TakeOuts.FoodOrder", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<decimal>("OrderSubTotalCost")
                        .HasColumnType("decimal(18,2)");

                    b.Property<int>("OrderTotalItems")
                        .HasColumnType("int");

                    b.Property<int?>("TakeOutCustomerId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("TakeOutCustomerId");

                    b.ToTable("FoodOrders");
                });

            modelBuilder.Entity("Data.Models.FoodMenus.OrderItem", b =>
                {
                    b.HasBaseType("Data.Models.FoodMenus.FoodItem");

                    b.Property<int?>("FoodOrderId")
                        .HasColumnType("int");

                    b.Property<int>("quantity")
                        .HasColumnType("int");

                    b.HasIndex("FoodOrderId");

                    b.HasDiscriminator().HasValue("OrderItem");
                });

            modelBuilder.Entity("Data.Models.DashboardData.BusinessLocation", b =>
                {
                    b.HasOne("Data.Models.DashboardData.SocialPlatforms", "Social")
                        .WithMany()
                        .HasForeignKey("SocialId");

                    b.Navigation("Social");
                });

            modelBuilder.Entity("Data.Models.TakeOuts.FoodOrder", b =>
                {
                    b.HasOne("Data.Models.TakeOuts.Customer", "TakeOutCustomer")
                        .WithMany()
                        .HasForeignKey("TakeOutCustomerId");

                    b.Navigation("TakeOutCustomer");
                });

            modelBuilder.Entity("Data.Models.FoodMenus.OrderItem", b =>
                {
                    b.HasOne("Data.Models.TakeOuts.FoodOrder", null)
                        .WithMany("FoodOrderItemList")
                        .HasForeignKey("FoodOrderId");
                });

            modelBuilder.Entity("Data.Models.TakeOuts.FoodOrder", b =>
                {
                    b.Navigation("FoodOrderItemList");
                });
#pragma warning restore 612, 618
        }
    }
}
