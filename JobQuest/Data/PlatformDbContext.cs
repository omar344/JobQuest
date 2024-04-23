using EntityFramework.Audit;
using JobQuest.Configurations;
using JobQuest.Models;
using Microsoft.EntityFrameworkCore;

namespace JobQuest.Data
{
    public class PlatformDataDbContext : DbContext
    {
        public PlatformDataDbContext()
        {

        }
		public PlatformDataDbContext(DbContextOptions<PlatformDataDbContext> options) : base(options) { }

        public DbSet<Freelancer> Freelancers { get; set; }
        public DbSet<Client> Clients { get; set; }
        public DbSet<Job> Jobs { get; set; }
        public DbSet<Proposal> Proposals { get; set; }
        public DbSet<ContractOfJob> ContractOfJobs { get; set; }
        public DbSet<Skill> Skills { get; set; }
        public DbSet<Contract> Contracts { get; set; }
        public DbSet<Payment> Payments { get; set; }
        public DbSet<ProposalSubmission> ProposalSubmissions { get; set; }

		protected override void OnModelCreating(ModelBuilder modelBuilder)
		{
			new FreelancerConfigurations().Configure(modelBuilder.Entity<Freelancer>());
			new ClientConfiguration().Configure(modelBuilder.Entity<Client>());
			new JobConfigurations().Configure(modelBuilder.Entity<Job>());
			new ContractOfJobConfigurations().Configure(modelBuilder.Entity<ContractOfJob>());
			new PaymentConfigurations().Configure(modelBuilder.Entity<Payment>());
			new SkillConfigurations().Configure(modelBuilder.Entity<Skill>());
			new ProposalSubmissionConfigurations().Configure(modelBuilder.Entity<ProposalSubmission>());
			new ProposalConfigurations().Configure(modelBuilder.Entity<Proposal>());
            new ContractConfigurations().Configure(modelBuilder.Entity<Contract>());
		}
	}    


}
