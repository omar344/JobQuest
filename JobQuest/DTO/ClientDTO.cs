using System.ComponentModel.DataAnnotations;

namespace JobQuest.DTO
{
	public class ClientDTO
	{
		[Required]
		public string FirstName { get; set; }
		[Required]
		public string LastName { get; set; }
		[Required]
		public string Email { get; set; }
		public string Address { get; set; }
		public string Phone { get; set; }
	}
}
