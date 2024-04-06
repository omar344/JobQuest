using JobQuest.DTO;
using JobQuest.Interface;
using JobQuest.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace JobQuest.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class JobController : ControllerBase
	{
		/*
		Job GetById(int id);
		void Add(Job job);
		void Edit(int id, JobDTO job);
		void Delete(int id);
		 */
		private readonly IJobRepository _jobRepo;
		public JobController(IJobRepository jobRepo)
		{
			_jobRepo = jobRepo;
		}
		[HttpGet("{Id:int}", Name = "GetOneJobRoute")]
		public IActionResult GetByID(int Id)
		{
			Job job = _jobRepo.GetById(Id);
			return Ok(job);
		}
		[HttpPost]
		public ActionResult Add(JobDTO jobDTO)
		{
			if (ModelState.IsValid)
			{
				_jobRepo.Add(jobDTO);
			//	string url = Url.Link("GetOneJobRoute", new { id = jobDTO.Id });
				return Ok(jobDTO);
			}

			return BadRequest(jobDTO);
		}
	}
}
