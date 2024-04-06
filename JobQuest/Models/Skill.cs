using System.ComponentModel.DataAnnotations.Schema;

namespace JobQuest.Models
{
	public class Skill
	{
		public int Id { get; set; }
		public string Name { get; set; }
		[ForeignKey(nameof(Freelancer))]
		public int FreelancerID { get; set; }
		public virtual Freelancer Freelancer { get; set; }
	}
}