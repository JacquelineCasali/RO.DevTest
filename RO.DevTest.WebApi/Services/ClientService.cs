using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using RO.DevTest.WebApi.Models;
using RO.DevTest.WebApi.Repositories; 

namespace RO.DevTest.WebApi.Services
{
    public class ClientService
    {
        private readonly AppDbContext _context;

        public ClientService(AppDbContext context)
        {
            _context = context;
        }

        public async Task<List<Client>> GetAllClientsAsync()
        {
            return await Task.FromResult(_context.Clients.ToList());
        }

        public async Task<Client> GetClientByIdAsync(Guid id)
        {
            return await Task.FromResult(_context.Clients.FirstOrDefault(c => c.Id == id));
        }

        public async Task<Client> CreateClientAsync(Client client)
        {
            _context.Clients.Add(client);
            await _context.SaveChangesAsync();
            return client;
        }

        public async Task<Client> UpdateClientAsync(Client client)
        {
            _context.Clients.Update(client);
            await _context.SaveChangesAsync();
            return client;
        }

        public async Task<bool> DeleteClientAsync(Guid id)
        {
            var client = await GetClientByIdAsync(id);
            if (client == null) return false;

            _context.Clients.Remove(client);
            await _context.SaveChangesAsync();
            return true;
        }
    }
}
