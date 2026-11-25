using JobQuest.Domain.Entities;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace JobQuest.Infrastructure.Persistence;

public class PlatformDataDbContext : IdentityDbContext<ApplicationUser>
{

    public PlatformDataDbContext(DbContextOptions<PlatformDataDbContext> options) : base(options)
    {
    }

    public DbSet<Freelancer> Freelancers { get; set; }
    public DbSet<Client> Clients { get; set; }
    public DbSet<Job> Jobs { get; set; }
    public DbSet<Proposal> Proposals { get; set; }
    public DbSet<Skill> Skills { get; set; }
    public DbSet<Contract> Contracts { get; set; }
    public DbSet<Payment> Payments { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(PlatformDataDbContext).Assembly);

        modelBuilder.Entity<Payment>()
            .HasOne(p => p.Contract)
            .WithMany(c => c.Payments)
            .HasForeignKey(p => p.ContractID)
            .OnDelete(DeleteBehavior.NoAction);

        modelBuilder.Entity<Job>()
.Property(j => j.JobBudget)
.HasPrecision(18, 2);

        modelBuilder.Entity<Payment>()
            .Property(p => p.Amount)
            .HasPrecision(18, 2);

        modelBuilder.Entity<Proposal>()
            .Property(p => p.BidAmount)
            .HasPrecision(18, 2);

    }
}