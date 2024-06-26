﻿
using Domains.Models;
using Microsoft.EntityFrameworkCore;

namespace Repositories.Context
{
    public partial class BicyclesContext : DbContext
    {
        public BicyclesContext()
        {
        }

        public BicyclesContext(DbContextOptions<BicyclesContext> options)
            : base(options)
        {
        }


        public virtual DbSet<Bicycle> Bicycles { get; set; }

        public virtual DbSet<Part> Parts { get; set; }

        public virtual DbSet<PartBicycle> PartBicycles { get; set; }

        public virtual DbSet<PartOrder> PartOrders { get; set; }

        public virtual DbSet<Supplier> Suppliers { get; set; }

        public virtual DbSet<SupplierType> SupplierTypes { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
            => optionsBuilder.UseSqlServer("Server=(localdb)\\MSSQLLocalDB;Database=Bicycles;Integrated Security=SSPI;Trusted_Connection=True;TrustServerCertificate=True");



    }
}
