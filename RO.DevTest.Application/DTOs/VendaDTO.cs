namespace RO.DevTest.Application.DTOs{
public class VendaDTO
{
    public int Id { get; set; }
    public int ClienteId { get; set; }
    public int ProdutoId { get; set; }
    public decimal Total { get; set; }
    public DateTime DataVenda { get; set; }
}
}
