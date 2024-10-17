using JobQuest.Models;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace JobQuest.DTO
{
	public class ClientDTO
	{
        [Required]
        public string FullName { get; set; }
        [Required]
        public string Address { get; set; }
        public DateTime? DateOfBirth { get; set; }

        public string? BillingInformation { get; set; }  
    }
}
