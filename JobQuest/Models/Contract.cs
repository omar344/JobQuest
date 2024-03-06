using System.ComponentModel.DataAnnotations.Schema;

namespace JobQuest.Models
{
	public class Contract
	{
		public int ContractID { get; set; }
		public string PaymentStatus { get; set; }
		public DateTime StartDate { get; set; }
		public DateTime EndDate { get; set; }
		public string ContractStatus { get; set; }
        public string  ScopeOfWork { get; set; }
		public int ClientID { get; set; }

		[ForeignKey("ClientID")]
		public Client Client { get; set; }

		public int FreelancerID { get; set; }

		[ForeignKey("FreelancerID")]
		public Freelancer Freelancer { get; set; }

		public int JobID { get; set; }

		[ForeignKey("JobID")]
		public Job Job { get; set; }
	}
}
