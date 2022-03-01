using System;
using System.Collections.Generic;

namespace api_web.Models
{
    public partial class Factorriesgo
    {
        public Factorriesgo()
        {
            Poblacionfactorriesgos = new HashSet<Poblacionfactorriesgo>();
        }

        public int Id { get; set; }
        public string Tipofactorriesgo { get; set; } = null!;

        public virtual ICollection<Poblacionfactorriesgo> Poblacionfactorriesgos { get; set; }
    }
}
