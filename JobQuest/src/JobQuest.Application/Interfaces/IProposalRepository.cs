using JobQuest.Application.DTOs;
using JobQuest.Domain.Entities;

namespace JobQuest.Application.Interfaces;

public interface IProposalRepository
{
    Task<Proposal?> GetByIdAsync(int id);
    Task<List<Proposal>> GetAllAsync();
    Task<List<Proposal>> GetProposalsByJobIdAsync(int jobId);
    Task<List<Proposal>> GetProposalsByFreelancerIdAsync(int freelancerId);
    Task AddAsync(ProposalDTO proposalDto);
    Task DeleteAsync(int id);
    Task UpdateAsync(int id, ProposalDTO proposalDto);
}
