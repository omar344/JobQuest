using System.ComponentModel.DataAnnotations;
using JobQuest.Models;

namespace JobQuest.DTO;

public class ProposalDTO
{
    [Required(ErrorMessage = "Proposal text is required")]
    [StringLength(2000, MinimumLength = 10, ErrorMessage = "Proposal text must be between 10 and 2000 characters")]
    public string ProposalText { get; set; }

    [Required(ErrorMessage = "Bid amount is required")]
    [Range(1, 1000000, ErrorMessage = "Bid amount must be between 1 and 1,000,000")]
    public decimal BidAmount { get; set; }

    [Required(ErrorMessage = "Job ID is required")]
    public int JobID { get; set; }

    [Required(ErrorMessage = "Freelancer ID is required")]
    public int FreelancerID { get; set; }

    public ProposalStatus Status { get; set; } = ProposalStatus.Pending;

    public DateTime SubmittedAt { get; set; } = DateTime.Now;
}