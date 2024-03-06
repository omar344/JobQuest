using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Diagnostics.Contracts;

namespace JobQuest.Models
{
	public class Payment
	{
		[Key]
		public int PaymentID { get; set; }
	    public string PaymentMethod { get; set; }
	    public DateTime Date { get; set; }
		public string Status { get; set; }
		public string Amount { get; set; }

		public int ClientID { get; set; }

		[ForeignKey("ClientID")]
		public Client Client { get; set; }
		public int ContractID { get; set; }

		[ForeignKey("ContractID")]
		public Contract Contract { get; set; }
	}
}
