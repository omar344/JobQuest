using JobQuest.Data;
using JobQuest.DTO;
using JobQuest.Interface;
using JobQuest.Models;
using Microsoft.EntityFrameworkCore;

namespace JobQuest.Repository;

public class FreelancerRepository(PlatformDataDbContext context): IFreelancerRepository
{
   public async Task<Freelancer> GetAsync(int id)
   {
      return await context.Freelancers.FindAsync(id);
   }
   public async Task AddAsync(FreelancerDTO freelancerDto)
   {
      var freelancer = new Freelancer
      {
         FirstName = freelancerDto.FirstName,
         LastName = freelancerDto.LastName,
         Specialization = freelancerDto.Specialization,
         HourlyRate = freelancerDto.HourlyRate,
         Experience = freelancerDto.Experience,
         Country = freelancerDto.Country,
         Phone = freelancerDto.Phone,
         Email = "to test",
         Password = "***",
         Username = "........"
      };

      context.Freelancers.Add(freelancer);
      await context.SaveChangesAsync();
   }
   
   public async Task UpdateAsync(int id, FreelancerDTO freelancerDto)
   {
      var existingFreelancer = GetAsync(id).Result;

      if (existingFreelancer != null)
      {
         existingFreelancer.FirstName = freelancerDto.FirstName;
         existingFreelancer.LastName = freelancerDto.LastName;
         existingFreelancer.Specialization = freelancerDto.Specialization;
         existingFreelancer.HourlyRate = freelancerDto.HourlyRate;
         existingFreelancer.Experience = freelancerDto.Experience;
         existingFreelancer.Country = freelancerDto.Country;
         existingFreelancer.Phone = freelancerDto.Phone;

         context.Freelancers.Update(existingFreelancer);
         await context.SaveChangesAsync();
      }
   }
   public async Task DeleteAsync(int id)
   {
      var freelancerToDelete = GetAsync(id).Result;

      if (freelancerToDelete != null)
      {
         context.Freelancers.Remove(freelancerToDelete);
         await context.SaveChangesAsync();
      }
   }
   public async Task AddSkillAsync(int freelancerId, SkillDTO skillDto)
   {
      var freelancer = await GetAsync(freelancerId);

      if (freelancer != null)
      {
         if (freelancer.FreelancerSkills == null)
         {
            freelancer.FreelancerSkills = new List<Skill>(); // Initialize the collection if it's null
         }

         var skill = new Skill
         {
            Name = skillDto.Name
         };

         freelancer.FreelancerSkills.Add(skill);
         await context.SaveChangesAsync();
      }
   }
   public async Task RemoveSkillAsync(int freelancerId, int skillId)
   {
      var freelancer = await context.Freelancers
         .Include(f => f.FreelancerSkills)
         .FirstOrDefaultAsync(f => f.Id == freelancerId);

      if (freelancer != null)
      {
         var skillToRemove = freelancer.FreelancerSkills.FirstOrDefault(s => s.SkillID == skillId);

         if (skillToRemove != null)
         {
            freelancer.FreelancerSkills.Remove(skillToRemove);
            await context.SaveChangesAsync();
         }
      }
   }

   }


