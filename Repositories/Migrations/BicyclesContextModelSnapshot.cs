
using System;

using Domains.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Repositories.Context;

#nullable disable

namespace Repositories.Migrations
{
    [DbContext(typeof(BicyclesContext))]
    partial class BicyclesContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.6")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("Domains.Models.Bicycle", b =>
                {
                    b.Property<int>("BicycleId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("BicycleId"));

                    b.Property<string>("ModelName")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("BicycleId");

                    b.ToTable("Bicycles");
                });

            modelBuilder.Entity("Domains.Models.Part", b =>
                {
                    b.Property<int>("PartId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("PartId"));

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

            modelBuilder.Entity("Domains.Models.PartBicycle", b =>
                {
                    b.Property<int>("PartBicycleId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("PartBicycleId"));

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

            modelBuilder.Entity("Domains.Models.PartOrder", b =>
                {
                    b.Property<int>("PartOrderId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("PartOrderId"));

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

            modelBuilder.Entity("Domains.Models.Supplier", b =>
                {
                    b.Property<int>("SupplierId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("SupplierId"));

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

            modelBuilder.Entity("Domains.Models.SupplierType", b =>
                {
                    b.Property<int>("SupplierTypeId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("SupplierTypeId"));

                    b.Property<string>("SupplierTypeName")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("SupplierTypeId");

                    b.ToTable("SupplierTypes");
                });

            modelBuilder.Entity("Domains.Models.Part", b =>
                {
                    b.HasOne("Domains.Models.Supplier", "Supplier")
                        .WithMany("Parts")
                        .HasForeignKey("SupplierId");

                    b.Navigation("Supplier");
                });

            modelBuilder.Entity("Domains.Models.PartBicycle", b =>
                {
                    b.HasOne("Domains.Models.Bicycle", "Bicycle")
                        .WithMany("PartBicycles")
                        .HasForeignKey("BicycleId");

                    b.HasOne("Domains.Models.Part", "Part")
                        .WithMany("PartBicycles")
                        .HasForeignKey("PartId");

                    b.Navigation("Bicycle");

                    b.Navigation("Part");
                });

            modelBuilder.Entity("Domains.Models.PartOrder", b =>
                {
                    b.HasOne("Domains.Models.Bicycle", "Bicycle")
                        .WithMany("PartOrders")
                        .HasForeignKey("BicycleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Bicycle");
                });

            modelBuilder.Entity("Domains.Models.Supplier", b =>
                {
                    b.HasOne("Domains.Models.SupplierType", "SupplierType")
                        .WithMany("Suppliers")
                        .HasForeignKey("SupplierTypeId");

                    b.Navigation("SupplierType");
                });

            modelBuilder.Entity("Domains.Models.Bicycle", b =>
                {
                    b.Navigation("PartBicycles");

                    b.Navigation("PartOrders");
                });

            modelBuilder.Entity("Domains.Models.Part", b =>
                {
                    b.Navigation("PartBicycles");
                });

            modelBuilder.Entity("Domains.Models.Supplier", b =>
                {
                    b.Navigation("Parts");
                });

            modelBuilder.Entity("Domains.Models.SupplierType", b =>
                {
                    b.Navigation("Suppliers");
                });
#pragma warning restore 612, 618
        }
    }
}
