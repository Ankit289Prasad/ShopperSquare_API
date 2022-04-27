﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using ShopperSquare.DL;

namespace ShopperSquare.DL.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    [Migration("20220427104404_InitOrder")]
    partial class InitOrder
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.23")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("ShopperSquare.DL.Entities.Cart", b =>
                {
                    b.Property<int>("cartId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<decimal>("DiscountAmount")
                        .HasColumnType("decimal(18,4)");

                    b.Property<int>("ItemId")
                        .HasColumnType("int");

                    b.Property<int>("MRPAmount")
                        .HasColumnType("int");

                    b.Property<int>("UserId")
                        .HasColumnType("int");

                    b.Property<int>("itemCount")
                        .HasColumnType("int");

                    b.HasKey("cartId");

                    b.ToTable("Carts");
                });

            modelBuilder.Entity("ShopperSquare.DL.Entities.Category", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Categories");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Description = "Test",
                            Name = "Books"
                        },
                        new
                        {
                            Id = 2,
                            Description = "Test",
                            Name = "Games"
                        },
                        new
                        {
                            Id = 3,
                            Description = "Test",
                            Name = "Tools"
                        },
                        new
                        {
                            Id = 4,
                            Description = "Test",
                            Name = "Mobiles"
                        },
                        new
                        {
                            Id = 5,
                            Description = "Test",
                            Name = "Laptops"
                        });
                });

            modelBuilder.Entity("ShopperSquare.DL.Entities.Item", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("CategoryId")
                        .HasColumnType("int");

                    b.Property<int>("DiscountPercentage")
                        .HasColumnType("int");

                    b.Property<string>("Image")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("InStock")
                        .HasColumnType("bit");

                    b.Property<string>("InventoryId")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("MRPAmount")
                        .HasColumnType("int");

                    b.Property<int>("MaxOrderAmount")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("CategoryId");

                    b.ToTable("Items");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            CategoryId = 4,
                            DiscountPercentage = 10,
                            Image = "oppo1.png",
                            InStock = true,
                            InventoryId = "Mob-oppo-1",
                            MRPAmount = 15999,
                            MaxOrderAmount = 3,
                            Name = "Oppo Reno 6"
                        },
                        new
                        {
                            Id = 2,
                            CategoryId = 4,
                            DiscountPercentage = 10,
                            Image = "vivo1.png",
                            InStock = true,
                            InventoryId = "Mob-vivo-1",
                            MRPAmount = 15999,
                            MaxOrderAmount = 3,
                            Name = "Vivo X"
                        },
                        new
                        {
                            Id = 3,
                            CategoryId = 4,
                            DiscountPercentage = 10,
                            Image = "samsung1.png",
                            InStock = true,
                            InventoryId = "Mob-Sam-1",
                            MRPAmount = 15999,
                            MaxOrderAmount = 3,
                            Name = "Samsung M31"
                        },
                        new
                        {
                            Id = 4,
                            CategoryId = 4,
                            DiscountPercentage = 10,
                            Image = "IPhone1.png",
                            InStock = true,
                            InventoryId = "Mob-iphone-1",
                            MRPAmount = 15999,
                            MaxOrderAmount = 3,
                            Name = "Iphone 13 Max pro"
                        });
                });

            modelBuilder.Entity("ShopperSquare.DL.Entities.Orders", b =>
                {
                    b.Property<int>("OrderId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<decimal>("DiscountAmount")
                        .HasColumnType("decimal(18,4)");

                    b.Property<string>("Image")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("MRPAmount")
                        .HasColumnType("int");

                    b.Property<string>("ProductName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Quantity")
                        .HasColumnType("int");

                    b.Property<int>("UserId")
                        .HasColumnType("int");

                    b.HasKey("OrderId");

                    b.ToTable("Orders");
                });

            modelBuilder.Entity("ShopperSquare.DL.Entities.User", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("Age")
                        .HasColumnType("int");

                    b.Property<DateTime>("DateOfBirth")
                        .HasColumnType("datetime2");

                    b.Property<string>("EmailId")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(102)")
                        .HasMaxLength(102);

                    b.Property<string>("Password")
                        .HasColumnType("nvarchar(20)")
                        .HasMaxLength(20);

                    b.HasKey("Id");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("ShopperSquare.DL.Entities.Item", b =>
                {
                    b.HasOne("ShopperSquare.DL.Entities.Category", "Category")
                        .WithMany("Items")
                        .HasForeignKey("CategoryId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}
