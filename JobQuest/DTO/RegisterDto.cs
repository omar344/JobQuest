using System.ComponentModel.DataAnnotations;

namespace JobQuest.DTO
{
    public class RegisterDto
    {
        [Required(ErrorMessage = "Username is required")]
        [StringLength(50, MinimumLength = 3, ErrorMessage = "Username must be between 3 and 50 characters")]
        public string UserName { get; set; }

        [Required(ErrorMessage = "Password is required")]
        [StringLength(100, MinimumLength = 6, ErrorMessage = "Password must be at least 6 characters")]
        public string Password { get; set; }

        [Required(ErrorMessage = "Email is required")]
        [EmailAddress(ErrorMessage = "Invalid email address")]
        public string Email { get; set; }

        [RegularExpression("^(Client|Freelancer|Admin)$", ErrorMessage = "Role must be either 'Client', 'Freelancer', or 'Admin'")]
        public string? Role { get; set; } // "Client" or "Freelancer"
    }
}
