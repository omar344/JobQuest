namespace JobQuest.Domain.Common;

public abstract class Entity
{
    public Guid Id { get; protected set; } = Guid.CreateVersion7();
    public DateTime CreatedAtUtc { get; protected set; } = DateTime.UtcNow;
    public DateTime? LastModifiedAtUtc { get; protected set; }

    protected void Touch() => LastModifiedAtUtc = DateTime.UtcNow;
}