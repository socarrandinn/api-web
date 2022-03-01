using System;
using System.Collections.Generic;

namespace api_web.Models
{
    public partial class Poblacion
    {
        public Poblacion()
        {
            Poblacionenfermedads = new HashSet<Poblacionenfermedad>();
            Poblacionfactorriesgos = new HashSet<Poblacionfactorriesgo>();
            Poblacionhojacargos = new HashSet<Poblacionhojacargo>();
            Poblacionintervensions = new HashSet<Poblacionintervension>();
        }

        public int Id { get; set; }
        public string Nombre { get; set; } = null!;
        public string Apellidos { get; set; } = null!;
        public string NoNucleo { get; set; } = null!;
        public string NoVivienda { get; set; } = null!;
        public int Edad { get; set; }
        public string Sexo { get; set; } = null!;
        public DateOnly Fechanecimiento { get; set; }
        public DateOnly Fechahojacargo { get; set; }
        public DateOnly Fechaa { get; set; }
        public int Calleid { get; set; }
        public int Consultoriomedicoid { get; set; }
        public int Grupoid { get; set; }

        public virtual Calle Calle { get; set; } = null!;
        public virtual Consultoriomedico Consultoriomedico { get; set; } = null!;
        public virtual Grupo Grupo { get; set; } = null!;
        public virtual ICollection<Poblacionenfermedad> Poblacionenfermedads { get; set; }
        public virtual ICollection<Poblacionfactorriesgo> Poblacionfactorriesgos { get; set; }
        public virtual ICollection<Poblacionhojacargo> Poblacionhojacargos { get; set; }
        public virtual ICollection<Poblacionintervension> Poblacionintervensions { get; set; }
    }
}
