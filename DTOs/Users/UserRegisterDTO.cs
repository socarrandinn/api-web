using System.ComponentModel.DataAnnotations;

namespace api_web.DTOs.Users
{
    public class UserRegisterDTO
    {
        [Required]
        public string Usuario { get; set; } = null!;

        [Required]
        public string Password { get; set; } = null!;

        [Required]
        public string Email { get; set; } = null!;

        [Required]
        public int Consultoriomedicoid { get; set; }

    }

    public class Jwt
    {
        public string key { get; set; } 
        public string Issuer { get; set; }
        public string Audience { get; set; }
        public string Subject { get; set; }

    }
}


//[ScaffoldColumn(false)]
//[DatabaseGenerated(DatabaseGeneratedOption.Identity)] 