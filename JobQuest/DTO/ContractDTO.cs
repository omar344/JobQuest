using System.ComponentModel.DataAnnotations;
using JobQuest.Models;

namespace JobQuest.DTO;

public class ContractDTO
{
        [Required(ErrorMessage = "Start date is required")]
        public DateTime StartDate { get; set; }

        [Required(ErrorMessage = "End date is required")]
        public DateTime EndDate { get; set; }

        public ContractStatus Status { get; set; } = ContractStatus.Active;

        [Required(ErrorMessage = "Freelancer ID is required")]
        public int FreelancerID { get; set; }

        [Required(ErrorMessage = "Client ID is required")]
        public int ClientID { get; set; }
}
