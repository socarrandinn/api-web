using System.ComponentModel.DataAnnotations;

namespace api_web.DTOs.Users
{
    public class UserDTO
    {
        public int Id { get; set; }

        [Required]
        public string Usuario { get; set; } = null!;

        [Required]
        public string Password { get; set; } = null!;

        [Required]
        public string Nombre { get; set; } = null!;

        [Required]
        public string Apellidos { get; set; } = null!;

        [Required]
        public DateOnly? Fecha { get; set; }

        [Required]
        [EmailAddress]
        [StringLength(100, ErrorMessage = "El Correo es requerido")]
        public string Email { get; set; } = null!;

        [Required]        
        public virtual ConsultoriomedicoDTO Consultoriomedico { get; set; } = null!;

    }
}
