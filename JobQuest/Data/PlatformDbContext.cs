using JobQuest.Models;
using Microsoft.EntityFrameworkCore;

namespace JobQuest.Data
{
    public class PlatformDbContext : DbContext
    {
        public PlatformDbContext()
        {

        }
        public PlatformDbContext(DbContextOptions<PlatformDbContext> options) : base(options) { }

        public DbSet<Freelancer> Freelancers { get; set; }
        public DbSet<Client> Clients { get; set; }
        public DbSet<Job> Jobs { get; set; }
        public DbSet<Proposal> Proposals { get; set; }

        public DbSet<Skill> Skills { get; set; }
        public DbSet<Contract> Contracts { get; set; }
        public DbSet<Payment> Payments { get; set; }
    }
}
