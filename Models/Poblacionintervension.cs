using System;
using System.Collections.Generic;

namespace api_web.Models
{
    public partial class Poblacionintervension
    {
        public int Intervensionid { get; set; }
        public int Poblacionid { get; set; }
        public DateOnly Fecha { get; set; }

        public virtual Intervension Intervension { get; set; } = null!;
        public virtual Poblacion Poblacion { get; set; } = null!;
    }
}
