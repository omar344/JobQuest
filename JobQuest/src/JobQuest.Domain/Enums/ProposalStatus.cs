using System.ComponentModel.DataAnnotations;

namespace JobQuest.Domain.Enums;

public enum ProposalStatus
{
    [Display(Name = "Pending")]
    Pending,
    [Display(Name = "Accepted")]
    Accepted,
    [Display(Name = "Rejected")]
    Rejected,
    [Display(Name = "Withdrawn")]
    Withdrawn,
    [Display(Name = "Expired")]
    Expired
}
