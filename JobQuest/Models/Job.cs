using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace JobQuest.Models
{
	public class Job
	{
		[Key]
		public int JobID { get; set; }
		public string JObTitle { get; set; }
		public string JobDescription { get; set; }

		public string JobBudget { get; set; }

		public string JobStatus { get; set; }
		public string JobCategory { get; set; }

		public string JobTimeline { get; set; }
		public int ClientID { get; set; }

		[ForeignKey("ClientID")]
		public Client Client {  get; set; }



	}
}
