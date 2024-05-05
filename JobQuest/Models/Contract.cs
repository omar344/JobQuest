using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using JobQuest.DTO;

namespace JobQuest.Models
{
	public class Contract
	{
		public int ContractID { get; set; }
		public DateTime StartDate { get; set; }
		public DateTime EndDate { get; set; }
		public ContractStatus ContractStatus { get; set; }
		public int FreelancerID { get; set; }
		public virtual Freelancer Freelancer { get; set; }
		public int ClientID { get; set; }
		public virtual Client Client { get; set; }
		public virtual Payment Payment { get; set; }
		
	}
	public enum ContractStatus
	{
		Active,
		Terminated,
		Completed
	}
}
