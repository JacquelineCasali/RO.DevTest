using RO.DevTest.Application.DTOs.Cliente;

using RO.DevTest.Domain.Entities;
using RO.DevTest.Persistence.Repositories;

namespace RO.DevTest.Application.Services
{
    public class ClienteService
{
    private readonly IClienteRepository _clienteRepository;

    public ClienteService(IClienteRepository clienteRepository)
    {
        _clienteRepository = clienteRepository;
    }

    public async Task<ClienteDTO> CreateClienteAsync(ClienteDTO clienteDto)
    {
        var cliente = new Cliente
        {
            Nome = clienteDto.Nome,
            Email = clienteDto.Email,
            DataCadastro = DateTime.UtcNow
        };

        await _clienteRepository.CreateAsync(cliente);
        return clienteDto;
    }

    public async Task<ClienteDTO> GetClienteAsync(int id)
    {
        var cliente = await _clienteRepository.GetAsync(c => c.Id == id);
        return new ClienteDTO
        {
            Id = cliente.Id,
            Nome = cliente.Nome,
            Email = cliente.Email
        };
    }

    public async Task<List<ClienteDTO>> GetAllClientesAsync()
    {
        var clientes = await _clienteRepository.GetAllAsync();
        return clientes.Select(c => new ClienteDTO
        {
            Id = c.Id,
            Nome = c.Nome,
            Email = c.Email
        }).ToList();
    }
}

}