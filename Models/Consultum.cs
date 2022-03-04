using System;
using System.Collections.Generic;

namespace api_web.Models
{
    public partial class Consultum
    {
        public int Id { get; set; }
        public string Tipoconsulta { get; set; } = null!;
    }
}
