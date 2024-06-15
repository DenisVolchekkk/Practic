using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Domains.Models
{
    public partial class SupplierType
    {

        [Key]

        public int SupplierTypeId { get; set; }
        [Display(Name = "Тип поставщика")]
        public string? SupplierTypeName { get; set; }
        [Display(Name = "Поставщик")]
        public virtual ICollection<Supplier> Suppliers { get; set; } = new List<Supplier>();
    }
}
