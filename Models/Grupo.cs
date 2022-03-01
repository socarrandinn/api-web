using System;
using System.Collections.Generic;

namespace api_web.Models
{
    public partial class Grupo
    {
        public Grupo()
        {
            Poblacions = new HashSet<Poblacion>();
        }

        public int Id { get; set; }
        public string Tipogrupo { get; set; } = null!;

        public virtual ICollection<Poblacion> Poblacions { get; set; }
    }
}
