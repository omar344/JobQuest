﻿using JobQuest.Data;
using JobQuest.DTO;
using JobQuest.Interface;
using JobQuest.Models;
using Microsoft.EntityFrameworkCore;

namespace JobQuest.Repository;

public class ContractRepository(PlatformDataDbContext context): IContractRepository
{
   public async Task<Contract?> GetById(int id)
   {
       return await context.Contracts.SingleOrDefaultAsync(d => d.ContractID == id);
   }
   public async Task AddAsync(ContractDTO contractDto)
   {
       var contract = new Contract
       {
           StartDate = contractDto.StartDate,
           EndDate = contractDto.EndDate,
           ContractStatus = contractDto.Status,
           FreelancerID = contractDto.FreelancerID,
           ClientID = contractDto.ClientID
       };
        context.Contracts.Add(contract);
        await context.SaveChangesAsync();
   }
   public async Task UpdateAsync(int id, ContractDTO contractDto)
   {
       var postedContract = await GetById(id);

       if (postedContract != null)
       {
           postedContract.StartDate = contractDto.StartDate;
           postedContract.EndDate = contractDto.EndDate;
           postedContract.ContractStatus = contractDto.Status;
           postedContract.FreelancerID = contractDto.FreelancerID;
           postedContract.ClientID = contractDto.ClientID;

           context.Contracts.Update(postedContract);
           await context.SaveChangesAsync();
       }
   }

   public async Task DeleteAsync(int id)
   {
           var contractToDelete = await GetById(id);

           if (contractToDelete != null)
           {
               context.Contracts.Remove(contractToDelete);
               await context.SaveChangesAsync();
           }
       
   }
}