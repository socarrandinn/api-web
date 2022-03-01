using System;
using System.Collections.Generic;

namespace api_web.Models
{
    public partial class Intervension
    {
        public Intervension()
        {
            Poblacionintervensions = new HashSet<Poblacionintervension>();
        }

        public int Id { get; set; }
        public int Tipointervension { get; set; }

        public virtual ICollection<Poblacionintervension> Poblacionintervensions { get; set; }
    }
}
