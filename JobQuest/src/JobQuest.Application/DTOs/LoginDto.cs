using System.ComponentModel.DataAnnotations;

namespace JobQuest.Application.DTOs;

public class LoginDto
{
    [Required(ErrorMessage = "Username is required")]
    public string UserName { get; set; } = default!;

    [Required(ErrorMessage = "Password is required")]
    public string Password { get; set; } = default!;
}
