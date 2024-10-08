﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;
using PolyFlora.Persistence;

#nullable disable

namespace PolyFlora.Persistence.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    [Migration("20240927160751_INIT")]
    partial class INIT
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.8")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("BouquetFlower", b =>
                {
                    b.Property<Guid>("BouquetsId")
                        .HasColumnType("uuid");

                    b.Property<Guid>("FlowersId")
                        .HasColumnType("uuid");

                    b.HasKey("BouquetsId", "FlowersId");

                    b.HasIndex("FlowersId");

                    b.ToTable("BouquetFlower");
                });

            modelBuilder.Entity("PolyFlora.Core.Models.Bouquet", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<bool>("Available")
                        .HasColumnType("boolean");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("TName")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<DateTime>("TimeStamp")
                        .HasColumnType("timestamp with time zone");

                    b.HasKey("Id");

                    b.ToTable("Bouquet");
                });

            modelBuilder.Entity("PolyFlora.Core.Models.BouquetSize", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<bool>("Available")
                        .HasColumnType("boolean");

                    b.Property<Guid>("BouquetId")
                        .HasColumnType("uuid");

                    b.Property<string>("CropDescription")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<Guid?>("OrderId")
                        .HasColumnType("uuid");

                    b.Property<decimal>("Price")
                        .HasColumnType("numeric");

                    b.Property<string>("SizeName")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("TSizeName")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.HasIndex("BouquetId");

                    b.HasIndex("OrderId");

                    b.ToTable("BouquetSize");
                });

            modelBuilder.Entity("PolyFlora.Core.Models.Customer", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("PhoneNumber")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<Guid?>("UserId")
                        .HasColumnType("uuid");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("Customer");
                });

            modelBuilder.Entity("PolyFlora.Core.Models.Flower", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<Guid?>("FlowerParentId")
                        .HasColumnType("uuid");

                    b.Property<int>("InStock")
                        .HasColumnType("integer");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<decimal>("Price")
                        .HasColumnType("numeric");

                    b.Property<string>("TName")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<DateTime>("TimeStamp")
                        .HasColumnType("timestamp with time zone");

                    b.HasKey("Id");

                    b.HasIndex("FlowerParentId");

                    b.ToTable("Flowers");
                });

            modelBuilder.Entity("PolyFlora.Core.Models.FlowerPack", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<Guid?>("BouquetSizeId")
                        .HasColumnType("uuid");

                    b.Property<Guid>("FlowerId")
                        .HasColumnType("uuid");

                    b.Property<long>("Quantity")
                        .HasColumnType("bigint");

                    b.HasKey("Id");

                    b.HasIndex("BouquetSizeId");

                    b.HasIndex("FlowerId");

                    b.ToTable("FlowerPack");
                });

            modelBuilder.Entity("PolyFlora.Core.Models.Order", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<string>("Address")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<bool>("Anonymous")
                        .HasColumnType("boolean");

                    b.Property<Guid>("CustomerId")
                        .HasColumnType("uuid");

                    b.Property<string>("DeliveryDate")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Notes")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<long>("OrderNumber")
                        .HasColumnType("bigint");

                    b.Property<int>("PrepaymentStatus")
                        .HasColumnType("integer");

                    b.Property<int>("PrepaymentType")
                        .HasColumnType("integer");

                    b.Property<Guid?>("RecipientId")
                        .HasColumnType("uuid");

                    b.Property<Guid?>("UserId")
                        .HasColumnType("uuid");

                    b.HasKey("Id");

                    b.HasIndex("CustomerId");

                    b.HasIndex("RecipientId");

                    b.HasIndex("UserId");

                    b.ToTable("Order");
                });

            modelBuilder.Entity("PolyFlora.Core.Models.Recipient", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("PhoneNumber")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.ToTable("Recipient");
                });

            modelBuilder.Entity("PolyFlora.Core.Models.User", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<string>("Adress")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("HashPassword")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("RefreshToken")
                        .HasColumnType("text");

                    b.Property<DateTime>("RefreshTokenExpire")
                        .HasColumnType("timestamp with time zone");

                    b.Property<int>("Role")
                        .HasColumnType("integer");

                    b.HasKey("Id");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("BouquetFlower", b =>
                {
                    b.HasOne("PolyFlora.Core.Models.Bouquet", null)
                        .WithMany()
                        .HasForeignKey("BouquetsId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("PolyFlora.Core.Models.Flower", null)
                        .WithMany()
                        .HasForeignKey("FlowersId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("PolyFlora.Core.Models.BouquetSize", b =>
                {
                    b.HasOne("PolyFlora.Core.Models.Bouquet", "Bouquet")
                        .WithMany("Sizes")
                        .HasForeignKey("BouquetId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("PolyFlora.Core.Models.Order", null)
                        .WithMany("Bouquets")
                        .HasForeignKey("OrderId");

                    b.Navigation("Bouquet");
                });

            modelBuilder.Entity("PolyFlora.Core.Models.Customer", b =>
                {
                    b.HasOne("PolyFlora.Core.Models.User", "User")
                        .WithMany()
                        .HasForeignKey("UserId");

                    b.Navigation("User");
                });

            modelBuilder.Entity("PolyFlora.Core.Models.Flower", b =>
                {
                    b.HasOne("PolyFlora.Core.Models.Flower", "FlowerParent")
                        .WithMany("FlowerChildrens")
                        .HasForeignKey("FlowerParentId");

                    b.Navigation("FlowerParent");
                });

            modelBuilder.Entity("PolyFlora.Core.Models.FlowerPack", b =>
                {
                    b.HasOne("PolyFlora.Core.Models.BouquetSize", null)
                        .WithMany("FlowerPacks")
                        .HasForeignKey("BouquetSizeId");

                    b.HasOne("PolyFlora.Core.Models.Flower", "Flower")
                        .WithMany()
                        .HasForeignKey("FlowerId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Flower");
                });

            modelBuilder.Entity("PolyFlora.Core.Models.Order", b =>
                {
                    b.HasOne("PolyFlora.Core.Models.Customer", "Customer")
                        .WithMany()
                        .HasForeignKey("CustomerId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("PolyFlora.Core.Models.Recipient", "Recipient")
                        .WithMany()
                        .HasForeignKey("RecipientId");

                    b.HasOne("PolyFlora.Core.Models.User", null)
                        .WithMany("Orders")
                        .HasForeignKey("UserId");

                    b.Navigation("Customer");

                    b.Navigation("Recipient");
                });

            modelBuilder.Entity("PolyFlora.Core.Models.Bouquet", b =>
                {
                    b.Navigation("Sizes");
                });

            modelBuilder.Entity("PolyFlora.Core.Models.BouquetSize", b =>
                {
                    b.Navigation("FlowerPacks");
                });

            modelBuilder.Entity("PolyFlora.Core.Models.Flower", b =>
                {
                    b.Navigation("FlowerChildrens");
                });

            modelBuilder.Entity("PolyFlora.Core.Models.Order", b =>
                {
                    b.Navigation("Bouquets");
                });

            modelBuilder.Entity("PolyFlora.Core.Models.User", b =>
                {
                    b.Navigation("Orders");
                });
#pragma warning restore 612, 618
        }
    }
}
