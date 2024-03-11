using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace JobQuest.Models
{
	public class Freelancer : User
	{
		[Key]
		public int Id { get; set; }

		[Required]
		public string Specialization { get; set; }

		[Required]
		public int HourlyRate { get; set; }

		public string Experience { get; set; }

		public ICollection<Skill> Skills { get; set; }
		public int? AssignedClientId { get; set; }

		[ForeignKey("AssignedClientId")]
		public Client AssignedClient { get; set; }
	    public ICollection<Proposal>Proposals { get; set; }

		public ICollection<Contract> Contracts { get;}
	}
}
