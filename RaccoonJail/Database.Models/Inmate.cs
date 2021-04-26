using System;
using System.Collections.Generic;

#nullable disable

namespace Database.Models
{
    public partial class Inmate
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public decimal SizeInOz { get; set; }
        public int TimeServedInMonths { get; set; }
        public int ArrestLocationId { get; set; }
        public int HappinessLevelId { get; set; }
        public int HungerLevelId { get; set; }

        public virtual ArrestLocation ArrestLocation { get; set; }
        public virtual HappinessLevel HappinessLevel { get; set; }
        public virtual HungerLevel HungerLevel { get; set; }
    }
}
