using JobQuest.Configurations;
using JobQuest.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace JobQuest.Data
{
	public class PlatformDataDbContext : IdentityDbContext<ApplicationUser>
    {
        public PlatformDataDbContext()
        {

        }
		public PlatformDataDbContext(DbContextOptions<PlatformDataDbContext> options) : base(options) { }
        public DbSet<Admin>Admins { get; set; }
        public DbSet<Freelancer> Freelancers { get; set; }
        public DbSet<Client> Clients { get; set; }
        public DbSet<Job?> Jobs { get; set; }
        public DbSet<Proposal> Proposals { get; set; }
        public DbSet<Skill> Skills { get; set; }
        public DbSet<Contract> Contracts { get; set; }
        public DbSet<Payment> Payments { get; set; }

		protected override void OnModelCreating(ModelBuilder modelBuilder)
		{
            base.OnModelCreating(modelBuilder);
            new AdminConfigurations().Configure(modelBuilder.Entity<Admin>());
            new FreelancerConfigurations().Configure(modelBuilder.Entity<Freelancer>());
			new ClientConfiguration().Configure(modelBuilder.Entity<Client>());
			new JobConfigurations().Configure(modelBuilder.Entity<Job>());
			new PaymentConfigurations().Configure(modelBuilder.Entity<Payment>());
			new SkillConfigurations().Configure(modelBuilder.Entity<Skill>());
			new ProposalConfigurations().Configure(modelBuilder.Entity<Proposal>());
            new ContractConfigurations().Configure(modelBuilder.Entity<Contract>());
		}
	}    


}
