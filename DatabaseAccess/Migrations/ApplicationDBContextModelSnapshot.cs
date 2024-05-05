﻿// <auto-generated />
using System;
using DatabaseAccess;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace DatabaseAccess.Migrations
{
    [DbContext(typeof(ApplicationDBContext))]
    partial class ApplicationDBContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.1")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRole", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<string>("NormalizedName")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.HasKey("Id");

                    b.HasIndex("NormalizedName")
                        .IsUnique()
                        .HasDatabaseName("RoleNameIndex")
                        .HasFilter("[NormalizedName] IS NOT NULL");

                    b.ToTable("tbl_Roles", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("ClaimType")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("RoleId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Id");

                    b.HasIndex("RoleId");

                    b.ToTable("tbl_RoleClaims", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("ClaimType")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("tbl_UserClaims", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.Property<string>("LoginProvider")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("ProviderKey")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("ProviderDisplayName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("LoginProvider", "ProviderKey");

                    b.HasIndex("UserId");

                    b.ToTable("tbl_UserLogins", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.Property<string>("UserId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("RoleId")
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("UserId", "RoleId");

                    b.HasIndex("RoleId");

                    b.ToTable("tbl_UserRoles", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.Property<string>("UserId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("LoginProvider")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Value")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("UserId", "LoginProvider", "Name");

                    b.ToTable("tbl_UserTokens", (string)null);
                });

            modelBuilder.Entity("Model.Amenity", b =>
                {
                    b.Property<int>("AmenityId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("AmenityId"));

                    b.Property<string>("AmenityName")
                        .IsRequired()
                        .HasMaxLength(200)
                        .HasColumnType("nvarchar(200)");

                    b.HasKey("AmenityId");

                    b.ToTable("tbl_Amenity");

                    b.HasData(
                        new
                        {
                            AmenityId = 1,
                            AmenityName = "Washing Machine"
                        },
                        new
                        {
                            AmenityId = 2,
                            AmenityName = "Electric Fan"
                        },
                        new
                        {
                            AmenityId = 3,
                            AmenityName = "TV"
                        },
                        new
                        {
                            AmenityId = 4,
                            AmenityName = "Internet Wifi"
                        },
                        new
                        {
                            AmenityId = 5,
                            AmenityName = "Microwave"
                        });
                });

            modelBuilder.Entity("Model.ApplicationUser", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<int>("AccessFailedCount")
                        .HasColumnType("int");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime?>("CreatedDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("Email")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<bool>("EmailConfirmed")
                        .HasColumnType("bit");

                    b.Property<string>("Fullname")
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<bool>("LockoutEnabled")
                        .HasColumnType("bit");

                    b.Property<DateTimeOffset?>("LockoutEnd")
                        .HasColumnType("datetimeoffset");

                    b.Property<string>("NormalizedEmail")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<string>("NormalizedUserName")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<string>("PasswordHash")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PhoneNumber")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("PhoneNumberConfirmed")
                        .HasColumnType("bit");

                    b.Property<string>("SecurityStamp")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("TwoFactorEnabled")
                        .HasColumnType("bit");

                    b.Property<DateTime?>("UpdatedDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("UserName")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.HasKey("Id");

                    b.HasIndex("NormalizedEmail")
                        .HasDatabaseName("EmailIndex");

                    b.HasIndex("NormalizedUserName")
                        .IsUnique()
                        .HasDatabaseName("UserNameIndex")
                        .HasFilter("[NormalizedUserName] IS NOT NULL");

                    b.ToTable("tbl_Users", (string)null);
                });

            modelBuilder.Entity("Model.Booking", b =>
                {
                    b.Property<int>("BookingId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("BookingId"));

                    b.Property<DateTime>("ActualCancelledDate")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("ActualCheckinDate")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("ActualCheckoutDate")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("BookingDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("BookingStatus")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateOnly>("CheckinDate")
                        .HasColumnType("date");

                    b.Property<DateOnly>("CheckoutDate")
                        .HasColumnType("date");

                    b.Property<bool>("IsPaymentSuccessfull")
                        .HasColumnType("bit");

                    b.Property<int>("NoOfStay")
                        .HasColumnType("int");

                    b.Property<DateTime>("PaymentDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("PhoneNumber")
                        .HasMaxLength(12)
                        .HasColumnType("nvarchar(12)");

                    b.Property<int>("RoomId")
                        .HasColumnType("int");

                    b.Property<int>("RoomNo")
                        .HasColumnType("int");

                    b.Property<string>("StripePaymentIntentId")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("StripeSessionId")
                        .HasColumnType("nvarchar(max)");

                    b.Property<double>("TotalCost")
                        .HasMaxLength(12)
                        .HasColumnType("float");

                    b.Property<string>("UserEmail")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("UserName")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.HasKey("BookingId");

                    b.HasIndex("RoomId");

                    b.HasIndex("UserId");

                    b.ToTable("tbl_Booking");
                });

            modelBuilder.Entity("Model.ResetPassword", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<DateTime>("CreatedDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("ExpirationDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("OTP")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Token")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("tbl_ResetPassword");
                });

            modelBuilder.Entity("Model.Room", b =>
                {
                    b.Property<int>("RoomId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("RoomId"));

                    b.Property<DateTime?>("CreatedDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("Description")
                        .HasMaxLength(500)
                        .HasColumnType("nvarchar(500)");

                    b.Property<string>("ImageUrl")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("MaxOccupancy")
                        .HasColumnType("int");

                    b.Property<string>("RoomName")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<double>("RoomPrice")
                        .HasColumnType("float");

                    b.Property<DateTime?>("UpdatedDate")
                        .HasColumnType("datetime2");

                    b.HasKey("RoomId");

                    b.ToTable("tbl_Rooms");

                    b.HasData(
                        new
                        {
                            RoomId = 1,
                            CreatedDate = new DateTime(2024, 5, 5, 12, 14, 7, 552, DateTimeKind.Local).AddTicks(8990),
                            Description = "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Sed finibus sed purus consequat porta. Praesent vitae tincidunt dolor, bibendum lacinia urna.",
                            ImageUrl = "\\img\\Rooms\\Single.jpg",
                            MaxOccupancy = 1,
                            RoomName = "Single Room",
                            RoomPrice = 85.0,
                            UpdatedDate = new DateTime(2024, 5, 5, 12, 14, 7, 552, DateTimeKind.Local).AddTicks(8991)
                        },
                        new
                        {
                            RoomId = 2,
                            CreatedDate = new DateTime(2024, 5, 5, 12, 14, 7, 552, DateTimeKind.Local).AddTicks(8998),
                            Description = "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Sed finibus sed purus consequat porta. Praesent vitae tincidunt dolor, bibendum lacinia urna.",
                            ImageUrl = "\\img\\Rooms\\Double.jpg",
                            MaxOccupancy = 2,
                            RoomName = "Double Room",
                            RoomPrice = 90.0,
                            UpdatedDate = new DateTime(2024, 5, 5, 12, 14, 7, 552, DateTimeKind.Local).AddTicks(8999)
                        },
                        new
                        {
                            RoomId = 3,
                            CreatedDate = new DateTime(2024, 5, 5, 12, 14, 7, 552, DateTimeKind.Local).AddTicks(9005),
                            Description = "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Sed finibus sed purus consequat porta. Praesent vitae tincidunt dolor, bibendum lacinia urna.",
                            ImageUrl = "\\img\\Rooms\\Deluxed.jpg",
                            MaxOccupancy = 3,
                            RoomName = "Deluxed Room",
                            RoomPrice = 100.0,
                            UpdatedDate = new DateTime(2024, 5, 5, 12, 14, 7, 552, DateTimeKind.Local).AddTicks(9007)
                        },
                        new
                        {
                            RoomId = 4,
                            CreatedDate = new DateTime(2024, 5, 5, 12, 14, 7, 552, DateTimeKind.Local).AddTicks(9013),
                            Description = "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Sed finibus sed purus consequat porta. Praesent vitae tincidunt dolor, bibendum lacinia urna.",
                            ImageUrl = "\\img\\Rooms\\Queens.jpg",
                            MaxOccupancy = 4,
                            RoomName = "Queens Room",
                            RoomPrice = 120.0,
                            UpdatedDate = new DateTime(2024, 5, 5, 12, 14, 7, 552, DateTimeKind.Local).AddTicks(9014)
                        },
                        new
                        {
                            RoomId = 5,
                            CreatedDate = new DateTime(2024, 5, 5, 12, 14, 7, 552, DateTimeKind.Local).AddTicks(9019),
                            Description = "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Sed finibus sed purus consequat porta. Praesent vitae tincidunt dolor, bibendum lacinia urna.",
                            ImageUrl = "\\img\\Rooms\\Kings.jpg",
                            MaxOccupancy = 5,
                            RoomName = "Kings Room",
                            RoomPrice = 130.0,
                            UpdatedDate = new DateTime(2024, 5, 5, 12, 14, 7, 552, DateTimeKind.Local).AddTicks(9020)
                        },
                        new
                        {
                            RoomId = 6,
                            CreatedDate = new DateTime(2024, 5, 5, 12, 14, 7, 552, DateTimeKind.Local).AddTicks(9026),
                            Description = "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Sed finibus sed purus consequat porta. Praesent vitae tincidunt dolor, bibendum lacinia urna.",
                            ImageUrl = "\\img\\Rooms\\Executive.jpg",
                            MaxOccupancy = 10,
                            RoomName = "Executive Suite",
                            RoomPrice = 100.0,
                            UpdatedDate = new DateTime(2024, 5, 5, 12, 14, 7, 552, DateTimeKind.Local).AddTicks(9027)
                        },
                        new
                        {
                            RoomId = 7,
                            CreatedDate = new DateTime(2024, 5, 5, 12, 14, 7, 552, DateTimeKind.Local).AddTicks(9032),
                            Description = "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Sed finibus sed purus consequat porta. Praesent vitae tincidunt dolor, bibendum lacinia urna.",
                            ImageUrl = "\\img\\Rooms\\Super Deluxed.jpg",
                            MaxOccupancy = 10,
                            RoomName = "Super Deluxed",
                            RoomPrice = 110.0,
                            UpdatedDate = new DateTime(2024, 5, 5, 12, 14, 7, 552, DateTimeKind.Local).AddTicks(9033)
                        },
                        new
                        {
                            RoomId = 8,
                            CreatedDate = new DateTime(2024, 5, 5, 12, 14, 7, 552, DateTimeKind.Local).AddTicks(9039),
                            Description = "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Sed finibus sed purus consequat porta. Praesent vitae tincidunt dolor, bibendum lacinia urna.",
                            ImageUrl = "\\img\\Rooms\\Diamond Room.jpg",
                            MaxOccupancy = 10,
                            RoomName = "Diamond Room",
                            RoomPrice = 87.0,
                            UpdatedDate = new DateTime(2024, 5, 5, 12, 14, 7, 552, DateTimeKind.Local).AddTicks(9040)
                        },
                        new
                        {
                            RoomId = 9,
                            CreatedDate = new DateTime(2024, 5, 5, 12, 14, 7, 552, DateTimeKind.Local).AddTicks(9046),
                            Description = "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Sed finibus sed purus consequat porta. Praesent vitae tincidunt dolor, bibendum lacinia urna.",
                            ImageUrl = "\\img\\Rooms\\Emerald Room.jpg",
                            MaxOccupancy = 10,
                            RoomName = "Emerald Deluxed",
                            RoomPrice = 98.0,
                            UpdatedDate = new DateTime(2024, 5, 5, 12, 14, 7, 552, DateTimeKind.Local).AddTicks(9047)
                        });
                });

            modelBuilder.Entity("Model.RoomAmenity", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("AmenityId")
                        .HasColumnType("int");

                    b.Property<int>("RoomId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("AmenityId");

                    b.HasIndex("RoomId");

                    b.ToTable("tbl_RoomAmenity");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            AmenityId = 1,
                            RoomId = 1
                        },
                        new
                        {
                            Id = 2,
                            AmenityId = 2,
                            RoomId = 1
                        },
                        new
                        {
                            Id = 3,
                            AmenityId = 3,
                            RoomId = 1
                        },
                        new
                        {
                            Id = 4,
                            AmenityId = 4,
                            RoomId = 1
                        },
                        new
                        {
                            Id = 5,
                            AmenityId = 5,
                            RoomId = 1
                        },
                        new
                        {
                            Id = 6,
                            AmenityId = 3,
                            RoomId = 2
                        },
                        new
                        {
                            Id = 7,
                            AmenityId = 1,
                            RoomId = 2
                        },
                        new
                        {
                            Id = 8,
                            AmenityId = 5,
                            RoomId = 3
                        },
                        new
                        {
                            Id = 9,
                            AmenityId = 3,
                            RoomId = 4
                        },
                        new
                        {
                            Id = 10,
                            AmenityId = 5,
                            RoomId = 5
                        });
                });

            modelBuilder.Entity("Model.RoomNumber", b =>
                {
                    b.Property<int>("RoomNo")
                        .HasColumnType("int");

                    b.Property<string>("Description")
                        .HasMaxLength(500)
                        .HasColumnType("nvarchar(500)");

                    b.Property<int>("RoomId")
                        .HasColumnType("int");

                    b.HasKey("RoomNo");

                    b.HasIndex("RoomId");

                    b.ToTable("tbl_RoomNumber");

                    b.HasData(
                        new
                        {
                            RoomNo = 101,
                            Description = "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Sed finibus sed purus consequat porta. Praesent vitae tincidunt dolor.",
                            RoomId = 1
                        },
                        new
                        {
                            RoomNo = 102,
                            Description = "Lorem ipsum dolor sit amet, consectetur adipiscing elit.Sed finibus sed purus consequat porta.Praesent vitae tincidunt dolor.",
                            RoomId = 1
                        },
                        new
                        {
                            RoomNo = 103,
                            Description = "Lorem ipsum dolor sit amet, consectetur adipiscing elit.Sed finibus sed purus consequat porta.Praesent vitae tincidunt dolor.",
                            RoomId = 1
                        },
                        new
                        {
                            RoomNo = 104,
                            Description = "Lorem ipsum dolor sit amet, consectetur adipiscing elit.Sed finibus sed purus consequat porta.Praesent vitae tincidunt dolor.",
                            RoomId = 1
                        },
                        new
                        {
                            RoomNo = 201,
                            Description = "Lorem ipsum dolor sit amet, consectetur adipiscing elit.Sed finibus sed purus consequat porta.Praesent vitae tincidunt dolor.",
                            RoomId = 2
                        },
                        new
                        {
                            RoomNo = 202,
                            Description = "Lorem ipsum dolor sit amet, consectetur adipiscing elit.Sed finibus sed purus consequat porta.Praesent vitae tincidunt dolor.",
                            RoomId = 2
                        },
                        new
                        {
                            RoomNo = 203,
                            Description = "Lorem ipsum dolor sit amet, consectetur adipiscing elit.Sed finibus sed purus consequat porta.Praesent vitae tincidunt dolor.",
                            RoomId = 2
                        },
                        new
                        {
                            RoomNo = 204,
                            Description = "Lorem ipsum dolor sit amet, consectetur adipiscing elit.Sed finibus sed purus consequat porta.Praesent vitae tincidunt dolor.",
                            RoomId = 2
                        },
                        new
                        {
                            RoomNo = 301,
                            Description = "Lorem ipsum dolor sit amet, consectetur adipiscing elit.Sed finibus sed purus consequat porta.Praesent vitae tincidunt dolor.",
                            RoomId = 3
                        },
                        new
                        {
                            RoomNo = 302,
                            Description = "Lorem ipsum dolor sit amet, consectetur adipiscing elit.Sed finibus sed purus consequat porta.Praesent vitae tincidunt dolor.",
                            RoomId = 3
                        },
                        new
                        {
                            RoomNo = 303,
                            Description = "Lorem ipsum dolor sit amet, consectetur adipiscing elit.Sed finibus sed purus consequat porta.Praesent vitae tincidunt dolor.",
                            RoomId = 3
                        },
                        new
                        {
                            RoomNo = 304,
                            Description = "Lorem ipsum dolor sit amet, consectetur adipiscing elit.Sed finibus sed purus consequat porta.Praesent vitae tincidunt dolor.",
                            RoomId = 3
                        },
                        new
                        {
                            RoomNo = 401,
                            Description = "Lorem ipsum dolor sit amet, consectetur adipiscing elit.Sed finibus sed purus consequat porta.Praesent vitae tincidunt dolor.",
                            RoomId = 4
                        },
                        new
                        {
                            RoomNo = 402,
                            Description = "Lorem ipsum dolor sit amet, consectetur adipiscing elit.Sed finibus sed purus consequat porta.Praesent vitae tincidunt dolor.",
                            RoomId = 4
                        },
                        new
                        {
                            RoomNo = 403,
                            Description = "Lorem ipsum dolor sit amet, consectetur adipiscing elit.Sed finibus sed purus consequat porta.Praesent vitae tincidunt dolor.",
                            RoomId = 4
                        },
                        new
                        {
                            RoomNo = 501,
                            Description = "Lorem ipsum dolor sit amet, consectetur adipiscing elit.Sed finibus sed purus consequat porta.Praesent vitae tincidunt dolor.",
                            RoomId = 5
                        },
                        new
                        {
                            RoomNo = 502,
                            Description = "Lorem ipsum dolor sit amet, consectetur adipiscing elit.Sed finibus sed purus consequat porta.Praesent vitae tincidunt dolor.",
                            RoomId = 5
                        },
                        new
                        {
                            RoomNo = 503,
                            Description = "Lorem ipsum dolor sit amet, consectetur adipiscing elit.Sed finibus sed purus consequat porta.Praesent vitae tincidunt dolor.",
                            RoomId = 5
                        },
                        new
                        {
                            RoomNo = 601,
                            Description = "Lorem ipsum dolor sit amet, consectetur adipiscing elit.Sed finibus sed purus consequat porta.Praesent vitae tincidunt dolor.",
                            RoomId = 6
                        },
                        new
                        {
                            RoomNo = 602,
                            Description = "Lorem ipsum dolor sit amet, consectetur adipiscing elit.Sed finibus sed purus consequat porta.Praesent vitae tincidunt dolor.",
                            RoomId = 6
                        });
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole", null)
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.HasOne("Model.ApplicationUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.HasOne("Model.ApplicationUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole", null)
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Model.ApplicationUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.HasOne("Model.ApplicationUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Model.Booking", b =>
                {
                    b.HasOne("Model.Room", "Room")
                        .WithMany()
                        .HasForeignKey("RoomId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Model.ApplicationUser", "User")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Room");

                    b.Navigation("User");
                });

            modelBuilder.Entity("Model.RoomAmenity", b =>
                {
                    b.HasOne("Model.Amenity", "Amenity")
                        .WithMany()
                        .HasForeignKey("AmenityId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Model.Room", "Room")
                        .WithMany("RoomAmenities")
                        .HasForeignKey("RoomId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Amenity");

                    b.Navigation("Room");
                });

            modelBuilder.Entity("Model.RoomNumber", b =>
                {
                    b.HasOne("Model.Room", "Room")
                        .WithMany()
                        .HasForeignKey("RoomId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Room");
                });

            modelBuilder.Entity("Model.Room", b =>
                {
                    b.Navigation("RoomAmenities");
                });
#pragma warning restore 612, 618
        }
    }
}
