using Microsoft.AspNetCore.Mvc;
using RO.DevTest.Application.Services;
using RO.DevTest.Application.DTOs;

namespace RO.DevTest.WebApi.Controllers
 {
  [Route("api/[controller]")]
    [ApiController]
    public class VendaController : ControllerBase
    {
        private readonly VendaService _vendaService;

        public VendaController(VendaService vendaService)
        {
            _vendaService = vendaService;
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] VendaDTO vendaDto)
        {
            var createdVenda = await _vendaService.CreateVendaAsync(vendaDto);
            return CreatedAtAction(nameof(GetById), new { id = createdVenda.Id }, createdVenda);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var venda = await _vendaService.GetVendaAsync(id);
            if (venda == null)
                return NotFound();

            return Ok(venda);
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var vendas = await _vendaService.GetAllVendasAsync();
            return Ok(vendas);
        }

        [HttpGet("analyze")]
        public async Task<IActionResult> GetSalesReport(DateTime startDate, DateTime endDate)
        {
            var report = await _vendaService.GetSalesReportAsync(startDate, endDate);
            return Ok(report);
        }
    }
 }