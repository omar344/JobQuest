using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace JobQuest.Models
{
	public class Freelancer
	{
        [Key]
        public string ApplicationUserId { get; set; }

        [MaxLength(255)]
        public string PortfolioURL { get; set; }
        public string Specialization { get; set; }
        public string? Experience { get; set; }

        public int HourlyRate { get; set; }

        [ForeignKey("ApplicationUserId")]
        public virtual ApplicationUser ApplicationUser { get; set; }
        public virtual ICollection<Contract> Contracts { get; set; }
		public virtual ICollection<Proposal> Proposals { get; set; }
		public virtual ICollection<Skill>FreelancerSkills { get; set; }
	}
}
