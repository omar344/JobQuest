using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace JobQuest.Models
{
	public class Payment
	{
		[Key]
		public int PaymentID { get; set; }

		[Required]
		public string PaymentMethod { get; set; }

		[Required]
		public DateTime Date { get; set; }

		[Required]
		public string Status { get; set; }

		[Required(ErrorMessage = "Payment amount is required")]
		public decimal Amount { get; set; }

		[ForeignKey(nameof(Payer))]
		public int ClientID { get; set; }
		public virtual Client Payer { get; set; }

		[ForeignKey(nameof(Contract))]
		public int ContractID { get; set; }

		public Contract Contract { get; set; }
	}
}
