using JobQuest.Application.DTOs;
using JobQuest.Application.Interfaces;
using JobQuest.Domain.Entities;
using JobQuest.Domain.Enums;
using JobQuest.Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;

namespace JobQuest.Infrastructure.Repositories;

public class JobRepository(PlatformDataDbContext context) : IJobRepository
{
    public async Task<Job?> GetByIdAsync(int id)
    {
        return await context.Jobs.SingleOrDefaultAsync(d => d.JobID == id);
    }

    public async Task<List<Job?>> GetAllAsync()
    {
        return await context.Jobs.Cast<Job?>().ToListAsync();
    }

    public async Task AddAsync(JobDTO jobDto)
    {
        var job = new Job
        {
            ClientID = jobDto.ClientID,
            JobTitle = jobDto.JobTitle,
            JobDescription = jobDto.JobDescription,
            JobCategory = jobDto.Category,
            JobBudget = jobDto.JobBudget,
            JobTimeline = jobDto.JobTimeline
        };

        context.Jobs.Add(job);
        await context.SaveChangesAsync();
    }

    public async Task EditAsync(int id, JobDTO jobDto)
    {
        Job? postedJob = await GetByIdAsync(id);
        if (postedJob != null)
        {
            postedJob.JobTitle = jobDto.JobTitle;
            postedJob.JobDescription = jobDto.JobDescription;
            postedJob.JobCategory = jobDto.Category;
            postedJob.JobBudget = jobDto.JobBudget;
            postedJob.JobTimeline = jobDto.JobTimeline;

            await context.SaveChangesAsync();
        }
    }

    public async Task DeleteAsync(int id)
    {
        Job? postedJob = await GetByIdAsync(id);
        if (postedJob != null)
        {
            context.Jobs.Remove(postedJob);
            await context.SaveChangesAsync();
        }
    }

    public async Task<List<Job?>> GetJobsByCategory(JobCategoryEnum category)
    {
        return await context.Jobs.Where(j => j.JobCategory == category).Cast<Job?>().ToListAsync();
    }

    public async Task<List<Job?>> GetJobByBudget(int budget, bool select)
    {
        if (select)
            return await context.Jobs.Where(j => j.JobBudget <= budget).Cast<Job?>().ToListAsync();
        else
            return await context.Jobs.Where(j => j.JobBudget >= budget).Cast<Job?>().ToListAsync();
    }
}
