namespace JobQuest.Domain.Entities;

public class Client : User
{
    public virtual ICollection<Job> Jobs { get; set; } = [];
    public virtual ICollection<Payment> Payments { get; set; } = [];
}
