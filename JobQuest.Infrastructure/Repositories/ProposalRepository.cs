using JobQuest.Application.DTOs;
using JobQuest.Application.Interfaces;
using JobQuest.Domain.Entities;
using JobQuest.Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;

namespace JobQuest.Infrastructure.Repositories;

public class ProposalRepository(PlatformDataDbContext context) : IProposalRepository
{
    public async Task<Proposal?> GetByIdAsync(int id)
    {
        return await context.Proposals.SingleOrDefaultAsync(d => d.ProposalID == id);
    }

    public async Task<List<Proposal>> GetAllAsync()
    {
        return await context.Proposals.Include(p => p.Freelancer).Include(p => p.AssociatedJob).ToListAsync();
    }

    public async Task<List<Proposal>> GetProposalsByJobIdAsync(int jobId)
    {
        return await context.Proposals
            .Include(p => p.Freelancer)
            .Where(p => p.JobID == jobId)
            .ToListAsync();
    }

    public async Task<List<Proposal>> GetProposalsByFreelancerIdAsync(int freelancerId)
    {
        return await context.Proposals
            .Include(p => p.AssociatedJob)
            .Where(p => p.FreelancerID == freelancerId)
            .ToListAsync();
    }

    public async Task AddAsync(ProposalDTO proposalDto)
    {
        var proposal = new Proposal
        {
            ProposalText = proposalDto.ProposalText,
            BidAmount = proposalDto.BidAmount,
            JobID = proposalDto.JobID,
            FreelancerID = proposalDto.FreelancerID,
            SubmittedAt = proposalDto.SubmittedAt,
            Status = proposalDto.Status
        };

        context.Proposals.Add(proposal);
        await context.SaveChangesAsync();
    }

    public async Task UpdateAsync(int id, ProposalDTO proposalDto)
    {
        var postedProposal = await GetByIdAsync(id);

        if (postedProposal != null)
        {
            postedProposal.ProposalText = proposalDto.ProposalText;
            postedProposal.BidAmount = proposalDto.BidAmount;
            postedProposal.JobID = proposalDto.JobID;
            postedProposal.FreelancerID = proposalDto.FreelancerID;
            postedProposal.SubmittedAt = proposalDto.SubmittedAt;
            postedProposal.Status = proposalDto.Status;

            context.Proposals.Update(postedProposal);
            await context.SaveChangesAsync();
        }
    }

    public async Task DeleteAsync(int id)
    {
        var proposalToDelete = await GetByIdAsync(id);

        if (proposalToDelete != null)
        {
            context.Proposals.Remove(proposalToDelete);
            await context.SaveChangesAsync();
        }
    }
}
