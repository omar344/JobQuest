using System.ComponentModel.DataAnnotations;
using JobQuest.Domain.Enums;

namespace JobQuest.Application.DTOs;

public class JobDTO
{
    [Required]
    public int ClientID { get; set; }

    [Required]
    public string JobTitle { get; set; } = default!;

    public string JobDescription { get; set; } = default!;

    [Required]
    public JobCategoryEnum Category { get; set; }

    [Required]
    public int JobBudget { get; set; }

    [Required]
    public string JobTimeline { get; set; } = default!;
}
