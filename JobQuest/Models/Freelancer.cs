using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace JobQuest.Models
{
	public class Freelancer : User
	{
		public string Specialization { get; set; }

		public int HourlyRate { get; set; }

		public string Experience { get; set; }

		public ICollection<Skill> Skills { get; set; }
		[ForeignKey("AssignedClient")]
		public  int AssignedClientId { get; set; }
		public virtual Client AssignedClient { get; set; }
	    public virtual ICollection<Proposal>Proposals { get; set; }

		//public virtual ICollection<Contract> Contracts { get;}
	}
}
