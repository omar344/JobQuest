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
		[Required]
		public string Country { get; set; }
		[Required]
		public string Phone { get; set; }
	}
}
