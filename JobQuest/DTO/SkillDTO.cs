using System.ComponentModel.DataAnnotations;

namespace JobQuest.DTO;

public class SkillDTO
{
     [Required(ErrorMessage = "Skill name is required")]
     [StringLength(100, MinimumLength = 2, ErrorMessage = "Skill name must be between 2 and 100 characters")]
     public string Name { get; set; }
}