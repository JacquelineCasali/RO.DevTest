using Microsoft.AspNetCore.Mvc;
using RO.DevTest.Application.Services;
using RO.DevTest.Application.DTOs;

namespace RO.DevTest.WebApi.Controllers
{
   [Route("api/[controller]")]
    [ApiController]
    public class ProdutoController : ControllerBase
    {
        private readonly ProdutoService _produtoService;

        public ProdutoController(ProdutoService produtoService)
        {
            _produtoService = produtoService;
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] ProdutoDTO produtoDto)
        {
            var createdProduto = await _produtoService.CreateProdutoAsync(produtoDto);
            return CreatedAtAction(nameof(GetById), new { id = createdProduto.Id }, createdProduto);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var produto = await _produtoService.GetProdutoAsync(id);
            if (produto == null)
                return NotFound();

            return Ok(produto);
        }
[HttpGet("produtos")]
public async Task<IActionResult> GetProdutos([FromQuery] int pageIndex = 1, [FromQuery] int pageSize = 10, [FromQuery] string? searchQuery = null)
{
    var produtos = await _produtoService.GetAllProdutosAsync(pageIndex, pageSize, searchQuery);
    return Ok(produtos);
}
    }
}
