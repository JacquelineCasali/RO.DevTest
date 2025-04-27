public class SalesReportDTO
{
    public int TotalVendas { get; set; }
    public decimal RendaTotal { get; set; }
    public List<ProdutoVendidoDTO> ProdutosVendidos { get; set; }
}

public class ProdutoVendidoDTO
{
    public int ProdutoId { get; set; }
    public int QuantidadeVendida { get; set; }
    public decimal RendaTotal { get; set; }
}
