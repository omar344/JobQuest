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

		[Required]
		public decimal Amount { get; set; }

		public int ClientID { get; set; }

		[ForeignKey("ClientID")]
		public Client Payer { get; set; }

		public Contract Contract { get; set; }

	}
}
