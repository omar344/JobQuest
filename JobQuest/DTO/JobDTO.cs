using System.ComponentModel.DataAnnotations;

namespace JobQuest.DTO
{
	public class JobDTO
	{
		[Required]
		public string JobTitle { get; set; }
		[Required]
		public string JobDescription { get; set; }
		[Required]
		public string JobStatus { get; set; }
		[Required]
		public string JobCategory { get; set; }
	}
}
