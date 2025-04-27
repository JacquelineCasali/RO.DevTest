namespace RO.DevTest.Domain.Entities
{
    public class Venda
    {
   public int Id { get; set; }
    public int ClienteId { get; set; }
    public int ProdutoId { get; set; }
    public decimal Total { get; set; }
    public DateTime DataVenda { get; set; }

    public Cliente Cliente { get; set; }
    public Produto Produto { get; set; }
    }
}
