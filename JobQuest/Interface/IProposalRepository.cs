using JobQuest.DTO;
using JobQuest.Models;

namespace JobQuest.Interface;

public interface IProposalRepository
{
    /*
     - proposal create Update delete 
     - constraints for job and proposal {
     * 1-Display the Proposals assigned to the posted job for client, but he can see his proposal that he submitted to job
     * 2-client can select one of them and display it individually then choose to open contract with it or not
     * then he can create contract with freelancer or cancel. after create contract we follow it with status prop.

        - Display all method
        - display individually by id
        - open contract just click
      }  
     */
    Task<Proposal?> GetByIdAsync(int id);
    Task AddAsync(ProposalDTO proposalDto);
    Task DeleteAsync(int id);
    Task UpdateAsync(int id, ProposalDTO proposalDto);

   
}