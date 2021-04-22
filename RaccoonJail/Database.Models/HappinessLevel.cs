using System;
using System.Collections.Generic;

#nullable disable

namespace Database.Models
{
    public partial class HappinessLevel
    {
        public HappinessLevel()
        {
            Inmates = new HashSet<Inmate>();
        }

        public int Id { get; set; }
        public string Description { get; set; }

        public virtual ICollection<Inmate> Inmates { get; set; }
    }
}
