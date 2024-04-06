using System.Collections.Generic;

namespace JobQuest.Models
{
	public class Client : User
	{
		public virtual ICollection<Freelancer> Freelancers { get; set; }
		public virtual ICollection<Payment> PaymentOperations { get; set; }
		public virtual ICollection<Contract> Contracts { get; set; }
		public virtual ICollection<Job> Jobs { get; set; }
	}
}
