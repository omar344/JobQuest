using JobQuest.Application.DTOs;
using JobQuest.Domain.Entities;
using JobQuest.Domain.Enums;

namespace JobQuest.Application.Interfaces;

public interface IJobRepository
{
    Task<Job?> GetByIdAsync(int id);
    Task<List<Job?>> GetAllAsync();
    Task AddAsync(JobDTO job);
    Task EditAsync(int id, JobDTO job);
    Task DeleteAsync(int id);
    Task<List<Job?>> GetJobsByCategory(JobCategoryEnum category);
    Task<List<Job?>> GetJobByBudget(int budget, bool select);
}
