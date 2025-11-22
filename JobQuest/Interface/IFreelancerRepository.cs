using JobQuest.DTO;
using JobQuest.Models;

namespace JobQuest.Interface;

public interface IFreelancerRepository
{
    Task<Freelancer> GetAsync(int id);
    Task<List<Freelancer>> GetAllAsync();
    Task AddAsync(FreelancerDTO freelancerDto);
    Task DeleteAsync(int id);
    Task UpdateAsync(int id, FreelancerDTO freelancerDto);
    Task AddSkillAsync(int freelancerId, SkillDTO skillDto);

    Task RemoveSkillAsync(int freelancerId, int skillId);
}