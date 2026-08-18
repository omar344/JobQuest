using System.ComponentModel.DataAnnotations;

namespace JobQuest.Application.DTOs;

public class ClientDTO
{
    [Required(ErrorMessage = "First name is required")]
    public string FirstName { get; set; } = default!;

    [Required(ErrorMessage = "Last name is required")]
    public string LastName { get; set; } = default!;

    [Required(ErrorMessage = "Email is required")]
    [EmailAddress(ErrorMessage = "Invalid email address")]
    public string Email { get; set; } = default!;

    [Required(ErrorMessage = "Country is required")]
    public string Country { get; set; } = default!;

    [Required(ErrorMessage = "Phone is required")]
    [Phone(ErrorMessage = "Invalid phone number")]
    public string Phone { get; set; } = default!;
}
