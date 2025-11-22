using JobQuest.DTO;
using JobQuest.Interface;
using JobQuest.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace JobQuest.Controllers;

[Route("api/[controller]s")]
[ApiController]
public class ProposalController(IProposalRepository proposalRepo) : ControllerBase
{
	[HttpGet]
	public async Task<IActionResult> GetAll()
	{
		var proposals = await proposalRepo.GetAllAsync();
		return Ok(proposals);
	}

	[HttpGet("job/{jobId:int}")]
	public async Task<IActionResult> GetByJobId(int jobId)
	{
		var proposals = await proposalRepo.GetProposalsByJobIdAsync(jobId);
		return Ok(proposals);
	}

	[HttpGet("freelancer/{freelancerId:int}")]
	public async Task<IActionResult> GetByFreelancerId(int freelancerId)
	{
		var proposals = await proposalRepo.GetProposalsByFreelancerIdAsync(freelancerId);
		return Ok(proposals);
	}

	[HttpGet("{id:int}")]
	public async Task<IActionResult> GetById(int id)
	{
		var proposal = await proposalRepo.GetByIdAsync(id);
		if (proposal == null)
		{
			return NotFound();
		}
		return Ok(proposal);
	}
	[HttpPost]
	public async Task<IActionResult> Add(ProposalDTO proposalDto)
	{
		if (!ModelState.IsValid) return BadRequest(proposalDto);
		await proposalRepo.AddAsync(proposalDto);
		return CreatedAtAction(nameof(Add), proposalDto);

	}

	[HttpPut("{id:int}")]
	public async Task<IActionResult> Update(int id, ProposalDTO proposalDto)
	{
		if (!ModelState.IsValid)
		{
			return BadRequest(proposalDto);
		}
		await proposalRepo.UpdateAsync(id, proposalDto);
		return Ok(proposalDto);
	}

}