using System;
using System.Collections.Generic;

#nullable disable

namespace Database.Models
{
    public partial class ArrestLocation
    {
        public ArrestLocation()
        {
            Inmates = new HashSet<Inmate>();
        }

        public int Id { get; set; }
        public string Location { get; set; }

        public virtual ICollection<Inmate> Inmates { get; set; }
    }
}
