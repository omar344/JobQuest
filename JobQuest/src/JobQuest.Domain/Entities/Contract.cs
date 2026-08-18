using JobQuest.Domain.Enums;

namespace JobQuest.Domain.Entities;

public class Contract
{
    public int ContractID { get; set; }
    public DateTime StartDate { get; set; }
    public DateTime EndDate { get; set; }
    public ContractStatus ContractStatus { get; set; }
    public int FreelancerID { get; set; }
    public virtual Freelancer Freelancer { get; set; } = default!;
    public int ClientID { get; set; }
    public virtual Client Client { get; set; } = default!;
    public virtual Payment? Payment { get; set; }
}
