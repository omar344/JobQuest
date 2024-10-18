using JobQuest.DTO;
using JobQuest.Interface;
using JobQuest.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace JobQuest.Controllers
{
    [Authorize("Freelancer")]
	[Route("api/[controller]")]
	[ApiController]
	public class FreelancerController(IFreelancerRepository freelancerRepo) : ControllerBase
	{
        [HttpGet]
        public IActionResult Get()
        {
            return Ok("You have accessed Freelancer controller.");
        }
        /*
		 -job  Search by freelancer
		- jobs Filter by freelancer
		*/
        //[HttpPost]
        //public async Task<IActionResult> Add(FreelancerDTO freelancerDto)
        //{
        //	if (!ModelState.IsValid)
        //	{
        //		return BadRequest(freelancerDto);
        //	}

        //	await freelancerRepo.AddAsync(freelancerDto);
        //	return Ok(freelancerDto);
        //}
        //[HttpPut("{id:int}")]
        //public async Task<IActionResult> Update(int id, FreelancerDTO freelancerDto)
        //{
        //	if (!ModelState.IsValid)
        //	{
        //		return BadRequest(freelancerDto);
        //	}

        //	await freelancerRepo.UpdateAsync(id, freelancerDto);
        //	return Ok(freelancerDto);
        //}

        //[HttpDelete("{id:int}")]
        //public async Task<IActionResult> Delete(int id)
        //{
        //	await freelancerRepo.DeleteAsync(id);
        //	return NoContent();
        //}

        [HttpPost("{freelancerId:int}/skills")]
		public async Task<IActionResult> AddSkill(int freelancerId, SkillDTO skill)
		{
			if (!ModelState.IsValid)
			{
				return BadRequest(ModelState);
			}

			await freelancerRepo.AddSkillAsync(freelancerId, skill);
			return Ok(skill);
		}

		[HttpDelete("{freelancerId:int}/skills/{skillId:int}")]
		public async Task<IActionResult> DeleteSkill(int freelancerId, int skillId)
		{
			await freelancerRepo.RemoveSkillAsync(freelancerId, skillId);
			return NoContent();
		}
	}
}
