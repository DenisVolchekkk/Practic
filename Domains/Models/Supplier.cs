using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Domains.Models
{
    public partial class Supplier
    {
        [Key]
        [Display(Name = "Поставщик")]
        public int SupplierId { get; set; }
        [Display(Name = "Поставщик")]
        public string SupplierName { get; set; }
        [Display(Name = "Номер")]
        public string ContactInfo { get; set; }
        [Display(Name = "Адресс")]

        public string Address { get; set; }
        [Display(Name = "Тип поставщика")]
        public int SupplierTypeId { get; set; }
        [Display(Name = "Тип поставщика")]

        public virtual SupplierType? SupplierType { get; set; }
        public virtual ICollection<Part> Parts { get; set; } = new List<Part>();
    }
}
