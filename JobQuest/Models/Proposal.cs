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
		public int JobID { get; set; }
		public virtual Job AssociatedJob { get; set; }
		public int FreelancerID { get; set; }
		public virtual Freelancer Freelancer { get; set; }
		public virtual ICollection<ProposalSubmission> ProposalSubmissions { get; set;}
	}
}
