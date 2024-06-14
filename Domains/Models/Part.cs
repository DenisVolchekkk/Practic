using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Domains.Models
{
    public partial class Part
    {

        [Key]
        public int PartId { get; set; }
        public string? PartName { get; set; }
        public string? PartDescription { get; set; }
        public int? SupplierId { get; set; }

        public virtual Supplier? Supplier { get; set; }
        public virtual ICollection<PartBicycle> PartBicycles { get; set; } = new List<PartBicycle>();
    }
}
