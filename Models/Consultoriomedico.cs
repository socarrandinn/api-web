using System;
using System.Collections.Generic;

namespace api_web.Models
{
    public partial class Consultoriomedico
    {
        public Consultoriomedico()
        {
            Hojacargos = new HashSet<Hojacargo>();
            Poblacions = new HashSet<Poblacion>();
            Users = new HashSet<User>();
        }

        public int Id { get; set; }
        public string Nombre { get; set; } = null!;

        public virtual ICollection<Hojacargo> Hojacargos { get; set; }
        public virtual ICollection<Poblacion> Poblacions { get; set; }
        public virtual ICollection<User> Users { get; set; }
    }
}
