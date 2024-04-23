using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace JobQuest.Models
{
	public class Job
	{
		public int JobID { get; set; }
		public string JobTitle { get; set; }
		public string JobDescription { get; set; }
		public decimal JobBudget { get; set; }
		public string JobCategory { get; set; }
		public string JobTimeline { get; set; }
		public int ClientID { get; set; }
		public virtual Client Client { get; set; }
		public virtual ContractOfJob ContractOfJob { get; set; }
		public virtual ICollection<Proposal> Proposals { get; set; }
		public virtual ICollection<ProposalSubmission> ProposalSubmissions { get; set; }
	}
}

/*
 JobTimeline
JobDescription
JobDescription
JobBudget
JobTitle
 */