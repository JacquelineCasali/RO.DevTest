namespace RO.DevTest.Domain.Entities
{
    public class Produto
    {
        public Int Id { get; set; } = Guid.NewGuid();
        public string Nome { get; set; }
        public decimal Preco { get; set; }
          public int Estoque { get; set; }
    }
}
