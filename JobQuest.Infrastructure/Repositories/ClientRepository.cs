using JobQuest.Application.DTOs;
using JobQuest.Application.Interfaces;
using JobQuest.Domain.Entities;
using JobQuest.Infrastructure.Persistence;

namespace JobQuest.Infrastructure.Repositories;

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

    public Client? GetById(int id)
    {
        return context.Clients.SingleOrDefault(d => d.Id == id);
    }

    public List<Client> GetAll()
    {
        return context.Clients.ToList();
    }

    public void Edit(int id, ClientDTO client)
    {
        Client? old = GetById(id);
        if (old != null)
        {
            old.FirstName = client.FirstName;
            old.LastName = client.LastName;
            old.Email = client.Email;
            old.Country = client.Country;
            old.Phone = client.Phone;
            context.SaveChanges();
        }
    }
}
