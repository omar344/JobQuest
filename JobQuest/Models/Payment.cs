using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace JobQuest.Models
{
	public class Payment
	{
		public int PaymentID { get; set; }
		public string PaymentType{ get; set; }
		public DateTime Date { get; set; }
		public string Status { get; set; }
		public decimal Amount { get; set; }
		public int ClientID { get; set; }
		public virtual Client Client { get; set; }
		public int ContractID { get; set; }
		public virtual Contract Contract { get; set; }
	}
}
																									