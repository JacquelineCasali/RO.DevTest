using RO.DevTest.Application.DTOs.Produto;
using RO.DevTest.Domain.Entities;
using RO.DevTest.Persistence.Repositories;

namespace RO.DevTest.Application.Services
{
    public class ProdutoService
{
    private readonly IProdutoRepository _produtoRepository;

    public ProdutoService(IProdutoRepository produtoRepository)
    {
        _produtoRepository = produtoRepository;
    }

    public async Task<ProdutoDTO> CreateProdutoAsync(ProdutoDTO produtoDto)
    {
        var produto = new Produto
        {
            Nome = produtoDto.Nome,
            Preco = produtoDto.Preco,
            Estoque = produtoDto.Estoque
        };

        await _produtoRepository.CreateAsync(produto);
        return produtoDto;
    }

    public async Task<ProdutoDTO> GetProdutoAsync(int id)
    {
        var produto = await _produtoRepository.GetAsync(p => p.Id == id);
        return new ProdutoDTO
        {
            Id = produto.Id,
            Nome = produto.Nome,
            Preco = produto.Preco,
            Estoque = produto.Estoque
        };
    }
      public async Task<List<ProdutoDTO>> GetAllProdutosAsync(int pageIndex, int pageSize, string? searchQuery = null)
{
    var produtosQuery = _produtoRepository.GetQuery(p => string.IsNullOrEmpty(searchQuery) || p.Name.Contains(searchQuery))
        .Skip((pageIndex - 1) * pageSize)
        .Take(pageSize)
        .OrderBy(p => p.Name);

    var produtos = await produtosQuery.ToListAsync();

    return produtos.Select(p => new ProdutoDTO
    {
        Id = p.Id,
        Name = p.Name,
        Price = p.Price,
        StockQuantity = p.StockQuantity
    }).ToList();
}
    
}

}
