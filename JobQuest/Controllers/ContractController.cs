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
	[HttpGet("{id:int}")]
	public async Task<ActionResult<ContractDTO>> GetContract(int id)
	{
		var contract = await contractRepo.GetById(id);
		
		return Ok(contract);
	}
	[HttpPost]
	public async Task<IActionResult>Add(ContractDTO contractDto)
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