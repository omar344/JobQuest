using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace JobQuest.Models
{
	public class Contract
	{
		[Key]
		public int ContractID { get; set; }

		[Required]
		public string PaymentStatus { get; set; }

		[Required]
		public DateTime StartDate { get; set; }

		[Required]
		public DateTime EndDate { get; set; }

		[Required]
		public string ContractStatus { get; set; }

		public string ScopeOfWork { get; set; }

		[ForeignKey("Client")]
		public int ClientID { get; set; }
		public Client Client { get; set; }

		[ForeignKey("Freelancer")]
		public int FreelancerID { get; set; }
		public Freelancer Freelancer { get; set; }

		[ForeignKey("Job")]
		public int JobID { get; set; }
		public Job Job { get; set; }

		[ForeignKey("Payment")]
		public int PaymentID { get; set; }
		public Payment Payment { get; set; }
	}
}
