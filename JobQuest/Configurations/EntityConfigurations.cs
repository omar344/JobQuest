using JobQuest.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace JobQuest.Configurations
{
	public class ContractConfigurations : IEntityTypeConfiguration<Contract>
	{
		public void Configure(EntityTypeBuilder<Contract> builder)
		{
			builder
				.HasKey(c => c.ContractID);

			builder.HasOne(c => c.Freelancer)
				.WithMany(f => f.Contracts)
				.HasForeignKey(c => c.FreelancerID);
			builder
				.Property(p => p.StartDate)
				.IsRequired();
			builder
				.Property(p => p.EndDate)
				.IsRequired();
			builder
				.Property(p => p.ContractStatus)
				.IsRequired();
		}
	}

	public class ClientConfiguration : IEntityTypeConfiguration<Client>
	{
		public void Configure(EntityTypeBuilder<Client> builder)
		{
			builder
				.HasKey(key => key.Id);
		}
	}

	public class FreelancerConfigurations : IEntityTypeConfiguration<Freelancer>
	{
		public void Configure(EntityTypeBuilder<Freelancer> builder)
		{
			builder 
				.HasKey(key => key.Id);
			builder
				.Property(s => s.Specialization)
				.IsRequired();
			builder
				.Property(h => h.HourlyRate)
				.IsRequired();
			builder
				.Property(e => e.Experience)
				.IsRequired();
		}
	}

	public class ContractOfJobConfigurations : IEntityTypeConfiguration<ContractOfJob>
	{
		public void Configure(EntityTypeBuilder<ContractOfJob> builder)
		{
			builder
				.HasKey(p => new { p.JobID, p.ContractID });
          builder
				.HasOne(pt => pt.Job)
			    .WithOne(p => p.ContractOfJob)
			   .HasForeignKey<Job>(j => j.JobID)
			   .HasPrincipalKey<ContractOfJob>(pt => pt.JobID);
		}
	}

	public class JobConfigurations : IEntityTypeConfiguration<Job>
	{
		public void Configure(EntityTypeBuilder<Job> builder)
		{
			builder
				.HasKey(pt => pt.JobID);
			builder
				.Property(p => p.JobTitle)
				.IsRequired();
			builder
				.Property(p => p.JobBudget)
				.IsRequired();
			builder
				.Property(p => p.JobTimeline)
				.IsRequired();
			builder
				.Property(p => p.JobCategory)
				.IsRequired();
			builder.Property(p => p.JobDescription)
				.IsRequired();
		}
	}

	public class PaymentConfigurations : IEntityTypeConfiguration<Payment>
	{
		public void Configure(EntityTypeBuilder<Payment> builder)
		{
			builder
				.HasKey(pt => pt.PaymentID);
			builder
				.HasOne(pt => pt.Contract)
				.WithOne(p => p.Payment)
				.HasForeignKey<Contract>(fk => fk.ContractID)
				.IsRequired();
			builder
				.HasOne(c => c.Client)
				.WithMany(p => p.Payments)
				.HasForeignKey(fk => fk.ClientID)
				.IsRequired();
			builder
				.Property(p => p.PaymentType)
				.IsRequired();
			builder
				.Property(p => p.Status)
				.IsRequired();
			builder
				.Property(p => p.Amount)
				.IsRequired();
			builder
				.Property(p => p.Date)
				.IsRequired();
		}
	}

	public class ProposalConfigurations : IEntityTypeConfiguration<Proposal>
	{
		public void Configure(EntityTypeBuilder<Proposal> builder)
		{
			builder
				.HasKey(pt => pt.ProposalID);
			builder
				.HasOne(pt => pt.Freelancer)
				.WithMany(p => p.Proposals)
				.HasForeignKey(fk => fk.FreelancerID);
			builder
				.HasOne(p => p.AssociatedJob)
				.WithMany(p => p.Proposals)
				.HasForeignKey(fk => fk.JobID);
			builder
				.Property(p => p.ProposalText)
				.IsRequired();
			builder
				.Property(p => p.BidAmount)
				.IsRequired();
		}
	}

	public class ProposalSubmissionConfigurations : IEntityTypeConfiguration<ProposalSubmission>
	{
		public void Configure(EntityTypeBuilder<ProposalSubmission> builder)
		{
			builder
				.HasKey(pt => new {pt.ProposalID,pt.jobID});
			builder
				.HasOne(pt => pt.Job)
				.WithMany(p => p.ProposalSubmissions)
				.HasForeignKey(fk => fk.jobID);
			builder
				.HasOne(p => p.Proposal)
				.WithMany(p => p.ProposalSubmissions)
				.HasForeignKey(fk => fk.ProposalID);
			builder
				.Property(p => p.SubmittedAt)
				.IsRequired();
			builder
				.Property(p => p.Status)
				.IsRequired();
		}
	}

	public class SkillConfigurations : IEntityTypeConfiguration<Skill>
	{
		public void Configure(EntityTypeBuilder<Skill> builder)
		{
			builder
				.HasKey(p => p.SkillID);

			builder.HasOne(c => c.Freelancer)
				.WithMany(f => f.FreelancerSkills)
				.HasForeignKey(c => c.FreelancerID);
			builder
				.Property(p => p.Name)
				.IsRequired();
		}
	}

}
