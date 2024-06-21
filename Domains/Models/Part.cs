using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Domains.Models
{
    public partial class Part
    {

        [Key]
        [Display(Name = "Деталь")]
        public int PartId { get; set; }
        [Display(Name = "Название детали")]
        public string PartName { get; set; }
        [Display(Name = "Описание")]

        public string PartDescription { get; set; }
        [Display(Name = "Поставщик")]

        public int SupplierId { get; set; }
        [Display(Name = "Поставщик")]
        public virtual Supplier? Supplier { get; set; }
        public virtual ICollection<PartBicycle> PartBicycles { get; set; } = new List<PartBicycle>();
    }
}
