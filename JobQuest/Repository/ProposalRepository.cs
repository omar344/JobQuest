using JobQuest.Data;
using JobQuest.DTO;
using JobQuest.Interface;
using JobQuest.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace JobQuest.Repository;

public class ProposalRepository(PlatformDataDbContext context) : IProposalRepository
{
    public async Task<Proposal?> GetByIdAsync(int id)
    {
        return await context.Proposals.SingleOrDefaultAsync(d => d.ProposalID == id) ;
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

    public async Task UpdateAsync(int id,ProposalDTO proposalDto)
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