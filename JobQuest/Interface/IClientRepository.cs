using JobQuest.Models;

public interface IClientRepository
{
    Task<Client> GetByIdAsync(string applicationUserId);
    Task<IEnumerable<Client>> GetAllAsync();
    Task AddAsync(Client client);
    Task UpdateAsync(Client client);
    Task DeleteAsync(string applicationUserId);
}
