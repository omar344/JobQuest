using JobQuest.DTO;
using JobQuest.Interface;
using JobQuest.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace JobQuest.Controllers
{
    [Route("api/[controller]")]
	[ApiController]
	public class ClientController : ControllerBase
	{
		private readonly IClientRepository _clientRepo;
		public ClientController(IClientRepository clientRepo)
		{
			_clientRepo = clientRepo;
		}

		[HttpPut("{id:int}")]
		public IActionResult Update([FromRoute] int id, [FromBody] ClientDTO client)
		{
			if (ModelState.IsValid)
			{
				Client old = _clientRepo.GetById(id);
				if (old != null)
				{
					_clientRepo.Edit(id, client);
					return StatusCode(204, "Data Saved");
				}
				return BadRequest("Client is not found");
			}
			return BadRequest(client);
		}

	}
}
