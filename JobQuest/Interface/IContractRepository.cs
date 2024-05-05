using System.Diagnostics.Contracts;
using JobQuest.DTO;
using JobQuest.Models;

namespace JobQuest.Interface;

public interface IContractRepository
{
    Task<Models.Contract?> GetById(int id);
    Task AddAsync (ContractDTO contractDto);
    Task UpdateAsync(int id, ContractDTO contractDto);
    Task DeleteAsync(int id);
}