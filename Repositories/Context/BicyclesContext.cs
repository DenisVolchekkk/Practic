
using Domains.Models;
using Microsoft.EntityFrameworkCore;

namespace Repositories.Context
{
    public partial class BicyclesContext : DbContext
    {
        public BicyclesContext(DbContextOptions<BicyclesContext> options)
    : base(options)
        {
        }
<<<<<<< HEAD:Repositories/Context/BicyclesContext.cs
        public virtual DbSet<Bicycle> Bicycles { get; set; }
        public virtual DbSet<Part> Parts { get; set; }
        public virtual DbSet<PartBicycle> PartBicycles { get; set; }
        public virtual DbSet<PartOrder> PartOrders { get; set; }
        public virtual DbSet<Supplier> Suppliers { get; set; }
=======
>>>>>>> dd312b443ad0ae64a47a6e4f183b88a6614b7f6f:BicyclesWeb/Models/BicyclesContext.cs
        public virtual DbSet<SupplierType> SupplierTypes { get; set; }
        public virtual DbSet<Supplier> Suppliers { get; set; }
        public virtual DbSet<Part> Parts { get; set; }
        public virtual DbSet<Bicycle> Bicycles { get; set; }

        public virtual DbSet<PartOrder> PartOrders { get; set; }
        public virtual DbSet<PartBicycle> PartBicycles { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=(localdb)\\MSSQLLocalDB;Database=Bicycles;Integrated Security=SSPI;Trusted_Connection=True;TrustServerCertificate=True");
        }
    }
}
