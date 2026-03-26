using System.ComponentModel.DataAnnotations;

namespace MusicianFinder_Back.WebAPI.Dto.Request
{
    public class AuthLoginRequestDto
    {
        [Required]
        public required string Email { get; set; }

        [Required]
        public required string Password { get; set; }
    }

    public class AuthRegisterRequestDto
    {
        [Required]
        [EmailAddress]
        [MaxLength(320)]
        public required string Email { get; set; }

        [MinLength(4)]
        [MaxLength(50)]
        public required string? Username { get; set; }

        [Required]
        [MinLength(8)]
        [RegularExpression("(?=.*[A-Z])(?=.*[a-z])(?=.*[0-9])(?=.*[^A-Za-z0-9]).*")]
        public required string Password { get; set; }

    }
}
