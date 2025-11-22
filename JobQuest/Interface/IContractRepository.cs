using System.Diagnostics.Contracts;
using JobQuest.DTO;
using JobQuest.Models;

namespace JobQuest.Interface;

public interface IContractRepository
{
    Task<Models.Contract?> GetById(int id);
    Task<List<Models.Contract>> GetAllAsync();
    Task<List<Models.Contract>> GetContractsByClientIdAsync(int clientId);
    Task<List<Models.Contract>> GetContractsByFreelancerIdAsync(int freelancerId);
    Task AddAsync(ContractDTO contractDto);
    Task UpdateAsync(int id, ContractDTO contractDto);
    Task DeleteAsync(int id);
}