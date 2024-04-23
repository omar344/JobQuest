using JobQuest.Data;
using JobQuest.DTO;
using JobQuest.Interface;
using JobQuest.Models;
using Microsoft.EntityFrameworkCore;

namespace JobQuest.Repository
{
    public class JobRepository:IJobRepository
	{
		PlatformDataDbContext _context;

		public JobRepository(PlatformDataDbContext context)
		{
			_context = context;
		}
		public Job GetById(int id)
		{
			return _context.Jobs.SingleOrDefault(d => d.JobID== id);
		}

		public void Add(JobDTO jobDTO)
		{
			var job = new Job
			{
				JobTitle = jobDTO.JobTitle,
				JobDescription = jobDTO.JobDescription,
				//JobStatus = jobDTO.JobStatus,
				JobCategory = jobDTO.JobCategory,
				JobTimeline = "Test"
			};
			_context.Jobs.Add(job);
			_context.SaveChanges();
		}
		public void Edit(int id, JobDTO job)
		{
			Job postedJob = GetById(id);
			postedJob.JobTitle = job.JobTitle;
			postedJob.JobDescription = job.JobDescription;
			//postedJob.JobStatus = job.JobStatus;
			postedJob.JobCategory = job.JobCategory;

			_context.SaveChanges();
		}

		public void Delete(int id)
		{
			Job postedJob = GetById(id);
			_context.Jobs.Remove(postedJob);
			_context.SaveChanges();	
		}
	}
}
