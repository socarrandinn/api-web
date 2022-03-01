using System;
using System.Collections.Generic;

namespace api_web.Models
{
    public partial class Hojacargo
    {
        public Hojacargo()
        {
            Poblacionhojacargos = new HashSet<Poblacionhojacargo>();
        }

        public int Id { get; set; }
        public DateOnly Fechahojacargo { get; set; }
        public int Consultoriomedicoid { get; set; }
        public int Userid { get; set; }

        public virtual Consultoriomedico Consultoriomedico { get; set; } = null!;
        public virtual User User { get; set; } = null!;
        public virtual ICollection<Poblacionhojacargo> Poblacionhojacargos { get; set; }
    }
}
