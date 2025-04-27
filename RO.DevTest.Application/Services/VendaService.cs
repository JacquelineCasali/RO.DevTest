using RO.DevTest.Application.DTOs.Venda;
using RO.DevTest.Domain.Entities;
using RO.DevTest.Persistence.Repositories;
namespace RO.DevTest.Application.Services
{
public class VendaService
{
    private readonly IVendaRepository _vendaRepository;

    public VendaService(IVendaRepository vendaRepository)
    {
        _vendaRepository = vendaRepository;
    }

    public async Task<VendaDTO> CreateVendaAsync(VendaDTO vendaDto)
    {
        var venda = new Venda
        {
            ClienteId = vendaDto.ClienteId,
            ProdutoId = vendaDto.ProdutoId,
            Total = vendaDto.Total,
            DataVenda = DateTime.UtcNow
        };

        await _vendaRepository.CreateAsync(venda);
        return vendaDto;
    }

    public async Task<List<VendaDTO>> GetAllVendasAsync()
    {
        var vendas = await _vendaRepository.GetAllAsync();
        return vendas.Select(v => new VendaDTO
        {
            Id = v.Id,
            ClienteId = v.ClienteId,
            ProdutoId = v.ProdutoId,
            Total = v.Total,
            DataVenda = v.DataVenda
        }).ToList();
    }
      // Função que retorna o relatório de vendas
    public async Task<SalesReportDTO> GetSalesReportAsync(DateTime startDate, DateTime endDate)
    {
        var vendas = await _vendaRepository.GetAllAsync(v => v.DataVenda >= startDate && v.DataVenda <= endDate);

        var totalVendas = vendas.Count;
        var totalRenda = vendas.Sum(v => v.Total);

        var produtosVendido = vendas
            .GroupBy(v => v.ProdutoId)
            .Select(group => new ProdutoVendidoDTO
            {
                ProdutoId = group.Key,
                RendaTotal = group.Sum(v => v.Total),
                QuantidadeVendida = group.Count()
            })
            .ToList();

        return new SalesReportDTO
        {
            TotalVendas = totalVendas,
            RendaTotal = totalRenda,
            ProdutosVendidos = produtosVendido
        };
    }
}

}
