using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace JobQuest.Models
{
	public class Freelancer : User
	{
		[Key]
		public int FreelancerID { get; set; }

		public string Specialization { get; set; }

		public int HourlyRate { get; set; }

		public string Experience { get; set; }
		public int? ClientID { get; set; }

		[ForeignKey("ClientID")]
		public Client Client { get; set; }
	}
}
