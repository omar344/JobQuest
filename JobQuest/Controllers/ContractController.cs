using System.Diagnostics.Contracts;
using JobQuest.DTO;
using JobQuest.Interface;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace JobQuest.Controllers;

[Route("api/[controller]s")]
[ApiController]
public class ContractController(IContractRepository contractRepo) : ControllerBase
{
	[HttpGet]
	public async Task<IActionResult> GetAll()
	{
		var contracts = await contractRepo.GetAllAsync();
		return Ok(contracts);
	}

	[HttpGet("client/{clientId:int}")]
	public async Task<IActionResult> GetByClientId(int clientId)
	{
		var contracts = await contractRepo.GetContractsByClientIdAsync(clientId);
		return Ok(contracts);
	}

	[HttpGet("freelancer/{freelancerId:int}")]
	public async Task<IActionResult> GetByFreelancerId(int freelancerId)
	{
		var contracts = await contractRepo.GetContractsByFreelancerIdAsync(freelancerId);
		return Ok(contracts);
	}

	[HttpGet("{id:int}")]
	public async Task<ActionResult<ContractDTO>> GetContract(int id)
	{
		var contract = await contractRepo.GetById(id);

		return Ok(contract);
	}
	[HttpPost]
	public async Task<IActionResult> Add(ContractDTO contractDto)
	{
		if (!ModelState.IsValid) return BadRequest(contractDto);
		await contractRepo.AddAsync(contractDto);
		return CreatedAtAction(nameof(Add), contractDto);
	}
	[HttpPut("{id:int}")]
	public async Task<IActionResult> Edit(int id, ContractDTO contractDto)
	{
		if (!ModelState.IsValid) return BadRequest(contractDto);
		await contractRepo.UpdateAsync(id, contractDto);
		return Ok(contractDto);
	}
	[HttpDelete("{id:int}")]
	public async Task<IActionResult> Delete(int id)
	{
		await contractRepo.DeleteAsync(id);
		return NoContent();
	}
}