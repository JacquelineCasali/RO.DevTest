using Microsoft.AspNetCore.Mvc;
using RO.DevTest.Application.Services;
using RO.DevTest.Application.DTOs;

namespace RO.DevTest.WebApi.Controllers
{
    [ApiController]
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClienteController : ControllerBase
    {
        private readonly ClienteService _clienteService;

        public ClienteController(ClienteService clienteService)
        {
            _clienteService = clienteService;
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] ClienteDTO clienteDto)
        {
            var createdCliente = await _clienteService.CreateClienteAsync(clienteDto);
            return CreatedAtAction(nameof(GetById), new { id = createdCliente.Id }, createdCliente);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var cliente = await _clienteService.GetClienteAsync(id);
            if (cliente == null)
                return NotFound();

            return Ok(cliente);
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var clientes = await _clienteService.GetAllClientesAsync();
            return Ok(clientes);
        }
    }
}
}
