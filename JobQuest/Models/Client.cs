using System.Collections.Generic;

namespace JobQuest.Models
{
	public class Client : User
	{

		public virtual ICollection<Job> Jobs { get; set; }
		public virtual ICollection<Payment> Payments { get; set; }
	}
}
