using JobQuest.Domain.Enums;

namespace JobQuest.Domain.Entities;

public class Proposal
{
    public int ProposalID { get; set; }
    public string ProposalText { get; set; } = default!;
    public decimal BidAmount { get; set; }
    public ProposalStatus Status { get; set; }
    public DateTime SubmittedAt { get; set; }
    public int JobID { get; set; }
    public virtual Job AssociatedJob { get; set; } = default!;
    public int FreelancerID { get; set; }
    public virtual Freelancer Freelancer { get; set; } = default!;
}
