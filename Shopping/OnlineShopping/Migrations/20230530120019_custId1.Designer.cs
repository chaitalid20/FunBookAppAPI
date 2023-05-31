﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using OnlineShopping.Data;

#nullable disable

namespace OnlineShopping.Migrations
{
    [DbContext(typeof(DataContext))]
    [Migration("20230530120019_custId1")]
    partial class custId1
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.5")
                .HasAnnotation("Relational:MaxIdentifierLength", 64);

            modelBuilder.Entity("OnlineShopping.Models.Cart", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<int>("ItemCount")
                        .HasColumnType("int");

                    b.Property<double>("TotalPrice")
                        .HasColumnType("double");

                    b.HasKey("Id");

                    b.ToTable("Cart");
                });

            modelBuilder.Entity("OnlineShopping.Models.CartItem", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<int?>("Amount")
                        .HasColumnType("int");

                    b.Property<int>("CartId")
                        .HasColumnType("int");

                    b.Property<int>("ProductListId")
                        .HasColumnType("int");

                    b.Property<int>("customerId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("CartId")
                        .IsUnique();

                    b.ToTable("CartItem");
                });

            modelBuilder.Entity("OnlineShopping.Models.Customer", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<bool?>("IsMembership")
                        .HasColumnType("tinyint(1)");

                    b.Property<string>("email")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("userName")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.HasKey("Id");

                    b.ToTable("Customer");
                });

            modelBuilder.Entity("OnlineShopping.Models.Order", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<int>("CustomerId")
                        .HasColumnType("int");

                    b.Property<bool?>("IsPaymentSuccess")
                        .HasColumnType("tinyint(1)");

                    b.Property<double>("TotalPrice")
                        .HasColumnType("double");

                    b.Property<bool?>("isMember")
                        .HasColumnType("tinyint(1)");

                    b.HasKey("Id");

                    b.ToTable("Order");
                });

            modelBuilder.Entity("OnlineShopping.Models.OrderItems", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<int>("Amount")
                        .HasColumnType("int");

                    b.Property<int>("OrderId")
                        .HasColumnType("int");

                    b.Property<double>("Price")
                        .HasColumnType("double");

                    b.Property<int>("ProductId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("OrderId");

                    b.ToTable("OrderItems");
                });

            modelBuilder.Entity("OnlineShopping.Models.ProductList", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("Description")
                        .HasColumnType("longtext");

                    b.Property<double?>("Price")
                        .HasColumnType("double");

                    b.Property<string>("ProductName")
                        .HasColumnType("longtext");

                    b.Property<int>("ProductTypeId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("ProductList");
                });

            modelBuilder.Entity("OnlineShopping.Models.ProductType", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.HasKey("Id");

                    b.ToTable("ProductType");
                });

            modelBuilder.Entity("OnlineShopping.Models.Products", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("Description")
                        .HasColumnType("longtext");

                    b.Property<double?>("Price")
                        .HasColumnType("double");

                    b.Property<string>("ProductName")
                        .HasColumnType("longtext");

                    b.Property<int>("ProductTypeId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("ProductTypeId");

                    b.ToTable("Products");
                });

            modelBuilder.Entity("OnlineShopping.Models.CartItem", b =>
                {
                    b.HasOne("OnlineShopping.Models.Cart", null)
                        .WithOne("CartItem")
                        .HasForeignKey("OnlineShopping.Models.CartItem", "CartId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("OnlineShopping.Models.OrderItems", b =>
                {
                    b.HasOne("OnlineShopping.Models.Order", null)
                        .WithMany("OrderList")
                        .HasForeignKey("OrderId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("OnlineShopping.Models.Products", b =>
                {
                    b.HasOne("OnlineShopping.Models.ProductType", "ProductType")
                        .WithMany()
                        .HasForeignKey("ProductTypeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("ProductType");
                });

            modelBuilder.Entity("OnlineShopping.Models.Cart", b =>
                {
                    b.Navigation("CartItem")
                        .IsRequired();
                });

            modelBuilder.Entity("OnlineShopping.Models.Order", b =>
                {
                    b.Navigation("OrderList");
                });
#pragma warning restore 612, 618
        }
    }
}
