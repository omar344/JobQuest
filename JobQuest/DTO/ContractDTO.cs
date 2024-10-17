using JobQuest.Models;

namespace JobQuest.DTO;

public class ContractDTO
{
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public ContractStatus Status { get; set; }
        public string FreelancerID { get; set; }
        public string ClientID { get; set; }

}
