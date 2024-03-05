using Microsoft.EntityFrameworkCore;
using System.Runtime.Intrinsics.Arm;

namespace JobQuest.Models
{
	public class PlatformDbContext:DbContext
	{
		public DbSet<Freelancer> Freelancers { get; set; }

		public DbSet<Client> Clients { get; set; }
		public DbSet<Job> Jobs { get; set; }


		protected override void OnConfiguring(DbContextOptionsBuilder options) =>
			options.UseSqlServer("Data Source=OMAR;Initial Catalog=PlatformDB;Integrated Security=True;Trust Server Certificate=True");

		
	}
}
