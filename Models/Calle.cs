using System;
using System.Collections.Generic;

namespace api_web.Models
{
    public partial class Calle
    {
        public Calle()
        {
            Poblacions = new HashSet<Poblacion>();
        }

        public int Id { get; set; }
        public string Direccion { get; set; } = null!;

        public virtual ICollection<Poblacion> Poblacions { get; set; }
    }
}
