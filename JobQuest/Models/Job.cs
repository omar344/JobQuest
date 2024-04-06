using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace JobQuest.Models
{
	public class Job
	{
		[Key]
		public int JobID { get; set; }
		public string JobTitle { get; set; }
		public string JobDescription { get; set; }

		public decimal JobBudget { get; set; }
		public string JobStatus { get; set; }
		public string JobCategory { get; set; }
		public string JobTimeline { get; set; }

		[ForeignKey("Client")]
		public int? ClientID { get; set; }
		public virtual Client Client { get; set; }
		public virtual ICollection<Contract> Contracts { get; set; }
		public virtual ICollection<Proposal> Proposals { get; set; }
	}
}
