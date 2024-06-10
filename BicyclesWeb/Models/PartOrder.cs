using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace BicyclesWeb.Models
{
    public partial class PartOrder
    {
        [Key]
        public int PartOrderId { get; set; }
        public DateTime? OrderDate { get; set; }
        public DateTime? ExpectedDeliveryDate { get; set; }
        public int BicycleId { get; set; }

        public int CountofBicycles   { get; set; }
        public virtual Bicycle? Bicycle { get; set; }
    }
}
