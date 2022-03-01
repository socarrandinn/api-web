using System;
using System.Collections.Generic;

namespace api_web.Models
{
    public partial class Poblacionfactorriesgo
    {
        public int Factorriesgoid { get; set; }
        public int Poblacionid { get; set; }
        public int Fecha { get; set; }

        public virtual Factorriesgo Factorriesgo { get; set; } = null!;
        public virtual Poblacion Poblacion { get; set; } = null!;
    }
}
