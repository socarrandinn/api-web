using System;
using System.Collections.Generic;

namespace api_web.Models
{
    public partial class Poblacionhojacargo
    {
        public int Hojacargoid { get; set; }
        public int Poblacionid { get; set; }
        public string Numhc { get; set; } = null!;
        public string Problemasalud { get; set; } = null!;
        public string Conducta { get; set; } = null!;
        public int Consultaid { get; set; }

        public virtual Consulta Consulta { get; set; } = null!;
        public virtual Hojacargo Hojacargo { get; set; } = null!;
        public virtual Poblacion Poblacion { get; set; } = null!;
    }
}
