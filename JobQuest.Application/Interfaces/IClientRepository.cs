using JobQuest.Application.DTOs;
using JobQuest.Domain.Entities;

namespace JobQuest.Application.Interfaces;

public interface IClientRepository
{
    void Add(ClientDTO clientDto);
    Client? GetById(int id);
    List<Client> GetAll();
    void Edit(int id, ClientDTO client);
}
