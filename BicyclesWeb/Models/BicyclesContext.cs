using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace BicyclesWeb.Models
{
    public partial class BicyclesContext : DbContext
    {
        public virtual DbSet<Bicycle> Bicycles { get; set; }
        public virtual DbSet<Part> Parts { get; set; } 
        public virtual DbSet<PartBicycle> PartBicycles { get; set; }
        public virtual DbSet<PartOrder> PartOrders { get; set; }
        public virtual DbSet<Supplier> Suppliers { get; set; } 
        public virtual DbSet<SupplierType> SupplierTypes { get; set; } 

    }
}
