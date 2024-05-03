using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;

namespace JobQuest.DTO
{
	public class JobDTO
	{
		[Required]
		public int ClientID { get; set; }
		[Required]
		public string JobTitle { get; set; }
		public string JobDescription { get; set; }
		[Required]
		public JobCategoryEnum Category { get; set; }
		[Required]
		public int JobBudget { get; set; }
		[Required]
		public string JobTimeline { get; set; }
	}

}
