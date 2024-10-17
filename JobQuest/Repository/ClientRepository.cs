using JobQuest.Data; // Adjust the namespace as necessary
using JobQuest.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

public class ClientRepository : IClientRepository
{
    private readonly PlatformDataDbContext _context;

    public ClientRepository(PlatformDataDbContext context)
    {
        _context = context;
    }

    public async Task<Client> GetByIdAsync(string applicationUserId)
    {
        return await _context.Clients
            .Include(c => c.ApplicationUser) // Include related ApplicationUser if needed
            .FirstOrDefaultAsync(c => c.ApplicationUserId == applicationUserId);
    }

    public async Task<IEnumerable<Client>> GetAllAsync()
    {
        return await _context.Clients
            .Include(c => c.ApplicationUser) // Include related ApplicationUser if needed
            .ToListAsync();
    }

    public async Task AddAsync(Client client)
    {
        await _context.Clients.AddAsync(client);
        await _context.SaveChangesAsync();
    }

    public async Task UpdateAsync(Client client)
    {
        _context.Clients.Update(client);
        await _context.SaveChangesAsync();
    }

    public async Task DeleteAsync(string applicationUserId)
    {
        var client = await GetByIdAsync(applicationUserId);
        if (client != null)
        {
            _context.Clients.Remove(client);
            await _context.SaveChangesAsync();
        }
    }
}
