using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace JobQuest.Models
{
	public class Proposal
	{
		public int ProposalID { get; set; }
		public string ProposalText { get; set; }
		public decimal BidAmount { get; set; }
		
		public ProposalStatus Status { get; set; }
		
		public DateTime SubmittedAt { get; set; }
		public int JobID { get; set; }
		public virtual Job AssociatedJob { get; set; }
		public int FreelancerID { get; set; }
		public virtual Freelancer Freelancer { get; set; }
	}

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

}
