using JobQuest.DTO;
using JobQuest.Models;

namespace JobQuest.Interface
{
    public interface IClientRepository
    {
        void Add(ClientDTO clientDto);
        Client GetById(int id);
        void Edit(int id, ClientDTO client);
    }
}
