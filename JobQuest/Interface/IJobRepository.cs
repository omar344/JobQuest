using System.Threading.Tasks;
using JobQuest.DTO;
using JobQuest.Models;

namespace JobQuest.Interface
{
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
}
