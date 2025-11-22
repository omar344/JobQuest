using System.ComponentModel.DataAnnotations;

namespace JobQuest.DTO
{
	public class ClientDTO
	{
		[Required(ErrorMessage = "First name is required")]
		public string FirstName { get; set; }

		[Required(ErrorMessage = "Last name is required")]
		public string LastName { get; set; }

		[Required(ErrorMessage = "Email is required")]
		[EmailAddress(ErrorMessage = "Invalid email address")]
		public string Email { get; set; }

		[Required(ErrorMessage = "Country is required")]
		public string Country { get; set; }

		[Required(ErrorMessage = "Phone is required")]
		[Phone(ErrorMessage = "Invalid phone number")]
		public string Phone { get; set; }
	}
}
