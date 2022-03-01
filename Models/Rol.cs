using System;
using System.Collections.Generic;

namespace api_web.Models
{
    public partial class Rol
    {
        public Rol()
        {
            Userrols = new HashSet<Userrol>();
        }

        public int Id { get; set; }
        public string Role { get; set; } = null!;
        public string Name { get; set; } = null!;

        public virtual ICollection<Userrol> Userrols { get; set; }
    }
}
