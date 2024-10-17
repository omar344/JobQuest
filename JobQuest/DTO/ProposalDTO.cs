using JobQuest.Models;

namespace JobQuest.DTO;

public class ProposalDTO
{
    public string ProposalText { get; set; }
    public decimal BidAmount { get; set; }
    public int JobID { get; set; }
    public string FreelancerID { get; set; }
    public ProposalStatus Status { get; set; }
    public DateTime SubmittedAt { get; set; }
}