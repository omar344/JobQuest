using JobQuest.Application.DTOs;
using JobQuest.Domain.Entities;

namespace JobQuest.Application.Interfaces;

public interface IContractRepository
{
    Task<Contract?> GetById(int id);
    Task<List<Contract>> GetAllAsync();
    Task<List<Contract>> GetContractsByClientIdAsync(int clientId);
    Task<List<Contract>> GetContractsByFreelancerIdAsync(int freelancerId);
    Task AddAsync(ContractDTO contractDto);
    Task UpdateAsync(int id, ContractDTO contractDto);
    Task DeleteAsync(int id);
}
