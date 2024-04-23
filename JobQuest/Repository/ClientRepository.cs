using JobQuest.Data;
using JobQuest.DTO;
using JobQuest.Interface;
using JobQuest.Models;
using Microsoft.EntityFrameworkCore;

namespace JobQuest.Repository
{
    public class ClientRepository : IClientRepository
	{
		PlatformDataDbContext _context;

		public ClientRepository(PlatformDataDbContext context) 
		{
			_context = context;
		}
		public Client GetById(int id)
		{
			return _context.Clients.SingleOrDefault(d => d.Id == id);
		}
		public void Edit(int id, ClientDTO client)
		{
			Client old = GetById(id);
			old.FirstName = client.FirstName;
			old.LastName = client.LastName;
			//old.Address = client.Address;
			old.Email = client.Email;
			old.Phone = client.Phone;
			_context.SaveChanges();

		}
	}
}
