using Microsoft.EntityFrameworkCore;

namespace JobQuest.Models
{
	public class PlatformDbContext : DbContext
	{
		public PlatformDbContext(DbContextOptions<PlatformDbContext> options) : base(options) { }

		public DbSet<Freelancer> Freelancers { get; set; }
		public DbSet<Client> Clients { get; set; }
		public DbSet<Job> Jobs { get; set; }
		public DbSet<Proposal> Proposals { get; set; } 

		public DbSet<Contract> Contracts { get; set; }
		public DbSet<Payment> Payments { get; set; }
	}
}
