using System;
using System.Collections.Generic;

namespace api_web.Models
{
    public partial class Consulta
    {
        public Consulta()
        {
            Poblacionhojacargos = new HashSet<Poblacionhojacargo>();
        }

        public int Id { get; set; }
        public string Tipoconsulta { get; set; } = null!;

        public virtual ICollection<Poblacionhojacargo> Poblacionhojacargos { get; set; }
    }
}
