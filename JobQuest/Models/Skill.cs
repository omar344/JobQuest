using System.ComponentModel.DataAnnotations.Schema;

namespace JobQuest.Models
{
	public class Skill
	{
		public int SkillID { get; set; }
		public string Name { get; set; }
		public int FreelancerID { get; set; }
		public virtual Freelancer Freelancer { get; set; }
	}
}