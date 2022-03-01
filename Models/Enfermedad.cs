using System;
using System.Collections.Generic;

namespace api_web.Models
{
    public partial class Enfermedad
    {
        public Enfermedad()
        {
            Poblacionenfermedads = new HashSet<Poblacionenfermedad>();
        }

        public int Id { get; set; }
        public string Tipoenfermedad { get; set; } = null!;

        public virtual ICollection<Poblacionenfermedad> Poblacionenfermedads { get; set; }
    }
}
