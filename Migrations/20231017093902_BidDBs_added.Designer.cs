﻿// <auto-generated />
using System;
using AuctionApplication.Persistence;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace AuctionApplication.Migrations
{
    [DbContext(typeof(AuctionDbContext))]
    [Migration("20231017093902_BidDBs_added")]
    partial class BidDBs_added
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.12")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("AuctionApplication.Persistence.AuctionDB", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<DateTime>("ClosingTime")
                        .HasColumnType("datetime2");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("nvarchar(255)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(128)
                        .HasColumnType("nvarchar(128)");

                    b.Property<int>("StartingPrice")
                        .HasColumnType("int");

                    b.Property<string>("UserName")
                        .IsRequired()
                        .HasMaxLength(128)
                        .HasColumnType("nvarchar(128)");

                    b.HasKey("Id");

                    b.ToTable("AuctionDBs");

                    b.HasData(
                        new
                        {
                            Id = -1,
                            ClosingTime = new DateTime(2023, 10, 17, 12, 0, 0, 0, DateTimeKind.Unspecified),
                            Description = "En test auktion",
                            Name = "Test",
                            StartingPrice = 100,
                            UserName = "admin"
                        });
                });

            modelBuilder.Entity("AuctionApplication.Persistence.BidDB", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("AuctionId")
                        .HasColumnType("int");

                    b.Property<DateTime>("CreatedDate")
                        .HasColumnType("datetime2");

                    b.Property<int>("Price")
                        .HasColumnType("int");

                    b.Property<string>("UserName")
                        .IsRequired()
                        .HasMaxLength(128)
                        .HasColumnType("nvarchar(128)");

                    b.HasKey("Id");

                    b.HasIndex("AuctionId");

                    b.ToTable("BidDBs");

                    b.HasData(
                        new
                        {
                            Id = -1,
                            AuctionId = -1,
                            CreatedDate = new DateTime(2023, 10, 17, 11, 39, 2, 586, DateTimeKind.Local).AddTicks(8385),
                            Price = 500,
                            UserName = "admin"
                        },
                        new
                        {
                            Id = -2,
                            AuctionId = -1,
                            CreatedDate = new DateTime(2023, 10, 17, 11, 39, 2, 586, DateTimeKind.Local).AddTicks(8424),
                            Price = 1000,
                            UserName = "admin"
                        });
                });

            modelBuilder.Entity("AuctionApplication.Persistence.BidDB", b =>
                {
                    b.HasOne("AuctionApplication.Persistence.AuctionDB", "AuctionDB")
                        .WithMany("BidDBs")
                        .HasForeignKey("AuctionId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("AuctionDB");
                });

            modelBuilder.Entity("AuctionApplication.Persistence.AuctionDB", b =>
                {
                    b.Navigation("BidDBs");
                });
#pragma warning restore 612, 618
        }
    }
}
