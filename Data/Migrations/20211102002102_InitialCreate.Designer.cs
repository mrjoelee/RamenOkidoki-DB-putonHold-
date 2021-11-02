﻿// <auto-generated />
using System;
using Data.DbContext;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace Data.Migrations
{
    [DbContext(typeof(RestaurantDbContext))]
    [Migration("20211102002102_InitialCreate")]
    partial class InitialCreate
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.11")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Data.Models.DashboardData.BusinessLocation", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

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
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

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
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

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
                    b.Property<string>("id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("CategoryName")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("id");

                    b.ToTable("FoodCategories");
                });

            modelBuilder.Entity("Data.Models.FoodMenus.FoodMenu+FoodItem", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("FoodCategoryid")
                        .HasColumnType("nvarchar(450)");

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

                    b.HasIndex("FoodCategoryid");

                    b.ToTable("FoodItems");
                });

            modelBuilder.Entity("Data.Models.DashboardData.BusinessLocation", b =>
                {
                    b.HasOne("Data.Models.DashboardData.SocialPlatforms", "Social")
                        .WithMany()
                        .HasForeignKey("SocialId");

                    b.Navigation("Social");
                });

            modelBuilder.Entity("Data.Models.FoodMenus.FoodMenu+FoodItem", b =>
                {
                    b.HasOne("Data.Models.FoodMenus.FoodCategory", null)
                        .WithMany("FoodItems")
                        .HasForeignKey("FoodCategoryid");
                });

            modelBuilder.Entity("Data.Models.FoodMenus.FoodCategory", b =>
                {
                    b.Navigation("FoodItems");
                });
#pragma warning restore 612, 618
        }
    }
}
