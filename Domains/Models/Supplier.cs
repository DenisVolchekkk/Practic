using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Domains.Models
{
    public partial class Supplier
    {
        [Key]
        public int SupplierId { get; set; }
        public string? SupplierName { get; set; }
        public string? ContactInfo { get; set; }
        public string? Address { get; set; }
        public int? SupplierTypeId { get; set; }

        public virtual SupplierType? SupplierType { get; set; }
        public virtual ICollection<Part> Parts { get; set; } = new List<Part>();
    }
}
