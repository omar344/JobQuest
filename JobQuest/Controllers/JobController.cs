using JobQuest.DTO;
using JobQuest.Interface;
using JobQuest.Models;
using JobQuest.Repository;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace JobQuest.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class JobController(IJobRepository jobRepo) : ControllerBase
	{
		[HttpGet("{Id:int}", Name = "GetOneJobRoute")]
		public async Task<IActionResult> GetById(int id)
		{
			Job? job = await jobRepo.GetByIdAsync(id);
			if (job == null)
			{
				return NotFound();
			}
			return Ok(job);
		}

		[HttpPost]
		public async Task<IActionResult> Add(JobDTO jobDto)
		{
			if (!ModelState.IsValid)
			{
				var errors = ModelState.Values
					.SelectMany(v => v.Errors)
					.Select(e => e.ErrorMessage)
					.ToList();

				return BadRequest(new { Error = "Validation failed", Errors = errors });
			}

			await jobRepo.AddAsync(jobDto);

			return Ok(jobDto);
		}

		[HttpPut("{id:int}")]
		public async Task<IActionResult> Update(int id, JobDTO jobDto)
		{
			if (!ModelState.IsValid)
			{
				var errors = ModelState.Values
					.SelectMany(v => v.Errors)
					.Select(e => e.ErrorMessage)
					.ToList();

				return BadRequest(new { Error = "Validation failed", Errors = errors });
			}

			await jobRepo.EditAsync(id, jobDto);

			return Ok(jobDto);
		}
		[HttpGet("delete/{id:int}")]
		public async Task<IActionResult> Delete(int id)
		{
			Job? job = await jobRepo.GetByIdAsync(id);
			if (job == null)
			{
				return NotFound();
			}

			await jobRepo.DeleteAsync(id);

			return NoContent();
		}
		[HttpGet("category/{category}")]
		public async Task<IActionResult> GetJobsByCategory(JobCategoryEnum category)
		{

			var jobs = await jobRepo.GetJobsByCategory(category);

			return Ok(jobs);
		}

		[HttpGet("budget/{budget:int}/{select}")]
		public async Task<IActionResult> GetJobByBudget(int budget, bool select)
		{
			try
			{
				var jobs = await jobRepo.GetJobByBudget(budget, select);
				return Ok(jobs);
			}
			catch (Exception ex)
			{
				return StatusCode(StatusCodes.Status500InternalServerError, "Error retrieving jobs by budget");
			}
		}


	}
}

