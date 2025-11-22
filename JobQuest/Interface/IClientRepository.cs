using JobQuest.DTO;
using JobQuest.Models;

namespace JobQuest.Interface
{
    public interface IClientRepository
    {
        void Add(ClientDTO clientDto);
        Client GetById(int id);
        List<Client> GetAll();
        void Edit(int id, ClientDTO client);
    }
}
