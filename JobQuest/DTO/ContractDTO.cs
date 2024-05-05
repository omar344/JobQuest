using JobQuest.Models;

namespace JobQuest.DTO;

public class ContractDTO
{
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public ContractStatus Status { get; set; }
        public int FreelancerID { get; set; }
        public int ClientID { get; set; }

}
