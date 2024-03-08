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

		public int? AssignedClientId { get; set; }

		[ForeignKey("AssignedClientId")]
		public Client AssignedClient { get; set; }
	}
}
