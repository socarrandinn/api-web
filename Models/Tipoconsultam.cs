using System;
using System.Collections.Generic;

namespace api_web.Models
{
    public partial class Tipoconsultam
    {
        public Tipoconsultam()
        {
            Poblacionhojacargos = new HashSet<Poblacionhojacargo>();
        }

        public int Id { get; set; }
        public string Tipo { get; set; } = null!;

        public virtual ICollection<Poblacionhojacargo> Poblacionhojacargos { get; set; }
    }
}
