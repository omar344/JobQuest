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

		[ForeignKey("Freelancer")]
		public int FreelancerID { get; set; }

		public virtual Freelancer Freelancer { get; set; }

		[ForeignKey("Job")]
		public int? JobID { get; set; }

		public virtual Job Job { get; set; }

		public Payment Payment { get; set; }
	}
}
