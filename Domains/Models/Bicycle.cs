using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Domains.Models
{
    public partial class Bicycle
    {
        [Key]
        public int BicycleId { get; set; }
        [Display(Name = "Модель")]
        public string ModelName { get; set; }

        public virtual ICollection<PartBicycle> PartBicycles { get; set; } = new List<PartBicycle>();
        public virtual ICollection<PartOrder> PartOrders { get; set; } = new List<PartOrder>();
    }
}
