using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace BicyclesWeb.Models
{
    public partial class SupplierType
    {

        [Key]
        public int SupplierTypeId { get; set; }
        public string SupplierTypeName { get; set; }

        public virtual ICollection<Supplier> Suppliers { get; set; } = new List<Supplier>();
    }
}
