using JobQuest.Data;
using JobQuest.DTO;
using JobQuest.Interface;
using JobQuest.Models;
using Microsoft.EntityFrameworkCore;

namespace JobQuest.Repository
{
	public class ClientRepository(PlatformDataDbContext context) : IClientRepository
	{
		public void Add(ClientDTO clientDto)
		{
			var client = new Client
			{
				FirstName = clientDto.FirstName,
				LastName = clientDto.LastName,
				Email = clientDto.Email,
				Country = clientDto.Country,
				Phone = clientDto.Phone,
				Username = "OMar321",
				Password = "*****************"
			};

			context.Clients.Add(client);
			context.SaveChanges();

		}
		public Client GetById(int id)
		{
			return context.Clients.SingleOrDefault(d => d.Id == id);
		}

		public List<Client> GetAll()
		{
			return context.Clients.ToList();
		}

		public void Edit(int id, ClientDTO client)
		{
			Client old = GetById(id);
			old.FirstName = client.FirstName;
			old.LastName = client.LastName;
			old.Email = client.Email;
			old.Country = client.Country;
			old.Phone = client.Phone;
			context.SaveChanges();

		}

	}
}
