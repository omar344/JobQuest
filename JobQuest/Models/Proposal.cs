using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace JobQuest.Models
{
	public class Proposal
	{
		public int ProposalID { get; set; }

		[Required(ErrorMessage = "Proposal text is required")]
		public string ProposalText { get; set; }

		[Required(ErrorMessage = "Bid amount is required")]
		public decimal BidAmount { get; set; }

		public DateTime SubmittedAt { get; set; }

		public string Status { get; set; }

		[ForeignKey(nameof(Job))]
		public int JobID { get; set; }
		public virtual Job Job { get; set; }

		[ForeignKey(nameof(Freelancer))]
		public int FreelancerID { get; set; }
		public virtual Freelancer Freelancer { get; set; }
	}
}
