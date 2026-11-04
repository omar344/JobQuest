using JobQuest.Domain.Enums;

namespace JobQuest.Domain.Entities;

public class Payment
{
    public int PaymentID { get; set; }
    public string PaymentType { get; set; } = default!;
    public DateTime Date { get; set; }
    public PaymentStatus Status { get; set; }
    public decimal Amount { get; set; }
    public int ClientID { get; set; }
    public virtual Client Client { get; set; } = default!;
    public int ContractID { get; set; }
    public virtual Contract Contract { get; set; } = default!;
}
