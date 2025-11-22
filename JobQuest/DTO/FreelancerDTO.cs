using System.ComponentModel.DataAnnotations;

namespace JobQuest.DTO;

public class FreelancerDTO
{
    [Required(ErrorMessage = "Specialization is required")]
    public string Specialization { get; set; }

    [Required(ErrorMessage = "Hourly rate is required")]
    [Range(1, 10000, ErrorMessage = "Hourly rate must be between 1 and 10000")]
    public int HourlyRate { get; set; }

    [Required(ErrorMessage = "Experience is required")]
    public string Experience { get; set; }

    [Required(ErrorMessage = "Country is required")]
    public string Country { get; set; }

    [Required(ErrorMessage = "Phone is required")]
    [Phone(ErrorMessage = "Invalid phone number")]
    public string Phone { get; set; }

    [Required(ErrorMessage = "First name is required")]
    public string FirstName { get; set; }

    [Required(ErrorMessage = "Last name is required")]
    public string LastName { get; set; }
}