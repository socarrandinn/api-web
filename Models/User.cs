using System;
using System.Collections.Generic;

namespace api_web.Models
{
    public partial class User
    {
        public User()
        {
            Hojacargos = new HashSet<Hojacargo>();
            Userrols = new HashSet<Userrol>();
        }

        public int Id { get; set; }
        public string Usuario { get; set; } = null!;
        public string Password { get; set; } = null!;
        public string Nombre { get; set; } = null!;
        public string Apellidos { get; set; } = null!;
        public DateOnly? Fecha { get; set; } 
        public string Email { get; set; } = null!;
        public int Consultoriomedicoid { get; set; }
        
        public virtual Consultoriomedico Consultoriomedico { get; set; } = null!;              
        public virtual ICollection<Hojacargo> Hojacargos { get; set; }
        public virtual ICollection<Userrol> Userrols { get; set; }
    }
}
