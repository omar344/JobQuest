using System.ComponentModel.DataAnnotations.Schema;

namespace JobQuest.Models
{
	public class Skill
	{
		public int Id { get; set; }
		public string Name { get; set; }
		public int FreelancerID { get; set; }

		[ForeignKey(nameof(FreelancerID))]
		public Freelancer Freelancer { get; set; }
	}
}