namespace JobQuest.Domain.Entities;

public class Skill
{
    public int SkillID { get; set; }
    public string Name { get; set; } = default!;
    public int FreelancerID { get; set; }
    public virtual Freelancer Freelancer { get; set; } = default!;
}
