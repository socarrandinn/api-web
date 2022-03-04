using System.ComponentModel.DataAnnotations;

namespace api_web.DTOs.Users
{
    public class UserLoginDTO
    {
        [Required]
        public string Usuario { get; set; } = null!;

        [Required]
        public string Password { get; set; } = null!;

    }
}
