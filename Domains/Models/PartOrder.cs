using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Domains.Models
{
    public partial class PartOrder
    {
        [Key]
        [Display(Name = "Заказ")]
        public int PartOrderId { get; set; }
        [Display(Name = "Дата заказа")]
        public DateTime OrderDate { get; set; }
        [Display(Name = "Дата выполнения заказа")]
        public DateTime ExpectedDeliveryDate { get; set; }
        [Display(Name = "Модель велосипеда")]
        public int BicycleId { get; set; }
        [Display(Name = "Кол-во велосипедов")]
        public int CountofBicycles   { get; set; }

        [Display(Name = "Модель велосипеда")]
        public virtual Bicycle? Bicycle { get; set; }
    }
}
