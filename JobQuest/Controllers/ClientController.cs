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

		[HttpGet]
		public IActionResult GetAll()
		{
			var clients = _clientRepo.GetAll();
			return Ok(clients);
		}

		[HttpGet("{id:int}")]
		public IActionResult GetById(int id)
		{
			var client = _clientRepo.GetById(id);
			if (client == null)
			{
				return NotFound();
			}
			return Ok(client);
		}

		[HttpPost]
		public IActionResult Add([FromBody] ClientDTO client)
		{
			if (ModelState.IsValid)
			{
				_clientRepo.Add(client);
				return StatusCode(204, "Data Saved");
			}
			return BadRequest(client);
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
