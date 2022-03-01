using System;
using System.Collections.Generic;

namespace api_web.Models
{
    public partial class Userrol
    {
        public int Userid { get; set; }
        public int Rolid { get; set; }
        public DateOnly Fecha { get; set; }

        public virtual Rol Rol { get; set; } = null!;
        public virtual User User { get; set; } = null!;
    }
}
