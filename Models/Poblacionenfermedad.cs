using System;
using System.Collections.Generic;

namespace api_web.Models
{
    public partial class Poblacionenfermedad
    {
        public int Enfermedadid { get; set; }
        public int Poblacionid { get; set; }
        public DateOnly Fecha { get; set; }

        public virtual Enfermedad Enfermedad { get; set; } = null!;
        public virtual Poblacion Poblacion { get; set; } = null!;
    }
}
