using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Domains.Models
{
    public partial class PartBicycle
    {
        [Key]
        public int PartBicycleId { get; set; }
        public int? PartId { get; set; }
        public int? BicycleId { get; set; }
        public int? QuantityRequired { get; set; }

        public virtual Bicycle? Bicycle { get; set; }
        public virtual Part? Part { get; set; }
    }
}
