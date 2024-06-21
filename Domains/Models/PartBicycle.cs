using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Domains.Models
{
    public partial class PartBicycle
    {
        [Key]
        [Display(Name = "Деталь велосипеда")]
        public int PartBicycleId { get; set; }
        [Display(Name = "Название детали")]
        public int PartId { get; set; }
        [Display(Name = "Модель велосипеда")]

        public int BicycleId { get; set; }
        [Display(Name = "Количество деталей")]
        public int QuantityRequired { get; set; }
        [Display(Name = "Модель велосипеда")]
        public virtual Bicycle? Bicycle { get; set; }
        [Display(Name = "Название детали")]

        public virtual Part? Part { get; set; }
    }
}
