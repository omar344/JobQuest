using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace JobQuest.Models
{
	public class Contract
	{
		public int ContractID { get; set; }

		public DateTime StartDate { get; set; }
		public DateTime EndDate { get; set; }
		public string ContractStatus { get; set; }
		public int FreelancerID { get; set; }
		public virtual Freelancer Freelancer { get; set; }
		public int ClientID { get; set; }
		public virtual Client Client { get; set; }
		public virtual Payment Payment { get; set; }
		public virtual ContractOfJob ContractOfJob { get; set; }


	}
}


/*
 Contract
	PK id
	FK freelancer_id
	FK client_id

	ContractStatus
	StartDate
	EndDate

 */