using JobQuest.Domain.Enums;

namespace JobQuest.Domain.Entities;

public class Job
{
    public int JobID { get; set; }
    public string JobTitle { get; set; } = default!;
    public string JobDescription { get; set; } = default!;
    public decimal JobBudget { get; set; }
    public JobCategoryEnum JobCategory { get; set; }
    public string JobTimeline { get; set; } = default!;
    public int ClientID { get; set; }
    public virtual Client Client { get; set; } = default!;
    public virtual ICollection<Proposal> Proposals { get; set; } = [];
}
