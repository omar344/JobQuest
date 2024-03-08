using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace JobQuest.Models
{
	public class Proposal
	{
		public int ProposalID { get; set; }

		public string ProposalText { get; set; }

		public decimal BidAmount { get; set; }

		public DateTime SubmittedAt { get; set; }

		public string Status { get; set; }

		public int JobID { get; set; }

		[ForeignKey("JobID")]
		public Job Job { get; set; }

		public int FreelancerID { get; set; }

		[ForeignKey("FreelancerID")]
		public Freelancer Freelancer { get; set; }
	}
}
