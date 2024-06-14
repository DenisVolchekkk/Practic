﻿// <auto-generated />
using System;
using BicyclesWeb.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace BicyclesWeb.Migrations
{
    [DbContext(typeof(BicyclesContext))]
    [Migration("20240614165246_Migration2")]
    partial class Migration2
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.29")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("BicyclesWeb.Models.Bicycle", b =>
                {
                    b.Property<int>("BicycleId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("BicycleId"), 1L, 1);

                    b.Property<string>("ModelName")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("BicycleId");

                    b.ToTable("Bicycles");
                });

            modelBuilder.Entity("BicyclesWeb.Models.Part", b =>
                {
                    b.Property<int>("PartId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("PartId"), 1L, 1);

                    b.Property<string>("PartDescription")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PartName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("SupplierId")
                        .HasColumnType("int");

                    b.HasKey("PartId");

                    b.HasIndex("SupplierId");

                    b.ToTable("Parts");
                });

            modelBuilder.Entity("BicyclesWeb.Models.PartBicycle", b =>
                {
                    b.Property<int>("PartBicycleId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("PartBicycleId"), 1L, 1);

                    b.Property<int?>("BicycleId")
                        .HasColumnType("int");

                    b.Property<int?>("PartId")
                        .HasColumnType("int");

                    b.Property<int?>("QuantityRequired")
                        .HasColumnType("int");

                    b.HasKey("PartBicycleId");

                    b.HasIndex("BicycleId");

                    b.HasIndex("PartId");

                    b.ToTable("PartBicycles");
                });

            modelBuilder.Entity("BicyclesWeb.Models.PartOrder", b =>
                {
                    b.Property<int>("PartOrderId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("PartOrderId"), 1L, 1);

                    b.Property<int>("BicycleId")
                        .HasColumnType("int");

                    b.Property<int>("CountofBicycles")
                        .HasColumnType("int");

                    b.Property<DateTime?>("ExpectedDeliveryDate")
                        .HasColumnType("datetime2");

                    b.Property<DateTime?>("OrderDate")
                        .HasColumnType("datetime2");

                    b.HasKey("PartOrderId");

                    b.HasIndex("BicycleId");

                    b.ToTable("PartOrders");
                });

            modelBuilder.Entity("BicyclesWeb.Models.Supplier", b =>
                {
                    b.Property<int>("SupplierId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("SupplierId"), 1L, 1);

                    b.Property<string>("Address")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ContactInfo")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("SupplierName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("SupplierTypeId")
                        .HasColumnType("int");

                    b.HasKey("SupplierId");

                    b.HasIndex("SupplierTypeId");

                    b.ToTable("Suppliers");
                });

            modelBuilder.Entity("BicyclesWeb.Models.SupplierType", b =>
                {
                    b.Property<int>("SupplierTypeId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("SupplierTypeId"), 1L, 1);

                    b.Property<string>("SupplierTypeName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("SupplierTypeId");

                    b.ToTable("SupplierTypes");
                });

            modelBuilder.Entity("BicyclesWeb.Models.Part", b =>
                {
                    b.HasOne("BicyclesWeb.Models.Supplier", "Supplier")
                        .WithMany("Parts")
                        .HasForeignKey("SupplierId");

                    b.Navigation("Supplier");
                });

            modelBuilder.Entity("BicyclesWeb.Models.PartBicycle", b =>
                {
                    b.HasOne("BicyclesWeb.Models.Bicycle", "Bicycle")
                        .WithMany("PartBicycles")
                        .HasForeignKey("BicycleId");

                    b.HasOne("BicyclesWeb.Models.Part", "Part")
                        .WithMany("PartBicycles")
                        .HasForeignKey("PartId");

                    b.Navigation("Bicycle");

                    b.Navigation("Part");
                });

            modelBuilder.Entity("BicyclesWeb.Models.PartOrder", b =>
                {
                    b.HasOne("BicyclesWeb.Models.Bicycle", "Bicycle")
                        .WithMany("PartOrders")
                        .HasForeignKey("BicycleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Bicycle");
                });

            modelBuilder.Entity("BicyclesWeb.Models.Supplier", b =>
                {
                    b.HasOne("BicyclesWeb.Models.SupplierType", "SupplierType")
                        .WithMany("Suppliers")
                        .HasForeignKey("SupplierTypeId");

                    b.Navigation("SupplierType");
                });

            modelBuilder.Entity("BicyclesWeb.Models.Bicycle", b =>
                {
                    b.Navigation("PartBicycles");

                    b.Navigation("PartOrders");
                });

            modelBuilder.Entity("BicyclesWeb.Models.Part", b =>
                {
                    b.Navigation("PartBicycles");
                });

            modelBuilder.Entity("BicyclesWeb.Models.Supplier", b =>
                {
                    b.Navigation("Parts");
                });

            modelBuilder.Entity("BicyclesWeb.Models.SupplierType", b =>
                {
                    b.Navigation("Suppliers");
                });
#pragma warning restore 612, 618
        }
    }
}
