namespace JobQuest.Domain.Entities;

public class Freelancer : User
{
    public string Specialization { get; set; } = default!;
    public int HourlyRate { get; set; }
    public string Experience { get; set; } = default!;

    public virtual ICollection<Contract> Contracts { get; set; } = [];
    public virtual ICollection<Proposal> Proposals { get; set; } = [];
    public virtual ICollection<Skill> FreelancerSkills { get; set; } = [];
}
